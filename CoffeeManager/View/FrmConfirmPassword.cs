using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmConfirmPassword : Form
    {
        public FrmConfirmPassword()
        {
            InitializeComponent();
        }

        private void FrmConfirmPassword_Load(object sender, EventArgs e)
        {
            lblAccount.Text = FrmMain.UserName; 
        }

        private void LblAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string password = Common.Encrypt(SHOW_KEY_ENCRYPT, TxtPassword.Text);
                DataTable dt = DbLogin.GetLogin(lblAccount.Text, password);
                if (dt == null)
                {
                    MsgBox.ErrProcess(DbLogin.Message);
                    goto TheEnd;
                }

                if (dt.Rows.Count < 1)
                {
                    MsgBox.CfmInfomation(MSG_WRONG_PASSWORD);
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

        private void LblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
