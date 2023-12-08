using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmAddProduct : Form
    {
        private int _imgHeight = 0;
        private int _imgWidth = 0;
        private long _idProduct = 0;
        private ModeExe _modeExe = ModeExe.Add;

        private long _idGroup = 0;
        private string _name = "";
        private string _unit = "";
        private double _unitPrice = 0;
        private string _description = "";
        private byte[] _img = null;

        public FrmAddProduct(ModeExe modeExe, DbProductOut dbPrOut)
        {
            _modeExe = modeExe;
            _idProduct = dbPrOut.Id;
            _idGroup = dbPrOut.IdGroup;
            _name = dbPrOut.Name;
            _unit = dbPrOut.Unit;
            _unitPrice = dbPrOut.UnitPrice;
            _description = dbPrOut.Description;
            _img = dbPrOut.Img;

            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string message = CheckValidData();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                message = InsertProductToDb();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

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

        private string CheckValidData()
        {
            string message = "";
            try
            {
                if (txtName.Text.Equals(string.Empty))
                {
                    message = ERROR_PRODUCT_NAME_EMPTY;
                    goto TheEnd;
                }

                if (txtUnit.Text.Equals(string.Empty))
                {
                    message = ERROR_ENTER_UNIT;
                    goto TheEnd;
                }

                if (txtUnitPrice.Text.Equals(string.Empty))
                {
                    message = ERROR_ENTER_UNIT_PRICE;
                    goto TheEnd;
                }

                if (_imgHeight > 64 || _imgWidth > 64)
                {
                    message = ERROR_OUT_SIZE_IMAGE + _imgWidth + "x" + _imgHeight;
                    goto TheEnd;
                }

                if (_modeExe == ModeExe.Add)
                {
                    string nameCheck = DbProduct.CheckDoubleName(txtName.Text.Trim());
                    if (nameCheck.Length > 0)
                    {
                        message = ERROR_EXISTS_NAME;
                        goto TheEnd;
                    }                 
                }    

                if (_modeExe == ModeExe.Update)
                {
                    string nameCheck = DbProduct.CheckDoubleNameByID(txtName.Text.Trim(), _idProduct);
                    if (nameCheck.Length > 0)
                    {
                        message = ERROR_EXISTS_NAME;
                        goto TheEnd;
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

        private string InsertProductToDb()
        {
            string message = "";
            try
            {
                long id = _idProduct;
                long idgr = (long)cbbGroup.SelectedValue;
                string name = txtName.Text;
                string unit = txtUnit.Text;
                string unitPrice = txtUnitPrice.Text;
                string description = txtDescription.Text;
                string filePath = System.Reflection.Assembly.GetExecutingAssembly()
                   .Location + @"\..\..\..\Resources\nonimg.png";
                byte[] img = File.ReadAllBytes(filePath);
                if (_img != null)
                {
                    img = _img;
                }

                DbProductIn dbIn = new DbProductIn
                {
                    Id = _idProduct,
                    IdGroup = idgr,
                    Name = name,
                    Unit = unit,
                    UnitPrice = unitPrice,
                    Description = description,
                    Img = img
                };

                switch (_modeExe)
                {
                    case ModeExe.Add:
                        int insert = DbProduct.InsertProduct(dbIn);
                        if (insert != 1)
                        {
                            message = ERROR_ADDING_DATA;
                        }
                        break;

                    case ModeExe.Update:
                        int update = DbProduct.UpdateProduct(dbIn);
                        if (update != 1)
                        {
                            message = ERROR_EDITING_DATA;
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

        private Image ByteToImage(byte[] byteIn)
        {
            MemoryStream ms = new MemoryStream(byteIn);
            Image rt = Image.FromStream(ms);
            return rt;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png"
            };

            if (open.ShowDialog() != DialogResult.OK)
            {
                goto TheEnd;
            }
            Bitmap imgBitmap = new Bitmap(open.FileName);
            ptbImg.Image = imgBitmap;
            ptbImg.Tag = open.FileName;
            _imgHeight = imgBitmap.Height;
            _imgWidth = imgBitmap.Width;
            _img = File.ReadAllBytes(open.FileName);
        TheEnd:
            return;
        }       

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadGroup();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                } 
                
                if (_modeExe == ModeExe.Update)
                {
                    txtName.Text = _name;
                    txtUnit.Text = _unit;
                    cbbGroup.SelectedValue = _idGroup;
                    txtUnitPrice.Text = _unitPrice.ToString();
                    txtDescription.Text = _description;
                    ptbImg.Image = ByteToImage(_img);
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

        private string LoadGroup()
        {
            string message = "";
            try
            {
                DataTable dt = DbProduct.GetAllGroupProduct();
                if (dt == null)
                {
                    message = ERROR_LOAD_GROUP;
                    goto TheEnd;
                }    

                cbbGroup.DataSource = dt;
                cbbGroup.DisplayMember = "nameGr";
                cbbGroup.ValueMember = "idGr";
                cbbGroup.SelectedIndex = -1;
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
            DialogResult = DialogResult.Abort;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGroup frmGr = new FrmGroup(ModeExe.Add, 0, "", "");
                DialogResult dia = frmGr.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadGroup();
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

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
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
