using System;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmGroup : Form
    {
        private ModeExe _modeExe = ModeExe.Add;
        private long _id = 0;
        private string _name = "";
        private string _description = "";
        public FrmGroup(ModeExe modExe, long id, string name, string des)
        {
            _modeExe = modExe;
            _id = id;
            _name = name;
            _description = des;

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string des = txtDescription.Text;

                switch (_modeExe)
                {
                    case ModeExe.Add:
                        int insert = DbProduct.InsertGroupProduct(name, des);
                        if (insert != 1)
                        {
                            MsgBox.ErrProcess(ERROR_ADDING_DATA + Environment.NewLine + DbProduct.Message);
                            goto TheEnd;
                        }
                        break;

                    case ModeExe.Update:
                        int update = DbProduct.UpdateGroupProduct(_id, name, des);
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
    }
}
