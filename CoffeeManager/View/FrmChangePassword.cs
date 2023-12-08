using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmChangePassword : Form
    {
        private long _idLogin = 0;

        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            TxtUserName.Text = FrmMain.UserName;
            ActiveControl = TxtPassword;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string message = CheckValid();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }

                string password = Common.Encrypt(SHOW_KEY_ENCRYPT, TxtNewPassword.Text);
                int change = DbLogin.ChangePassword(_idLogin, password);
                if (change <= 0)
                {
                    MsgBox.ErrProcess(ERROR_WHEN_UPDATING);
                    goto TheEnd;
                }

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
                if (TxtUserName.Text.Length < 1)
                {
                    message = ERROR_ENTER_USER;
                    goto TheEnd;
                }

                if (TxtPassword.Text.Length < 1)
                {
                    message = ERROR_ENTER_PASSWORD;
                    goto TheEnd;
                }

                string userCode = TxtUserName.Text;
                string password = Common.Encrypt(SHOW_KEY_ENCRYPT, TxtPassword.Text);
                DataTable dt = DbLogin.GetLogin(userCode, password);
                if (dt == null)
                {
                    message = DbLogin.Message;
                    goto TheEnd;
                }

                DataRow dr = dt.Rows[0];
                _idLogin = (long)dr["id"];

                if (TxtNewPassword.Text.Length < 1)
                {
                    message = ERROR_ENTER_NEW_PASSWORD;
                    goto TheEnd;
                }

                if (TxtConfirmPassword.Text.Length < 1)
                {
                    message = ERROR_ENTER_CF_PASSWORD;
                    goto TheEnd;
                }

                if (TxtConfirmPassword.Text != TxtNewPassword.Text)
                {
                    message = ERROR_CF_PASSWORD_NOT_MATCH;
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
    }
}
