using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmChangeTable : Form
    {
        private long _idNeedChange = 0;
        private string _nameNeedChange = "";
        private long _idToChange = 0;
        private string _nameToChange = "";
        private DataTable _dtGroup = null;
        private bool _loadComplete = false;
        private ModeExe _modeExe = ModeExe.Add;

        private DbBill _dbBill = null;
        private DbTable _dbTable = null;

        public FrmChangeTable(ModeExe modeExe, long id, string name)
        {
            _idNeedChange = id;
            _nameNeedChange = name;
            _modeExe = modeExe;
            InitializeComponent();
            _dbBill = new DbBill();
            _dbTable = new DbTable();
        }

        private void FrmChangeTable_Load(object sender, EventArgs e)
        {
            try
            {
                if (_modeExe == ModeExe.Update)
                {
                    Text = SHOW_TABLE_MERGE;
                }    

                lblLeft.Text = _nameNeedChange;
                lblTable.Text = _nameNeedChange;

                FlpNeedChange.MaximumSize = new Size(Width / 2 - 2, 0);
                flpEmptyTable.MaximumSize = new Size(Width / 2 - 2, 0);
                

                string message = LoadGroupTb();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                _loadComplete = true;

                switch (_modeExe)
                {
                    case ModeExe.Add:
                        message = LoadDtTableNeedChange();
                        if (message.Length > 0)
                        {
                            MsgBox.ErrProcess(message);
                            goto TheEnd;
                        }

                        message = LoadDtTableToChange();
                        if (message.Length > 0)
                        {
                            MsgBox.ErrProcess(message);
                            goto TheEnd;
                        }
                        break;

                    case ModeExe.Update:
                        message = LoadDtTableNeedChange();
                        if (message.Length > 0)
                        {
                            MsgBox.ErrProcess(message);
                            goto TheEnd;
                        }
                        break;

                    default:
                        break;
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

        private string LoadGroupTb()
        {
            string message = "";
            try
            {
                _dtGroup = new DataTable();
                _dtGroup = _dbTable.GetAllGroupTable();
                cbbPosition.DataSource = _dtGroup;
                cbbPosition.ValueMember = "id";
                cbbPosition.DisplayMember = "name";            
                cbbPosition.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        public void btn_NeedChange(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _idNeedChange = long.Parse(btn.Name);
            _nameNeedChange = btn.Text;
            lblTable.Text = _nameNeedChange;
            lblLeft.Text = _nameNeedChange;
        }

        public void btn_ToChange(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _idToChange = long.Parse(btn.Name);
            _nameToChange = btn.Text;
            lblRight.Text = _nameToChange;
        }

        private string LoadDtTableToChange()
        {
            string message = "";

            try
            {
                flpEmptyTable.Controls.Clear();

                long id = long.Parse(cbbPosition.SelectedValue.ToString());
                DataTable dt = _dbTable.GetAllTable(0, id);

                foreach (DataRow row in dt.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["nameTb"].ToString(),
                        Name = row["id"].ToString(),
                        Tag = row["status"].ToString(),
                        Height = 50,
                        Width = 80,
                        BackColor = Color.White,
                    };

                    bool getSet = bool.Parse(bt.Tag.ToString());
                    if (getSet != false)
                    {
                        bt.BackColor = Color.Blue;
                    }


                    flpEmptyTable.Controls.Add(bt);
                    bt.Click += btn_ToChange;
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

        private string LoadDtTableNeedChange()
        {
            string message = "";

            try
            {
                DataTable dt = _dbTable.GetAllTableBusyNoId();
                FlpNeedChange.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["nameTb"].ToString(),
                        Name = row["id"].ToString(),
                        Tag = row["status"].ToString(),
                        Height = 50,
                        Width = 80,
                        BackColor = Color.White,
                    };

                    bool getSet = bool.Parse(bt.Tag.ToString());
                    if (getSet != false)
                    {
                        bt.BackColor = Color.Blue;
                        bt.ForeColor = Color.White;
                    }

                    FlpNeedChange.Controls.Add(bt);
                    bt.Click += btn_NeedChange;
                }

                if (_modeExe == ModeExe.Update)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Button bt = new Button
                        {
                            Text = row["nameTb"].ToString(),
                            Name = row["id"].ToString(),
                            Tag = row["status"].ToString(),
                            Height = 50,
                            Width = 80,
                            BackColor = Color.White,
                        };

                        bool getSet = bool.Parse(bt.Tag.ToString());
                        if (getSet != false)
                        {
                            bt.BackColor = Color.Blue;
                            bt.ForeColor = Color.White;
                        }

                        flpEmptyTable.Controls.Add(bt);
                        bt.Click += btn_ToChange;
                    }
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

        private void cbbPosition_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if  (_loadComplete == false)
                {
                    goto TheEnd;
                }    

                string message = LoadDtTableToChange();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (lblLeft.Text.Equals(SHOW_HAVENT_CHOSEN_TB) || lblRight.Text.Equals(SHOW_HAVENT_CHOSEN_TB))
            {
                MsgBox.CfmInfomation(MSG_HAVENT_CHOSEN_TB);
                goto TheEnd;
            }  
            
            DialogResult showMsg = MsgBox.CfmProcessing(SHOW_BILL_FROM + _nameNeedChange + SHOW_TO + _nameToChange + SHOW_CONTINUE);
            if (showMsg != DialogResult.Yes)
            {
                goto TheEnd;
            }    

            DataTable dt = _dbBill.GetAllBillDetailt(_idNeedChange);
            if (dt == null)
            {
                MsgBox.ErrProcess(ERROR_SHOW_ERROR);
                goto TheEnd;
            }

            DataRow dr = dt.Rows[0];
            long idBill = (long)dr["idBill"];
            switch (_modeExe)
            {
                case ModeExe.Add:
                    int change = _dbTable.UpdateChangeTable(_idToChange, idBill);
                    if (change != 1)
                    {
                        MsgBox.ErrProcess(ERROR_SWITCHING_TB);
                        goto TheEnd;
                    }

                    int update1 = _dbTable.UpdateStatusTableWhenChangeTrue(_idToChange);
                    if (update1 != 1)
                    {
                        MsgBox.ErrProcess(ERROR_UD_STATUS_TB);
                        goto TheEnd;
                    }
                    break;

                case ModeExe.Update:
                    DataTable dt2 = _dbBill.GetAllBillDetailt(_idToChange);
                    if (dt2 == null)
                    {
                        MsgBox.ErrProcess(ERROR_SHOW_ERROR);
                        goto TheEnd;
                    }

                    DataRow dr2 = dt2.Rows[0];
                    long idBill2 = (long)dr2["idBill"];

                    foreach (DataRow dr1 in dt.Rows)
                    {
                        long idDetailt = (long)dr1["id"];
                        long idProduct = (long)dr1["idProduct"];
                        int quantily = (int)dr1["quantily"];
                        double unitPrice = (double)dr1["unitPrice"];
                        double totalMoney = unitPrice * quantily;

                        DbBillDetailtIn DbBillDetailtIn = new DbBillDetailtIn();
                        DbBillDetailtIn.UnitPrice = unitPrice;
                        DbBillDetailtIn.Quantity = quantily;
                        DbBillDetailtIn.IdBill = idBill2;
                        DbBillDetailtIn.IdProduct = (long)dr1["idProduct"];
                        DbBillDetailtIn.IntoMoney = totalMoney;
                        DbBillDetailtIn.Description = (string)dr1["description"]; ;

                        long idInSertBill = _dbBill.SaveBillDetailt(DbBillDetailtIn);
                        if (idInSertBill == 0)
                        {
                            MsgBox.ErrProcess(ERROR_ADDING_DATA);
                            goto TheEnd;
                        }

                        // Xóa bill chi tiết bên bàn chuyển
                        int delBillDetailt = _dbBill.DelNumberBillDetailt(idDetailt);
                        if (delBillDetailt != 1)
                        {
                            MsgBox.ErrProcess(ERROR_WHEN_DEL);
                            goto TheEnd;
                        }    
                    }

                    // Xóa hóa đơn bên bàn chuyển
                    int delBill = _dbBill.DelBill(idBill);
                    if (delBill != 1)
                    {
                        MsgBox.ErrProcess(ERROR_WHEN_DEL);
                        goto TheEnd;
                    }

                    // Cập nhật lại tổng tiền bên Bill2
                    _dbBill.UpdateMoney(idBill2);   
                    break;

                default:
                    break;
            }    
            
            int update = _dbTable.UpdateStatusTableWhenChangeFalse(_idNeedChange);
            if (update != 1)
            {
                MsgBox.ErrProcess(ERROR_UD_STATUS_TB);
                goto TheEnd;
            }           

            DialogResult = DialogResult.OK;

        TheEnd:
            return;
        }
    }
}
