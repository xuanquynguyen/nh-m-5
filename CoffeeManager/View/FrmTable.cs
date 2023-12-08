using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmTable : Form
    {
        private DbTable _dbTable = null;
        public FrmTable()
        {
            InitializeComponent();
            _dbTable = new DbTable();
            SetToolTip();
        }

        private void SetToolTip()
        {
            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                //toolTip.InitialDelay = 1000;
                //toolTip.ReshowDelay = 500;
                ShowAlways = true
            };
            toolTip.SetToolTip(btnHelp, SHOW_TOOLTIP_HELP);
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadGroup();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }    
                
                message = LoadDataTable();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

                dgvMain.RowsDefaultCellStyle.BackColor = Color.Bisque;
                dgvMain.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.Beige;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private string LoadDtSearch()
        {
            string message = "";
            try
            {
                string search = txtSearch.Text;
                dgvMain.Rows.Clear();
                DataTable dt = _dbTable.SearchTbTable(search);
                for (int rowIdx = 0; rowIdx < dt.Rows.Count; rowIdx++)
                {
                    DataRow dr = dt.Rows[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = dr;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["idTb"].Value = dr["idTb"];
                    row.Cells["idgr"].Value = dr["idgr"];
                    row.Cells["nameTb"].Value = dr["nameTb"];
                    row.Cells["descriptionTb"].Value = dr["descriptionTb"];
                    row.Cells["nameGr"].Value = dr["nameGr"];
                    bool status = (bool)dr["status"];
                    if (status == false)
                    {
                        row.Cells["status"].Value = SHOW_NO_GUEST_YET;
                    }
                    else
                    {
                        row.Cells["status"].Value = SHOW_HAVE_GUEST;
                        dgvMain.Rows[rowIdx].Cells["status"].Style.ForeColor = Color.Red;
                    }
                }

                dgvMain.ClearSelection();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
        TheEnd:
            return message;
        }

        private string LoadDataTable()
        {
            string message = "";
            try
            {
                dgvMain.Rows.Clear();
                DataTable dt = _dbTable.GetAllTableNew();
                for (int rowIdx = 0; rowIdx < dt.Rows.Count; rowIdx++)
                {
                    DataRow dr = dt.Rows[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = dr;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["idTb"].Value = dr["idTb"];
                    row.Cells["idgr"].Value = dr["idgr"];
                    row.Cells["nameTb"].Value = dr["nameTb"];
                    row.Cells["descriptionTb"].Value = dr["descriptionTb"];
                    row.Cells["nameGr"].Value = dr["nameGr"];
                    bool status = (bool)dr["status"];
                    if (status == false)
                    {
                        row.Cells["status"].Value = SHOW_TABLE_EMPTY;
                    }   
                    else
                    {
                        row.Cells["status"].Value = SHOW_HAVE_GUEST;
                        dgvMain.Rows[rowIdx].Cells["status"].Style.ForeColor = Color.Red;
                    }    
                }

                dgvMain.ClearSelection();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
        TheEnd:
            return message;
        }

        private void DgvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count != 1)
                {
                    goto TheEnd;
                }

            }
            catch (Exception)
            {
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void TsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count <= 0)
            {
                MsgBox.CfmInfomation(SHOW_SELECT_FOR_EDIT);
                goto TheEnd;
            }
            long idGr = (long)dgvGroup.SelectedRows[0].Cells["id"].Value;
            string name = (string)dgvGroup.SelectedRows[0].Cells["name"].Value;
            string des = dgvGroup.SelectedRows[0].Cells["description"].Value 
                == null ? SHOW_NONE : dgvGroup.SelectedRows[0].Cells["description"].Value.ToString();
            FrmGroupTb frmAdd = new FrmGroupTb(ModeExe.Update, idGr, name, des);
            DialogResult dialog = frmAdd.ShowDialog();
            if (dialog != DialogResult.OK)
            {
                goto TheEnd;
            }

            string message = LoadGroup();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void TsmiDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGroup.SelectedRows.Count <= 0)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                long idGr = (long)dgvGroup.SelectedRows[0].Cells["id"].Value;
                string name = (string)dgvGroup.SelectedRows[0].Cells["name"].Value;
                DialogResult ask = MsgBox.CfmProcessing(name + MSG_DEL_QUES);
                if (ask != DialogResult.Yes)
                {
                    goto TheEnd;
                }    

                _dbTable.DelGrTable(idGr);

                MsgBox.CfmInfomation(MSG_DONE);

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

        private void TsmiEditTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_EDIT);
                    goto TheEnd;
                }

                DataRow dr = (DataRow)dgvMain.SelectedRows[0].Tag;

                long idTb = (long)dr["idTb"];
                long idGr = (long)dr["idgr"];
                
                string name = (string)dr["nameTb"];
                string des = (string)dr["descriptionTb"] == null?SHOW_NONE: (string)dr["descriptionTb"];

                FrmAddTable frmAdd = new FrmAddTable(ModeExe.Update, idTb, name, idGr, des);
                DialogResult dia = frmAdd.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadDataTable();
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

        private void TsmiDelTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                long id = (long)dgvMain.SelectedRows[0].Cells["idTb"].Value;
                string name = (string)dgvMain.SelectedRows[0].Cells["nameTb"].Value;
                string status = (string)dgvMain.SelectedRows[0].Cells["status"].Value;
                if (status.Equals(SHOW_HAVE_GUEST))
                {
                    MsgBox.ErrProcess(SHOW_CANT_DEL);
                    goto TheEnd;
                }    

                DialogResult ques = MsgBox.CfmProcessing(name + MSG_DEL_QUES);
                if (ques != DialogResult.Yes)
                {
                    goto TheEnd;
                }

                bool del = _dbTable.DelTable(id);
                if (del != true)
                {
                    MsgBox.ErrProcess(ERROR_WHEN_DEL + name + Environment.NewLine + _dbTable.Message);
                    goto TheEnd;
                }

                MsgBox.CfmInfomation(MSG_DELETED + name);

                string message = LoadDataTable();
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

        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGroupTb frmAdd = new FrmGroupTb(ModeExe.Add, 0,  "", "");
                DialogResult dialog = frmAdd.ShowDialog();
                if (dialog != DialogResult.OK)
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
                DataTable dt = _dbTable.GetAllGroupTable();
                if (dt == null)
                {
                    message = ERROR_LOAD_GROUP;
                    goto TheEnd;
                }

                dgvGroup.DataSource = dt;
                dgvGroup.ClearSelection();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private string LoadGroupSearch()
        {
            string message = "";
            try
            {
                string search = txtSearchGroup.Text;
                DataTable dt = _dbTable.SearchGroupTb(search);
                if (dt == null)
                {
                    message = ERROR_LOAD_GROUP;
                    goto TheEnd;
                }

                dgvGroup.DataSource = dt;
                dgvGroup.ClearSelection();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private void BtnAddPr_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAddTable frmAdd = new FrmAddTable(ModeExe.Add, 0, "", 0, "");
                DialogResult dialog = frmAdd.ShowDialog();
                if (dialog != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadDataTable();
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

        private void TxtSearchGroup_TextChanged(object sender, EventArgs e)
        {
            string message;
            if (txtSearchGroup.Text.Equals(string.Empty))
            {

                message = LoadGroup();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
            }

            message = LoadGroupSearch();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string message;
            if (txtSearch.Text.Equals(string.Empty))
            {
                message = LoadDataTable();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
            }

            message = LoadDtSearch();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            txtSearchGroup.Text = "";
        }

        private void BtnXProduct_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}
