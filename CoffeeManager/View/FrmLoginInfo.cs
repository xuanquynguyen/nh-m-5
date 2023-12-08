using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmLoginInfo : Form
    {
        private long _idEmployees = 0;
        private ModeExe _modeExe = ModeExe.Add;
        private DbLoginOut dbloginOut = null;
        public FrmLoginInfo(ModeExe mode, DbLoginOut dbLogin)
        {
            InitializeComponent();
            _modeExe = mode;
            dbloginOut = dbLogin;
        }

        private void lblUserSel_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị dialog chọn nhân viên
                FrmUserSel frmUserSel = new FrmUserSel();
                DialogResult dlgRet = frmUserSel.ShowDialog();
                if (dlgRet != DialogResult.OK)
                {
                    goto TheEnd;
                }

                // Lưu thông tin nhân viên đã chọn
                DbEmployeesOut dbUserInfo = frmUserSel.UserInfo;
                lblUserSel.Tag = dbUserInfo;

                // Hiển thị thông tin nhân viên đã chọn vào textbox
                txtFullName.Text = dbUserInfo.FullName;
                _idEmployees = dbUserInfo.Id;

                TxtUserName.Focus();
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void lblOk_Click(object sender, EventArgs e)
        {
            try
            {
                string message = CheckValid();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }

                DbLoginIn dbloginIn = new DbLoginIn();
                dbloginIn.IdEmployees = _idEmployees;
                dbloginIn.UserName = TxtUserName.Text;
                dbloginIn.Password = Common.Encrypt(SHOW_KEY_ENCRYPT, txtPassword.Text);
                dbloginIn.IsUse = chkUsing.Checked;

                if (_modeExe == ModeExe.Update)
                {
                    dbloginIn.Id = dbloginOut.Id;
                }

                int insert = DbLogin.InsertOrUpdateLogin(_modeExe, dbloginIn);

                MsgBox.CfmInfomation(MSG_DONE);
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

        private string CheckValid()
        {
            string message = "";

            try
            {
                if (txtFullName.Text.Equals(string.Empty))
                {
                    message = ERROR_SELECT_EM;
                    goto TheEnd;
                }

                if (TxtUserName.Text.Equals(string.Empty))
                {
                    message = ERROR_ENTER_USER;
                    goto TheEnd;
                }

                if (txtPassword.Text.Equals(string.Empty))
                {
                    message = ERROR_ENTER_PASSWORD;
                    goto TheEnd;
                }

                DataTable dt = DbLogin.CheckIdEmployees(_idEmployees);  

                if (dt == null || dt.Rows.Count > 0)
                {
                    message = DbEmployees.Message;
                    goto TheEnd;
                }    
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private void FrmLoginInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (_modeExe != ModeExe.Add)
                {
                    _idEmployees = dbloginOut.IdEmployees;
                    string name = DbEmployees.GetNameEmById(_idEmployees);
                    if(name.Length == 0)
                    {
                        MsgBox.ErrProcess(ERROR_RETRIEVING_USER);
                        goto TheEnd;
                    }

                    txtFullName.Text = name;
                    TxtUserName.Text = dbloginOut.UserName;
                    txtPassword.Text = dbloginOut.Password;
                    chkUsing.Checked = dbloginOut.IsUse;
                }    
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }
    }
}
