using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;
using Microsoft.Win32;

namespace CoffeeManager
{
    public partial class FrmLogin : Form
    {
        private long _idEmployees = 0;
        private string _userName = "";
        private string _fullName = "";
        private long _idLogin = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                bool checkExistDb = DbDatabase.CheckDatabaseExists();
                if (checkExistDb == false)
                {
                    toolStripBtnRestore.Visible = true;
                    MsgBox.CfmInfomation(MSG_DATABASE_NOT_FOUND);
                    TsbtnExecSql.Visible = true;
                    goto TheEnd;
                } 
                
                // Đọc mã nhân viên từ Registry
                string valUserCode = Common.RegistryRead(ConstDef.KEY_USERCODE);
                if (valUserCode != string.Empty)
                {
                    TxtUsername.Text = valUserCode;
                }

                // Đọc mật khẩu từ Registry
                string valPassword = Common.RegistryRead(ConstDef.KEY_PASSWORD);
                if (valPassword != string.Empty)
                {
                    TxtPassword.Text = Common.Decrypt(SHOW_KEY_ENCRYPT, valPassword);
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

        private void TxtUsername_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text.Equals("User name"))
            {
                TxtUsername.Text = "";
            }
        }

        private void TxtPassword_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text.Equals("Password"))
            {
                TxtPassword.Text = "";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra SQL đã được cài đặt chưa
                RegistryKey RK = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\MICROSOFT\Microsoft SQL Server");
                if (RK == null)
                {
                    MsgBox.CfmInfomation(MSG_CHECK_INSTALL_SQL);
                    goto TheEnd;
                }

                // Kiểm tra đã nhập đủ dữ liệu chưa
                if (TxtUsername.Text.Equals("User name") || TxtPassword.Equals(string.Empty))
                {
                    MsgBox.CfmInfomation(ERROR_ENTER_LOGIN);
                    goto TheEnd;
                }

                string userCode = TxtUsername.Text;
                string password = Common.Encrypt(SHOW_KEY_ENCRYPT, TxtPassword.Text);
                DataTable dt = DbLogin.GetLogin(userCode, password);
                if (dt == null)
                {
                    MsgBox.ErrProcess(DbLogin.Message);
                    goto TheEnd;
                }

                if (CkbSavePassword.Checked != false)
                {
                    // Lưu Mã người dùng và mật khẩu vào Registry
                    Common.RegistryWrite(ConstDef.KEY_USERCODE, userCode);
                    Common.RegistryWrite(ConstDef.KEY_PASSWORD, password);
                }

                if (CkbRemovePassword.Checked != false)
                {
                    // Lưu Mã người dùng và mật khẩu vào Registry
                    Common.DeleteKey(ConstDef.KEY_USERCODE);
                    Common.DeleteKey(ConstDef.KEY_PASSWORD);
                }

                DataRow dr = dt.Rows[0];
                _idEmployees = (long)dr["idEmployees"];
                _userName = (string)dr["userName"];
                _idLogin = (long)dr["id"];
                DataTable dtEms = DbLogin.GetFullNameLogin(_idEmployees);

                DataRow drEms = dtEms.Rows[0];
                _fullName = (string)drEms["fullName"];

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
     
        private void TstBtnSetting_Click(object sender, EventArgs e)
        {
            FrmConnect fconn = new FrmConnect();
            fconn.ShowDialog();
        }

        private void toolStripBtnRestore_Click(object sender, EventArgs e)
        {
            try
            {
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

        CheckBox lastChecked;
        private void ChkRemovePassword_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null)
            {
                lastChecked.Checked = false;
            }

            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void CkbSavePassword_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null)
            {
                lastChecked.Checked = false;
            }

            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        public string FullName
        {
            set { _fullName = value; }
            get { return _fullName; }
        }

        public string UserName
        {
            set { _userName = value; }
            get { return _userName; }
        }

        public long GetId
        {
            set { _idEmployees = value; }
            get { return _idEmployees; }
        }

        public long GetIdLogin
        {
            set { _idLogin = value; }
            get { return _idLogin; }
        }

        private void TsbtnExecSql_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "File sql|*.sql";

                if (openFile.ShowDialog() != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string path = openFile.FileName;
                bool exec = DbDatabase.ExecScriptSql(path);
                if (exec == false)
                {
                    MsgBox.ErrProcess(DbDatabase.Message);
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
    }
}
