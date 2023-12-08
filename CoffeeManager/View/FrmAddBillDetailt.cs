using System;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmAddBillDetailt : Form
    {
        private long _idProduct = 0;
        private string _nameProduct = "";
        private double _unitPrice = 0;
        private long _idTable = 0;
        private long _idBill = 0;
        private string _description = "";
        private ModeExe _modeExe = ModeExe.Add;
        private long _idUser = 0;
        private long _idCustomer;

        private DbBill _dbBill = null;
        private DbTable _dbTable = null;

        public FrmAddBillDetailt(ModeExe modeExe, long idTable, long idProduct, string nameProduct, double unitPrice, long idBill, string description, long idUser, long idCustomer)
        {
            _idProduct = idProduct;
            _nameProduct = nameProduct;
            _unitPrice = unitPrice;
            _idTable = idTable;
            _idBill = idBill;
            _modeExe = modeExe;
            _description = description;
            _idUser = idUser;
            _idCustomer = idCustomer;

            InitializeComponent();
            _dbBill = new DbBill();
            _dbTable = new DbTable();
        }

        private void FrmAddBillDetailt_Load(object sender, EventArgs e)
        {
            try
            {
                Name = SHOW_NAME_ADD_BILLDT;
                lblNameProduct.Text = _nameProduct;
                lblUnitPrice.Text = _unitPrice.ToString();
                txtDescription.Text = _description;
                if (_modeExe == ModeExe.Update)
                {
                    nudNumberProduct.Value = _idProduct;
                }                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CheckValidData()
        {
            string message = "";

            try
            {
                if (lblNameProduct.Text.Equals("name"))
                {
                    message = ERROR_PRODUCT_NAME_EMPTY;
                    goto TheEnd;
                }

                if (lblUnitPrice.Text.Equals("unit price"))
                {
                    message = ERROR_PRODUCT_PRICE_EMPTY;
                    goto TheEnd;
                }

                if (nudNumberProduct.Value.Equals(0))
                {
                    message = ERROR_PRODUCT_QUANTITY_EMPTY;
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

        private string CalculatorBill()
        {
            string message = "";

            try
            {
                message = CheckValidData();
                if (message.Length > 0)
                {
                    goto TheEnd;
                }    

                DateTime dateIn = DateTime.Now;
                int numberProduct = (int)nudNumberProduct.Value;

                double totalMoney = _unitPrice * numberProduct;
                bool status = false;
                string description = txtDescription.Text;

                // Nếu tiếp tục với hóa đơn cũ thì không thêm mới hóa đơn
                if (_idBill != 0)
                {
                    goto Second;
                }

                DbBillIn dbBillIn = new DbBillIn();
                dbBillIn.IdTable = _idTable;
                dbBillIn.Date = dateIn;
                dbBillIn.TotalMoney = totalMoney;
                dbBillIn.Status = status;
                dbBillIn.Description = "";
                dbBillIn.IdUser = _idUser;
                dbBillIn.IdCustomer = _idCustomer;
                                             
                _idBill = _dbBill.SaveBill(dbBillIn);
                if (_idBill == 0)
                {
                    MessageBox.Show(ERROR_ADD_BILL);
                    goto TheEnd;
                }

                if (_idTable != 0)
                {
                    int update = _dbTable.UpdateStatusTable(_idTable);
                    if (update != 1)
                    {
                        MessageBox.Show(ERROR_UPDATE_TB_STATUS);
                        goto TheEnd;
                    }
                }
                else
                {
                    DbCustomer dbCustomer = new DbCustomer();
                    int update = dbCustomer.UpdateStatusCustomer2(_idCustomer);
                    if (update != 1)
                    {
                        MessageBox.Show(ERROR_UPDATE_CUS_STATUS);
                        goto TheEnd;
                    }
                }    

                Second:

                DbBillDetailtIn dbBillDetailtIn = new DbBillDetailtIn();
                dbBillDetailtIn.UnitPrice = _unitPrice;
                dbBillDetailtIn.Quantity = numberProduct;
                dbBillDetailtIn.IdBill = _idBill;
                dbBillDetailtIn.IdProduct = _idProduct;
                dbBillDetailtIn.IntoMoney = totalMoney;
                dbBillDetailtIn.Description = description;
   
                long idInSertBill = _dbBill.SaveBillDetailt(dbBillDetailtIn);
                if (idInSertBill == 0)
                {
                    message = ERROR_ADD_BILLDT;
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

        private string CalculatorNumber(Button btn)
        {
            string message = "";

            try
            {
                int nowNumber = (int)nudNumberProduct.Value;
                switch (btn.Text)
                {
                    case "-":
                        nudNumberProduct.Value = nowNumber == 0 ? 0 : nowNumber -= 1;
                        break;

                    case "+":
                        nudNumberProduct.Value += 1;
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

        private void btnLess_Click(object sender, EventArgs e)
        {
            try
            {
                CalculatorNumber(btnLess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            try
            {
                CalculatorNumber(btnMore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                int number = (int)nudNumberProduct.Value;
                string des = txtDescription.Text;
                if (_modeExe == ModeExe.Update)
                {
                    int update = _dbBill.UpdateNumberBillDetailt(number,des,  _idBill);
                    if (update != 1)
                    {
                        MessageBox.Show(ERROR_WHEN_UPDATING);
                        goto TheEnd;
                    }   
                    
                    goto Second;
                }

                string message = CalculatorBill();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

            Second:
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        public long SendIdBill 
        {
            get { return _idBill; }
            set { _idBill = value; }
        }
    }
}
