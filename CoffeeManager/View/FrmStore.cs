using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmStore : Form
    {
        public FrmStore()
        {
            InitializeComponent();
        }

        private void FrmStore_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadStoreInfo();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
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

        private string LoadStoreInfo()
        {
            string message = "";
            try
            {
                DataTable dt = DbStore.GetInfoStore();
                if (dt == null)
                {
                    message = DbStore.Message;
                    goto TheEnd;
                }    

                DataRow dr = dt.Rows[0];
                lblName.Tag = (long)dr["id"];
                txtName.Text = (string)dr["nameStore"];
                txtAddress.Text = (string)dr["addressStore"];
                txtPhone.Text = (string)dr["phoneStore"];
                txtTaxCode.Text = (string)dr["taxCode"];
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
        TheEnd:
            return message;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MsgBox.CfmInfomation(ERROR_PRODUCT_NAME_EMPTY);
                    goto TheEnd;
                }

                DbStoreOut dbStoreOut = new DbStoreOut();
                dbStoreOut.Id = long.Parse(lblName.Tag.ToString());
                dbStoreOut.NameStore = txtName.Text;
                dbStoreOut.AddressStore = txtAddress.Text;
                dbStoreOut.PhoneStore = txtPhone.Text;
                dbStoreOut.TaxCode = txtTaxCode.Text;

                int Update = DbStore.UpdateStore(dbStoreOut);
                if (Update < 1)
                {
                    MsgBox.ErrProcess(DbStore.Message);
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
    }
}
