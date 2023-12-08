using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmAddOrEditEmployees : Form
    {
        private ModeExe _modeExe = ModeExe.Add;
        private DbEmployeesOut _employeesOut = null;
        private bool _isEnable = false;
        private bool _isUse = true;

        public FrmAddOrEditEmployees(ModeExe mode, bool enable, DbEmployeesOut dbEmOut)
        {
            InitializeComponent();
            _modeExe = mode;
            _employeesOut = dbEmOut;
            _isEnable = enable;
        }

        private void FrmAddOrEditEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                GrbInfo.Enabled = _isEnable;
                if (_modeExe != ModeExe.Add)
                {
                    TxtFullName.Text = _employeesOut.FullName;
                    TxtAddress.Text = _employeesOut.Address;
                    TxtPhone.Text = _employeesOut.PhoneNumber;
                    TxtIdCard.Text = _employeesOut.IdCard;
                    DtpDateWork.Value = _employeesOut.DateWork;
                    CkbStatus.Checked = _employeesOut.Status;
                    PtbAvatar.Image = Common.ByteToImage(_employeesOut.Img);
                }    
            }
            catch ( Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void PtbAvatar_Click(object sender, EventArgs e)
        {
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "image files (*.jpg)|*.jpg;| PNG(*.png;)|*.png;| JPGE(*.jpge;)|*.jpge;| Gif(*.gif;)|*.gif;| Bmp(*.bmp;)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PtbAvatar.Image = new Bitmap(dlg.FileName);
                    Type pboxType = PtbAvatar.GetType();
                    PropertyInfo irProperty = pboxType.GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);
                    Rectangle rectangle = (Rectangle)irProperty.GetValue(PtbAvatar, null);
                }
            }
        }

        private void CkbStatus_CheckedChanged(object sender, EventArgs e)
        {
            CkbStatus.ForeColor = Color.Blue;
            if (CkbStatus.Checked == false)
            {
                _isUse = false;
                CkbStatus.ForeColor = Color.Red;
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (_modeExe == ModeExe.View)
                {
                    DialogResult = DialogResult.Abort;
                    goto TheEnd;
                }    

                if (TxtFullName.Text.Equals(string.Empty))
                {
                    MsgBox.CfmInfomation(MSG_ENTER_USERNAME);
                    goto TheEnd;
                }

                DbEmployeesIn emIn = new DbEmployeesIn();

                if (_modeExe == ModeExe.Update)
                {
                    emIn.Id = _employeesOut.Id;
                }   
                
                emIn.FullName = TxtFullName.Text;
                emIn.PhoneNumber = TxtPhone.Text;
                emIn.Address = TxtAddress.Text;
                emIn.IdCard = TxtIdCard.Text;
                emIn.DateWord = DtpDateWork.Value;
                emIn.Img = Common.ImageToByte(PtbAvatar.Image);
                emIn.Status = CkbStatus.Checked;

                long insert = DbEmployees.InserOrUpdatetUser(_modeExe, emIn);
                if (insert != 1)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                BtnBrowse.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmAddOrEditEmployees_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.B)
            //{
            //    BtnBrowse.PerformClick();
            //}
            if (e.KeyCode == Keys.F2)
            {
                BtnBrowse.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isControl = char.IsControl(e.KeyChar);
            bool isDigit = char.IsDigit(e.KeyChar);
            if ((isControl == false) && (isDigit == false))
            {
                e.Handled = true;
                MsgBox.ErrProcess(MSG_PRESS_NUMBER);
            }

        }
    }
}
