using System;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmCus : Form
    {
        private ModeExe _modeExe = ModeExe.Add;
        private long _id = 0;
        private string _name = "";
        private string _address = "";
        private string _phone = "";
        private string _description = "";
        private bool _status = false;
        public FrmCus(ModeExe modExe,DbCustomerOut dbCustomerOut)
        {
            _modeExe = modExe;
            _id = dbCustomerOut.ID;
            _name = dbCustomerOut.Name;
            _address = dbCustomerOut.Address;
            _phone = dbCustomerOut.PhoneNumber;
            _description = dbCustomerOut.Description;
            _status = dbCustomerOut.Status;
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void FrmGroup_Load(object sender, EventArgs e)
        {
            try
            {
                if (_modeExe == ModeExe.Update)
                {
                    txtName.Text = _name;
                    txtAddress.Text = _address;
                    txtPhone.Text = _phone;
                    txtDescription.Text = _description;
                }

                ActiveControl = txtName;
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string message = CheckValidData();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                DbCustomer dbCustomer = new DbCustomer();
                DbCustomerIn dbCustomerIn = new DbCustomerIn();

                dbCustomerIn.ID = _id;
                dbCustomerIn.Name = txtName.Text;
                dbCustomerIn.Address = txtAddress.Text;
                dbCustomerIn.PhoneNumber = txtPhone.Text;
                dbCustomerIn.Description = txtDescription.Text;
                dbCustomerIn.Status = _status;

                switch (_modeExe)
                {
                    case ModeExe.Add:
                        int insert = dbCustomer.UpdatetCus(ModeExe.Add, dbCustomerIn);
                        if (insert != 1)
                        {
                            MsgBox.ErrProcess(ERROR_ADDING_DATA + Environment.NewLine + DbProduct.Message);
                            goto TheEnd;
                        }
                        break;

                    case ModeExe.Update:
                        //int update = dbCustomer.UpdateStatusCustomer(_id);
                        int update = dbCustomer.UpdatetCus(ModeExe.Update, dbCustomerIn);
                        if (update != 1)
                        {
                            MsgBox.ErrProcess(ERROR_WHEN_UPDATING + Environment.NewLine + DbProduct.Message);
                            goto TheEnd;
                        }
                        break;

                    default:
                        break;
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

        private string CheckValidData()
        {
            string message = "";

            try
            {
                if (txtName.Text.Equals(string.Empty) && 
                    txtAddress.Text.Equals(string.Empty) && 
                    txtPhone.Text.Equals(string.Empty))
                {
                    message = ERROR_ENTER_ONE_INFO;
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isControl = char.IsControl(e.KeyChar);
            bool isDigit = char.IsDigit(e.KeyChar);
            if ((isControl == false) && (isDigit == false))
            {
                e.Handled = true;
                MessageBox.Show(MSG_PRESS_NUMBER);
            }

        }
    }
}
