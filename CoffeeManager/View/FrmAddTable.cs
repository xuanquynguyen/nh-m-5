using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmAddTable : Form
    {
        private ModeExe _modeExe = ModeExe.Add;
        private long _id = 0;
        private string _name = "";
        private long _idGr = 0;
        private string _description = "";

        private DbTable _dbTable = new DbTable();
        public FrmAddTable(ModeExe modeExe, long id, string name, long idgr, string des)
        {
            _modeExe = modeExe;
            _id = id;
            _idGr = idgr;
            _name = name;
            _description = des;
            _dbTable = new DbTable();
            InitializeComponent();
        }

        private void FrmAddTable_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadGroupTb();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                if (_modeExe == ModeExe.Update)
                {
                    txtName.Text = _name;
                    txtDescription.Text = _description;
                    cbbGroup.SelectedValue = _idGr;
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
        /// <para>Load nhóm sản phẩm</para>
        /// </summary>
        /// <returns></returns>
        private string LoadGroupTb()
        {
            string message = "";

            try
            {
                DataTable dt = _dbTable.GetAllGroupTable();
                if (dt == null)
                {
                    message = ERROR_LOADING_AREA;
                }

                cbbGroup.DataSource = dt;
                cbbGroup.ValueMember = "id";
                cbbGroup.DisplayMember = "name";
                cbbGroup.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }

        private string CheckValid(string name, long pos)
        {
            string message = "";

            try
            {
                if (name.Equals(string.Empty))
                {
                    message = MSG_ENTER_TABLE;
                    goto TheEnd;
                }    

                if (pos.Equals(string.Empty))
                {
                    message = MSG_CHOOSE_AREA;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string des = txtDescription.Text;
                long idGr = (long)cbbGroup.SelectedValue;

                string message = CheckValid(name, idGr);
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                DataTable dt;
                switch (_modeExe)
                {
                    case ModeExe.Add:
                        dt = _dbTable.CheckExistNameTable(name, idGr);
                        if (dt == null)
                        {
                            MsgBox.ErrProcess(_dbTable.Message);
                            goto TheEnd;
                        }

                        if (dt.Rows.Count > 0)
                        {
                            MsgBox.ErrProcess(_dbTable.Message);
                            goto TheEnd;
                        }    

                        int insert = _dbTable.InsertTb(name, des, idGr);
                        if (insert != 1)
                        {
                            MsgBox.ErrProcess(ERROR_ADDING_DATA);
                            goto TheEnd;
                        }    
                        break;

                    case ModeExe.Update:
                        dt = _dbTable.CheckExistNameTable(name, _id, idGr);
                        if (dt == null)
                        {
                            MsgBox.ErrProcess(_dbTable.Message);
                            goto TheEnd;
                        }

                        if (dt.Rows.Count > 0)
                        {
                            MsgBox.ErrProcess(_dbTable.Message);
                            goto TheEnd;
                        }
                        int update = _dbTable.UpdateTable(name, des, idGr, _id);
                        if (update != 1)
                        {
                            MsgBox.ErrProcess(ERROR_WHEN_UPDATING);
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

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FrmGroupTb frmAdd = new FrmGroupTb(ModeExe.Add, 0, "", "");
            DialogResult dialog = frmAdd.ShowDialog();
            if (dialog != DialogResult.OK)
            {
                goto TheEnd;
            }

            long idgr = frmAdd.IdGroupShare;

            string message = LoadGroupTb();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
                goto TheEnd;
            }

            cbbGroup.SelectedValue = idgr;

        TheEnd:
            return;
        }
    }
}
