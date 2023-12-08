using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmMain : Form
    {
        private DataTable _dt = null;
       
        private string _nameTable = "";
        private string _messageClose = MSG_CLOSE_FORM;
        private string _nameProduct = "";
        private static string _userFullName = "";
        private static string _userName = "";
        private const string _defaultSettings = "14;70;80";
        private const string _defaultSettingsTb = "16;50;80";

        private double _unitPrice = 0;
        private long _idBill = 0;      
        private long _idCustomer = 0;
        private long _idEmployees = 0;
        private long _idTable = 0;
        private long _idProduct = 0;
        private long _idLogin = 0;
        // Hình thức mua tại chỗ hay đem về
        private int _modeInplaceOrBring = 0;
        private int _buttonProdutHeight = 70;
        private int _buttonProdutWidth = 80;
        private int _buttonTableHeight = 50;
        private int _buttonTableWidth = 80;
        private int _fontSizePr = 14;
        private int _fontSizeTb = 16;
        private int _modeGetTable = 1;

        private bool _isLogOut = false;
        private bool _loadComplete = false;
        private bool _isSave = true;
        private bool _needLoad = true;
        private bool _isRestart = false;

        private DbCustomer _dbCustomer = null;
        private DbBill _dbBill = null;
        private DbTable _dbTable = null;

        public FrmMain(long idEmployees, string userFullName, string userName, long idLogin)
        {
            _idEmployees = idEmployees;
            _userFullName = userFullName;
            _userName = userName;
            _idLogin = idLogin;
            InitializeComponent();
            _dbCustomer = new DbCustomer();
            _dbBill = new DbBill();
            _dbTable = new DbTable();
        }

        /// <summary>
        /// <para>Sự kiện load</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                string message = SetRoleForLogin();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                message = LoadGroupTb();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                message = LoadGroupProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                // Xác định đã load xong các nhóm
                _loadComplete = true;
                _modeGetTable = 1;

                message = ReadSettingTable();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
             
                message = ReadSettingProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                FormatDgv();

                lblFullName.Text = _userFullName;
                ActiveControl = txtSearch;

                SetToolTip();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }          

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Hiển thị tooltip</para>
        /// </summary>
        private void SetToolTip()
        {
            ToolTip toolTipMain = new ToolTip();
            toolTipMain.AutoPopDelay = 5000;
            toolTipMain.InitialDelay = 1000;
            toolTipMain.ReshowDelay = 500;
            toolTipMain.ShowAlways = true;
            toolTipMain.SetToolTip(LblSettingTable, SHOW_TOOLTIP_SET_TB);
            toolTipMain.SetToolTip(LblSettingPr, SHOW_TOOLTIP_SET_PR);
        }

        /// <summary>
        /// <para>Set quyền cho tài khoản đăng nhập</para>
        /// </summary>
        /// <returns></returns>
        private string SetRoleForLogin()
        {
            string message = "";
            try
            {
                List<DbLoginRoleOut> dbLoginRoleOuts = new List<DbLoginRoleOut>();
                dbLoginRoleOuts = DbLogin.GetLoginRoleByIdLogin(_idLogin);
                foreach(DbLoginRoleOut dbLoginRole in dbLoginRoleOuts)
                {
                    long idMenu = dbLoginRole.IdMenuItems;
                    string menuName = DbLogin.GetMenuNameById(idMenu);
                    foreach (ToolStripMenuItem items in mnsMain.Items)
                    {
                        foreach (ToolStripItem item in items.DropDownItems)
                        {
                            string itemname = item.Name;
                            if (itemname.Equals(menuName))
                            {
                                item.Enabled = true;
                                break;
                            }
                        }                                                      
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

        /// <summary>
        /// <para>Tải dữ liệu nhóm bàn</para>
        /// </summary>
        /// <returns></returns>
        private string LoadGroupTb()
        {
            string message = "";
            try
            {
                DataTable dt = new DataTable();
                dt = _dbTable.GetAllGroupTable();
                cbbPosition.DataSource = dt;
                cbbPosition.DisplayMember = "name";
                cbbPosition.ValueMember = "id";
                cbbPosition.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        /// <summary>
        /// <para>Load danh sách bàn</para>
        /// </summary>
        private string LoadDtTable()
        {
            string message = "";

            try
            {
                flpEmptyTable.Controls.Clear();
                long id = 0;
                if (cbbPosition.SelectedIndex != -1)
                {
                    id = long.Parse(cbbPosition.SelectedValue.ToString());
                }    
                
                _dt = new DataTable();
                _dt = _dbTable.GetAllTable(_modeGetTable, id);

                Label lb1 = new Label
                {
                    Text = MSG_TABLE_EMPTY,
                    AutoSize = false,
                    Height = 30,
                    Width = 300,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    ForeColor = Color.Blue,
                    BackColor = Color.Khaki,
                };

                flpEmptyTable.Controls.Add(lb1);

                foreach (DataRow row in _dt.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["nameTb"].ToString(),
                        Name = row["id"].ToString(),
                        Tag = row["status"].ToString(),
                        Height = _buttonTableHeight,
                        Width = _buttonTableWidth,
                        BackColor = Color.White,
                        Font = new Font("Arial",_fontSizeTb, FontStyle.Regular),
                    };

                    bool getSet = bool.Parse(bt.Tag.ToString());
                    if (getSet != false)
                    {
                        bt.BackColor = Color.Blue;
                    }


                    flpEmptyTable.Controls.Add(bt);
                    bt.Click += btn_msg;
                }

                Label lb = new Label
                {
                    Text = MSG_ALREADY_OCCUPIED,
                    AutoSize = false,
                    Height = 30,
                    Width = 300,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    ForeColor = Color.Red,
                    BackColor = Color.Khaki,
                };

                flpEmptyTable.Controls.Add(lb);

                DataTable dt = _dbTable.GetAllTableBusy(_modeGetTable, id);

                foreach (DataRow row in dt.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["nameTb"].ToString(),
                        Name = row["id"].ToString(),
                        Tag = row["status"].ToString(),
                        Height = _buttonTableHeight,
                        Width = _buttonTableWidth,
                        BackColor = Color.White,
                        Font = new Font("Arial", _fontSizeTb, FontStyle.Regular),
                    };

                    bool getSet = bool.Parse(bt.Tag.ToString());
                    if (getSet != false)
                    {
                        bt.BackColor = Color.Blue;
                        bt.ForeColor = Color.White;
                    }


                    flpEmptyTable.Controls.Add(bt);
                    bt.Click += btn_msg;
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

        /// <summary>
        /// <para>Sự kiện click nút Bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_msg(object sender, EventArgs e)
        {
            if (_isSave == false)
            {
                DialogResult dia = MessageBox.Show(MSG_WANT_TO_SAVE, MSG_NOTIFICATION,
                    MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (dia == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                }                   
            }

            ClearText();

            Button btn = (Button)sender;
            _idTable = long.Parse(btn.Name);
            _idCustomer = 0;
            _nameTable = btn.Text;
            lblTable.Text = _nameTable;

            _needLoad = true;
            if (btn.BackColor == Color.Blue)
            {
                _needLoad = false;
            } 
            
            string message = LoadAllBillDetailt();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
            }
            dgvMain.ClearSelection();
            flpRight.Visible = true;
        }

        /// <summary>
        /// <para>Tải dữ liệu khách hàng</para>
        /// </summary>
        /// <returns></returns>
        private string LoadDtCustomer()
        {
            string message = "";

            try
            {
                flpEmptyTable.Controls.Clear();

                _dt = new DataTable();
                _dt = _dbCustomer.GetAllCustomer();

                Label lb1 = new Label
                {
                    Text = SHOW_OLD_CUSTOMERS,
                    AutoSize = false,
                    Height = 30,
                    Width = 300,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    ForeColor = Color.Blue,
                    BackColor = Color.Khaki,
                };

                flpEmptyTable.Controls.Add(lb1);

                foreach (DataRow row in _dt.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["name"].ToString(),
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
                    bt.Click += btn_customer;
                }

                Label lb = new Label
                {
                    Text = SHOW_CUS_WAITING,
                    AutoSize = false,
                    Height = 30,
                    Width = 300,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    ForeColor = Color.Red,
                    BackColor = Color.Khaki,
                };

                flpEmptyTable.Controls.Add(lb);

                DataTable dt = _dbCustomer.GetAllCustomerBusy();

                foreach (DataRow row in dt.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["name"].ToString(),
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
                    bt.Click += btn_customer;
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

        public void btn_customer(object sender, EventArgs e)
        {
            if (_isSave == false)
            {
                DialogResult dia = MessageBox.Show(MSG_WANT_TO_SAVE, MSG_NOTIFICATION,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dia == DialogResult.Yes)
                {
                    // Tự động nhấn nút save
                    btnSave.PerformClick();
                }      
            }

            Button btn = (Button)sender;
            _idCustomer = long.Parse(btn.Name);
            _idTable = 0;
            _nameTable = btn.Text;
            lblTable.Text = _nameTable;

            _needLoad = true;
            if (btn.BackColor == Color.Blue)
            {
                _needLoad = false;
            }

            string message = LoadAllBillDetailt();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
            }
            dgvMain.ClearSelection();
            flpRight.Visible = true;
        }

        /// <summary>
        /// <para>Load dữ liệu hóa đơn chi tiết</para>
        /// </summary>
        /// <returns></returns>
        private string LoadAllBillDetailt()
        {
            string message = "";
            try
            {
                DataTable dt = new DataTable();
                switch (_modeInplaceOrBring)
                {                    
                    case 0:
                        dt = _dbBill.GetAllBillDetailt(_idTable);
                        if (dt == null)
                        {
                            message = _dbBill.Message;
                            goto TheEnd;
                        }
                        break;

                    case 1:
                        dt = _dbBill.GetAllBillDetailtByIdCustomer(_idCustomer);
                        if (dt == null)
                        {
                            message = _dbBill.Message;
                            goto TheEnd;
                        }
                        break;

                    default:
                        break;
                }    
                

                dgvMain.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    _idBill = 0;
                    txtTotalMoney.Text = "0";
                    goto TheEnd;
                }

                dgvMain.RowsDefaultCellStyle.BackColor = Color.Bisque;
                dgvMain.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.Beige;

                // Tính tổng tiền
                double totalMoney = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalMoney += double.Parse(row["intoMoney"].ToString());
                }

                DataRow row1 = dt.Rows[0];
                _idBill = long.Parse(row1["idBill"].ToString());
                txtTotalMoney.Text = totalMoney.ToString();

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
                _modeGetTable = 0;
                if (_loadComplete == false)
                {
                    goto TheEnd;
                }    

                string message = LoadDtTable();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Tải dữ liệu nhóm sản phẩm
        /// </summary>
        /// <returns></returns>
        private string LoadGroupProduct()
        {
            string message = "";
            try
            {
                DataTable dt = new DataTable();
                dt = _dbTable.GetAllGroupProduct();
                cbbMenu.DataSource = dt;
                cbbMenu.DisplayMember = "nameGr";
                cbbMenu.ValueMember = "idGr";
                cbbMenu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        /// <summary>
        /// <para>Đọc file cài đặt Bàn</para>
        /// </summary>
        /// <returns></returns>
        private string ReadSettingTable()
        {
            string message = SHOW_NONE;
            try
            {
                string pathSetPr = Application.StartupPath;
                // Đọc file setting
                string defaultSettings = pathSetPr + "\\DefaultSettingTables.tb";
                if (File.Exists(defaultSettings) == false)
                {
                    File.Create(defaultSettings);
                    goto Step1;
                }
                else
                {
                    string settingTb = File.ReadAllText(defaultSettings);
                    if (settingTb.Equals(string.Empty))
                    {
                        goto Step1;
                    }

                    string[] stTb = settingTb.Split(new char[] { ';' });
                    _buttonTableHeight = int.Parse(stTb[0]);
                    _buttonTableWidth = int.Parse(stTb[1]);
                    _fontSizeTb = int.Parse(stTb[2]);
                    goto Step2;
                }

            Step1:
                string[] getSetting = _defaultSettingsTb.Split(new char[] { ';' });
                _buttonTableHeight = int.Parse(getSetting[0]);
                _buttonTableWidth = int.Parse(getSetting[1]);
                _fontSizeTb = int.Parse(getSetting[2]);

            Step2:
                message = LoadDtTable();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
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

        /// <summary>
        /// <para>Đọc file cài đặt sản phẩm</para>
        /// </summary>
        /// <returns></returns>
        private string ReadSettingProduct()
        {
            string message = SHOW_NONE;
            try
            {
                string pathSetPr = Application.StartupPath ;
                // Đọc file setting
                string defaultSettings = pathSetPr + "\\DefaultSettings.tb";
                if (File.Exists(defaultSettings) == false)
                {
                    File.Create(defaultSettings);
                    goto Step1;
                }
                else
                {
                    string settingTb = File.ReadAllText(defaultSettings);
                    if (settingTb.Equals(string.Empty))
                    {
                        goto Step1;
                    }

                    string[] stTb = settingTb.Split(new char[] { ';' });
                    _buttonProdutHeight = int.Parse(stTb[0]);
                    _buttonProdutWidth = int.Parse(stTb[1]);
                    _fontSizePr = int.Parse(stTb[2]);
                    goto Step2;
                }

            Step1:
                string[] getSetting = _defaultSettings.Split(new char[] { ';' });
                _buttonProdutHeight = int.Parse(getSetting[0]);
                _buttonProdutWidth = int.Parse(getSetting[1]);
                _fontSizePr = int.Parse(getSetting[2]);

            Step2:
                message = LoadProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
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

        /// <summary>
        /// <para>Load sản phẩm</para>
        /// </summary>
        /// <returns></returns>
        private string LoadProduct()
        {
            string message = "";
            try
            {
                long id = long.Parse(cbbMenu.SelectedValue.ToString());
                DataTable dtP = _dbTable.GetAllProduct(id);
                flpRight.Controls.Clear();

                foreach (DataRow row in dtP.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["name"].ToString(),
                        Name = row["id"].ToString(),
                        Tag = row["unitPrice"].ToString(),
                        Image = ByteToImage((byte[])row["img"]),
                        ImageAlign = ContentAlignment.TopCenter,
                        Height = _buttonProdutHeight,
                        Width = _buttonProdutWidth,
                        BackColor = Color.White,
                        TextAlign = ContentAlignment.BottomCenter,
                        Font = new Font("Arial", _fontSizePr, FontStyle.Regular)
                };

                    flpRight.Controls.Add(bt);
                    bt.Click += btn_Product;
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

        // Tạo sự kiện click button
        public void btn_Product(object sender, EventArgs e)
        {
            if (lblTable.Text.Equals(MSG_HAVENT_SELECT_TABLE))
            {
                MessageBox.Show(MSG_SELECT_TABLE_FIRST);
                goto TheEnd;
            }    

            Button btn = (Button)sender;
            _idProduct = long.Parse(btn.Name);
            _nameProduct = btn.Text;
            _unitPrice = double.Parse(btn.Tag.ToString());

            FrmAddBillDetailt frmAddBdt = 
                new FrmAddBillDetailt(ModeExe.Add, _idTable,
                _idProduct, _nameProduct, _unitPrice, _idBill,
                SHOW_NONE, _idEmployees, _idCustomer);
            DialogResult show = frmAddBdt.ShowDialog();
            if (show != DialogResult.OK)
            {
                goto TheEnd;
            }

            // Load lại id hóa đơn
            _idBill = frmAddBdt.SendIdBill;

            string message = LoadAllBillDetailt();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
            }
           
            // Xác định lại trạng thái Lưu dữ liệu
            _isSave = false;

            // Nếu không cần load lại danh sách bàn thì out
            if (_needLoad == false)
            {
                goto TheEnd;
            }    

            switch (_modeInplaceOrBring)
            {
                case 0:
                    message = LoadDtTable();
                    if (message.Length > 0)
                    {
                        MessageBox.Show(message);
                        goto TheEnd;
                    }
                    break;

                case 1:
                    message = LoadDtCustomer();
                    if (message.Length > 0)
                    {
                        MessageBox.Show(message);
                        goto TheEnd;
                    }
                    break;

                default:
                    break;
            }

            _needLoad = false;

            dgvMain.ClearSelection();

        TheEnd:
            return;

        }

        /// <summary>
        /// <para>Set default cell</para>
        /// </summary>
        private void FormatDgv()
        {
            dgvMain.Columns["unitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns["unitPrice"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns["unitPrice"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMain.Columns["unitPrice"].DefaultCellStyle.Format = "#,0.###";

            dgvMain.Columns["intoMoney"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns["intoMoney"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns["intoMoney"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMain.Columns["intoMoney"].DefaultCellStyle.Format = "#,0.###";

            dgvMain.Columns["quantily"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.Columns["quantily"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.Columns["quantily"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
      
        /// <summary>
        /// <pa>Chuyển byte thành hình ảnh</pa>
        /// </summary>
        /// <param name="byteIn"></param>
        /// <returns></returns>
        private Image ByteToImage(byte[] byteIn)
        {
            MemoryStream ms = new MemoryStream(byteIn);
            Image rt = Image.FromStream(ms);
            return rt;
        }

        private void tsmnMenu_Click(object sender, EventArgs e)
        {
            FrmProduct prd = new FrmProduct();
            prd.ShowDialog();
        }

        private void txtTotalMoney_TextChanged(object sender, EventArgs e)
        {
            txtTotalMoney.Text = string.Format("{0:#,##0}", double.Parse(txtTotalMoney.Text));
        }

        private void txtMoneyPay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMoneyPay.Text = string.Format("{0:#,##0}", double.Parse(txtMoneyPay.Text));
                txtMoneyPay.SelectionStart = txtMoneyPay.Text.Length;
                double totalMoney = double.Parse(txtTotalMoney.Text.Trim());
                double moneyPay = double.Parse(txtMoneyPay.Text.Trim());
                double returnMoney = moneyPay - totalMoney;
                txtMoneyReturn.Text = returnMoney.ToString();
            }
            catch (Exception)
            {
                // throw ex;
            }
        }

        /// <summary>
        /// Gán format tiền tệ cho textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoneyReturn_TextChanged(object sender, EventArgs e)
        {
            txtMoneyReturn.Text = string.Format("{0:#,##0}", double.Parse(txtMoneyReturn.Text));
        }

        /// <summary>
        /// <para>Chọn nhóm sản phẩm</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbMenu_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_loadComplete == false)
                {
                    goto TheEnd;
                }

                string message = LoadProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Xóa text</para>
        /// </summary>
        private void ClearText()
        {
            txtMoneyPay.Text = "";
            txtMoneyReturn.Text = "0";
            txtTotalMoney.Text = "0";
            txtDescription.Text = "";
        }

        /// <summary>
        /// <para>Lưu dữ liệu</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                double totalMoney = double.Parse(txtTotalMoney.Text);
                if (totalMoney == 0)
                {
                    MsgBox.CfmInfomation(MSG_NOTHING_TO_SAVE);
                    goto TheEnd;
                }   
                
                int updat = _dbBill.UpdateTotalMoneyBill(_idBill, totalMoney);
                if (updat != 1)
                {
                    MessageBox.Show(ERROR_UPDATE_BILL);
                    goto TheEnd;
                }

                // Cập nhật lại trạng thái lưu
                _isSave = true;

                //MessageBox.Show("Lưu dữ liệu thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Sửa hóa đơn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    goto TheEnd;
                }

                long idBillDetail = (long)dgvMain.SelectedRows[0].Cells["id"].Value;
                int quantily = (int)dgvMain.SelectedRows[0].Cells["quantily"].Value;
                string nameProduct = (string)dgvMain.SelectedRows[0].Cells["drink"].Value;
                double unitPrice = (double)dgvMain.SelectedRows[0].Cells["unitPrice"].Value;
                string description = (string)dgvMain.SelectedRows[0].Cells["description"].Value;
                FrmAddBillDetailt frmAddBdt =
                    new FrmAddBillDetailt(ModeExe.Update, _idTable, quantily, nameProduct, unitPrice, 
                    idBillDetail,description, _idEmployees, _idCustomer);
                DialogResult show = frmAddBdt.ShowDialog();
                if (show != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadAllBillDetailt();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Xóa hóa đơn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    goto TheEnd;
                }

                long idBillDetail = (long)dgvMain.SelectedRows[0].Cells["id"].Value;
                string drink = (string)dgvMain.SelectedRows[0].Cells["drink"].Value;
                DialogResult show = MessageBox.Show(drink + MSG_DEL_QUES, MSG_NOTIFICATION,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (show != DialogResult.Yes)
                {
                    goto TheEnd;
                }

                int del = _dbBill.DelNumberBillDetailt(idBillDetail);
                if (del != 1)
                {
                    MessageBox.Show(ERROR_WHEN_DEL);
                    goto TheEnd;
                }

                MessageBox.Show(MSG_DELETED + drink + MSG_OUT_OF_LIST);

                string message = LoadAllBillDetailt();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        TheEnd:
            return;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        /// <summary>
        /// <para>Tìm kiếm sản phẩm</para>
        /// </summary>
        /// <returns></returns>
        private string SearchProduct()
        {
            string message = "";
            try
            {
                long id = long.Parse(cbbMenu.SelectedValue.ToString());
                string name = txtSearch.Text;

                DataTable dtP = DbProduct.GetProductForSearch(id, name);
                flpRight.Controls.Clear();

                foreach (DataRow row in dtP.Rows)
                {
                    Button bt = new Button
                    {
                        Text = row["name"].ToString(),
                        Name = row["id"].ToString(),
                        Tag = row["unitPrice"].ToString(),
                        Image = ByteToImage((byte[])row["img"]),
                        ImageAlign = ContentAlignment.TopCenter,
                        Height = 60,
                        Width = 80,
                        BackColor = Color.White,
                        TextAlign = ContentAlignment.BottomCenter,
                    };

                    flpRight.Controls.Add(bt);
                    bt.Click += btn_Product;
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

        /// <summary>
        /// <para>Tìm kiếm sản phẩm</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string message = "";

                if (cbbMenu.Text == string.Empty)
                {
                    MessageBox.Show(MSG_SELECT_GR_FIRST);
                    goto TheEnd;
                }    

                if (txtSearch.Text == string.Empty)
                {
                    message = LoadProduct();
                    if (message.Length > 0)
                    {
                        MessageBox.Show(message);
                        goto TheEnd;
                    }
                }   
                
                message = SearchProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        TheEnd:
            return;
        }

        private void ckbInPlace_Click(object sender, EventArgs e)
        {
            ckbInPlace.Checked = true;
            ckbBringBack.Checked = false;
        }

        private void ckbBringBack_Click(object sender, EventArgs e)
        {
            ckbInPlace.Checked = false;
            ckbBringBack.Checked = true;
        }

        /// <summary>
        /// <para>Chọn hình thức bán tại chỗ</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbInPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSave == false)
            {
                DialogResult dia = MessageBox.Show(MSG_WANT_TO_SAVE, MSG_NOTIFICATION,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dia == DialogResult.Yes)
                {
                    // Tự động nhấn nút save
                    btnSave.PerformClick();
                }

                lblTable.Text = MSG_HAVENT_SELECT_TABLE;
                _idTable = 0;
                string message = LoadAllBillDetailt();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                }
            }

            ckbInPlace.BackColor = Color.White;
            if (ckbInPlace.Checked != false)
            {
                ckbInPlace.BackColor = Color.Red;
                btnAddCustomer.Enabled = false;
                btnAddTable.Enabled = true;
                grPosition.Visible = true;
                string message = LoadDtTable();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                _modeInplaceOrBring = 0;
                grbTable.Text = SHOW_TABLE_LIST;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Chọn hình thức bán mang về</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbBringBack_CheckedChanged(object sender, EventArgs e)
        {
            if (_isSave == false)
            {
                DialogResult dia = MessageBox.Show(MSG_WANT_TO_SAVE, MSG_NOTIFICATION,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dia == DialogResult.Yes)
                {
                    // Tự động nhấn nút save
                    btnSave.PerformClick();
                }

                lblTable.Text = MSG_HAVENT_SELECT_TABLE;
                _idTable = 0;
                string message = LoadAllBillDetailt();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                }
            }

            ckbBringBack.BackColor = Color.White;
            if (ckbBringBack.Checked != false)
            {
                ckbBringBack.BackColor = Color.Red;
                btnAddCustomer.Enabled = true;
                btnAddTable.Enabled = false;
                grPosition.Visible = false;

                string message = LoadDtCustomer();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                _modeInplaceOrBring = 1;
                grbTable.Text = SHOW_CUS_LIST;

            TheEnd:
                return;
            }
        }

        /// <summary>
        /// <para>Thanh toán hóa đơn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMoneyPay.Text.Length < 1)
                {
                    DialogResult ques = MsgBox.CfmProcessing(MSG_QUES_ACCEPT);
                    if (ques != DialogResult.Yes)
                    {
                        goto TheEnd;
                    }    
                }   
                
                long idBill = (long)dgvMain.Rows[0].Cells["idBill"].Value;
                btnSave.PerformClick();
                //FrmPrint print = new FrmPrint(idBill);
                //print.ShowDialog();

                if (CkbPrintBill.Checked != false)
                {
                    ClPrintBill clprint = new ClPrintBill(idBill, _userFullName, lblTable.Text, "");
                    clprint.PrintReport();
                    //clprint.DisplayInvoice();
                }

                if (CkbPreviewPrint.Checked != false)
                {
                    ClPrintBill clprint = new ClPrintBill(idBill, _userFullName, lblTable.Text, "");
                    //clprint.PrintReport();
                    clprint.DisplayInvoice();
                }

                string message = UpdateBillAndTable();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                lblTable.Text = MSG_HAVENT_SELECT_TABLE;
                _idTable = 0;
                message = LoadAllBillDetailt();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                }

                ClearText();
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Cập nhật lại trạng thái bill và bàn hoặc khách hàng sau khi tính tiền</para>
        /// </summary>
        /// <returns></returns>
        private string UpdateBillAndTable()
        {
            string message = "";
            try
            {
                int update = 0;
                update = _dbBill.UpdateStatusBill(_idBill);
                if (update != 1)
                {
                    MsgBox.ErrProcess(ERROR_UPDATE_BILL_STATUS);
                    goto TheEnd;
                }    

                switch (_modeInplaceOrBring)
                {
                    case 0:
                        update = _dbTable.UpdateStatusTableToFalse(_idTable);
                        if (update != 1)
                        {
                            MsgBox.ErrProcess(ERROR_UPDATE_TABLE_STATUS);
                            goto TheEnd;
                        }    
                        break;

                    case 1:
                        update = _dbCustomer.UpdateStatusCustomer(_idCustomer);
                        if (update != 1)
                        {
                            MsgBox.ErrProcess(ERROR_UPDATE_CUS_STATUS);
                            goto TheEnd;
                        }
                        break;

                    default:
                        break;
                }

                MsgBox.CfmInfomation(MSG_DONE);

                switch (_modeInplaceOrBring)
                {
                    case 0:
                        message = LoadDtTable();
                        if (message.Length > 0)
                        {
                            MessageBox.Show(message);
                            goto TheEnd;
                        }
                        break;

                    case 1:
                        message = LoadDtCustomer();
                        if (message.Length > 0)
                        {
                            MessageBox.Show(message);
                            goto TheEnd;
                        }
                        break;

                    default:
                        break;
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

        /// <summary>
        /// <para>Xem - thêm - sửa - xóa danh sách bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmnTable_Click(object sender, EventArgs e)
        {
            FrmTable frmTable = new FrmTable();
            frmTable.ShowDialog();
        }

        /// <summary>
        /// <para>Thêm bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            FrmAddTable frmAdd = new FrmAddTable(ModeExe.Add, 0, SHOW_NONE, 0, SHOW_NONE);
            DialogResult dialog = frmAdd.ShowDialog();
            if (dialog != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = LoadDtTable();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Đổi bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            try
            {
                long idTable = _idTable;
                string nameTable = lblTable.Text;
                if (_needLoad == true)
                {
                    idTable = 0;
                    nameTable = MSG_HAVENT_SELECT_TABLE;
                }  
                
                FrmChangeTable frmChange = new FrmChangeTable(ModeExe.Add, idTable, nameTable);
                DialogResult show = frmChange.ShowDialog();
                if (show != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadDtTable();
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

        /// <summary>
        /// <para>Gộp bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergeTable_Click(object sender, EventArgs e)
        {
            long idTable = _idTable;
            string nameTable = lblTable.Text;
            if (_needLoad == true)
            {
                idTable = 0;
                nameTable = MSG_HAVENT_SELECT_TABLE;
            }

            FrmChangeTable frmChange = new FrmChangeTable(ModeExe.Update, idTable, nameTable);
            DialogResult show = frmChange.ShowDialog();
            if (show != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = LoadDtTable();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            DbCustomerOut dbCustomerOut = new DbCustomerOut();
            FrmCus frmCus = new FrmCus(ModeExe.Add, dbCustomerOut);
            DialogResult dia = frmCus.ShowDialog();
            if (dia != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = LoadDtCustomer();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }
     
        private void CkbPrintBill_CheckedChanged(object sender, EventArgs e)
        {
            //bool iChecked = CkbPrintBill.Checked;
            //CkbPrintBill.Checked = !iChecked;

            if (CkbPrintBill.Checked == true)
            {
                CkbPreviewPrint.Checked = false;
            }
        }

        private void CkbPreviewPrint_CheckedChanged(object sender, EventArgs e)
        {
            //bool iChecked = CkbPreviewPrint.Checked;
            //CkbPreviewPrint.Checked = !iChecked;

            if (CkbPreviewPrint.Checked == true)
            {
                CkbPrintBill.Checked = false;
            }
        }

        /// <summary>
        /// <para>Xem nhân viên</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmnEmployees_Click(object sender, EventArgs e)
        {
            FrmEmployees frmEmployees = new FrmEmployees();
            frmEmployees.ShowDialog();
        }

        /// <summary>
        /// <para>Đóng Form</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        { 
            if (_isLogOut != false)
            {
                goto TheEnd;
            }

            if (_isRestart == true)
            {
                MsgBox.CfmInfomation(_messageClose);
                goto TheEnd;
            }    

            DialogResult showQues = MsgBox.CfmProcessing(_messageClose);
            if (showQues != DialogResult.Yes)
            {
                e.Cancel = true;
                goto TheEnd;
            }

            
        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Thêm tài khoản đăng nhập</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiAdLogin_Click(object sender, EventArgs e)
        {
            FrmLoginInfo login = new FrmLoginInfo(ModeExe.Add, null);
            DialogResult showLog = login.ShowDialog();
        }

        /// <summary>
        /// <para>Đăng xuất</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmnLogOut_Click(object sender, EventArgs e)
        {
            _messageClose = MSG_CLICK_YES_LOG_OUT;
            DialogResult showQues = MsgBox.CfmProcessing(_messageClose);
            if (showQues != DialogResult.Yes)
            {
                goto TheEnd;
            }
            _isLogOut = true;
            Application.Restart();

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Phân quyền người dùng</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiLoginRole_Click(object sender, EventArgs e)
        {
            FrmLoginRole role = new FrmLoginRole();
            role.ShowDialog();
        }

        /// <summary>
        /// <para>Xem thông tin cửa hàng</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiStore_Click(object sender, EventArgs e)
        {
            FrmStore store = new FrmStore();
            DialogResult showStore = store.ShowDialog();
        }

        /// <summary>
        /// <para>Xem báo cáo bán hàng</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiSaleReport_Click(object sender, EventArgs e)
        {
            FrmSaleReport fsale = new FrmSaleReport();
            fsale.ShowDialog();
        }

        /// <summary>
        /// <para>Xem báo cáo bằng chart</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiBills_Click(object sender, EventArgs e)
        {
            FrmSalesChart chart = new FrmSalesChart();
            chart.ShowDialog();
        }
        
        private void tsmiAuthor_Click(object sender, EventArgs e)
        {
            FrmAuthor author = new FrmAuthor();
            author.Show();
        }

        /// <summary>
        /// <para>Đóng ứng dụng</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiExit_Click(object sender, EventArgs e)
        {
            _messageClose = MSG_CLOSE_FORM;
            Application.Exit();
        }

        /// <summary>
        /// <para>Thay đổi ngôn ngữ thành tiếng Việt</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiViet_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem mnuLangVi = (ToolStripMenuItem)sender;
                string langValue = (string)mnuLangVi.Tag;
                string curentLang = LgConfig.LangName.Replace("\0","").Trim();
                if (langValue.Equals(curentLang))
                {
                    goto TheEnd;
                }

                string message = LgConfig.SetLangToIni(langValue);
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                _isRestart = true;
                _messageClose = MSG_RESET_LANG;
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Thay đổi ngôn ngữ thành tiếng Anh</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiEnglish_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem mnuLangEng = (ToolStripMenuItem)sender;
                string langValue = (string)mnuLangEng.Tag;
                string curentLang = LgConfig.LangName.Replace("\0", "").Trim();
                if (langValue.Equals(curentLang))
                {
                    goto TheEnd;
                }

                string message = LgConfig.SetLangToIni(langValue);
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                _isRestart = true;
                _messageClose = MSG_RESET_LANG;
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Cài đặt lại hiển thị của sản phẩm</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblSettingPr_Click(object sender, EventArgs e)
        {
            FrmSetting frmSetting = new FrmSetting(SHOW_SETTING_PR, 1, _fontSizePr, _buttonProdutHeight, _buttonProdutWidth);
            DialogResult diaS = frmSetting.ShowDialog();
            if (diaS != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = ReadSettingProduct();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
                goto TheEnd;
            }    

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Cài đặt lại hiển thị của Bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblSettingTable_Click(object sender, EventArgs e)
        {
            FrmSetting frmSetting = new FrmSetting(SHOW_SETTING_TB, 2, _fontSizeTb, _buttonTableHeight, _buttonTableWidth);
            DialogResult diaS = frmSetting.ShowDialog();
            if (diaS != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = ReadSettingTable();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Hiển thị toàn bộ bàn</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CkbAll_Click(object sender, EventArgs e)
        {
            try
            {
                cbbPosition.SelectedIndex = -1;
                _modeGetTable = 1;
                
                string message = ReadSettingTable();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Xem thông tin khách hàng</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiCus_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCusInfo fcus = new FrmCusInfo();
                fcus.ShowDialog();
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Mở bảng thay đổi mật khẩu</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmnChangePass_Click(object sender, EventArgs e)
        {
            FrmChangePassword fchange = new FrmChangePassword();
            DialogResult showFchange = fchange.ShowDialog();
        }

        /// <summary>
        /// <para>Backup dữ liệu</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "Coffee_backup_" + DateTime.Now.ToString("yyyyMMdd_hhmmss");
                save.Filter = "File BAK|*.bak";
                if (save.ShowDialog() != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string pathFile = save.FileName;
                int bak = DbDatabase.Backup(pathFile);
                if (bak == 0)
                {
                    MsgBox.CfmInfomation(DbDatabase.Message);
                    goto TheEnd;
                }

                MsgBox.CfmInfomation(MSG_DONE);
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Restore database</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiRestoreDb_Click(object sender, EventArgs e)
        {
            try
            {
                FrmConfirmPassword frmConfirm = new FrmConfirmPassword();
                DialogResult showConf = frmConfirm.ShowDialog();
                if (showConf != DialogResult.OK)
                {
                    goto TheEnd;
                }

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "File BAK|*.bak";

                if (openFile.ShowDialog() != DialogResult.OK)
                {
                    goto TheEnd;
                }

                int res = DbDatabase.Restore(openFile.FileName);
                if (res == 0)
                {
                    MsgBox.ErrProcess(ERROR_SHOW_ERROR);
                    goto TheEnd;
                }

                MsgBox.CfmInfomation(MSG_DONE);
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Thêm sản phẩm</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddPr_Click(object sender, EventArgs e)
        {
            DbProductOut dbProductOut = new DbProductOut();
            FrmAddProduct frmAddPr = new FrmAddProduct(ModeExe.Add, dbProductOut);
            DialogResult dialog = frmAddPr.ShowDialog();
            if (dialog != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = LoadProduct();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        public static string UserFullName
        {
            get { return _userFullName; }
            set { _userFullName = value; }
        }

        public static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
}
