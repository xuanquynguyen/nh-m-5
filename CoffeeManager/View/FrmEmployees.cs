using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmEmployees : Form
    {
        private string _nameRadioButton = "";
        private int _modeSearch = 0;
        private bool _status = false;
        public FrmEmployees()
        {
            InitializeComponent();
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadEmployees();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                dgvMain.RowsDefaultCellStyle.BackColor = Color.Bisque;
                dgvMain.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.Beige;
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private string LoadEmployees()
        {
            string message = "";
            try
            {
                // Lấy tên radiobuton đang chọn
                foreach (RadioButton c in PnlTop.Controls)
                {
                    if (c.Checked != false)
                    {
                        _nameRadioButton = c.Name;
                        break;
                    }
                }

                List<DbEmployeesOut> dbEmOuts = DbEmployees.GetAllEm(_modeSearch, _status);                
                if (dbEmOuts == null)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }

                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbEmOuts.Count; rowIdx++)
                {
                    DbEmployeesOut rowdt = dbEmOuts[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = rowdt;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["id"].Value = rowdt.Id;
                    row.Cells["fullName"].Value = rowdt.FullName;
                    row.Cells["phoneNumber"].Value = rowdt.PhoneNumber;
                    row.Cells["address"].Value = rowdt.Address;
                    row.Cells["idCard"].Value = rowdt.IdCard;
                    row.Cells["dateWork"].Value = rowdt.DateWork;                  
                    row.Cells["img"].Value = rowdt.Img == null ? null : rowdt.Img;

                    string statusView = SHOW_IS_ACTIVE;
                    bool status = rowdt.Status;

                    if (status == false)
                    {
                        statusView = SHOW_INACTIVE;
                        row.Cells["status"].Style.ForeColor = Color.Red;
                    }    
                    row.Cells["status"].Value = statusView;
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

        private void RdbAll_CheckedChanged(object sender, EventArgs e)
        {
            _modeSearch = 0;
            if (_nameRadioButton.Equals("RdbOn"))
            {
                _modeSearch = 1;
                _status = true;
            }

            if (_nameRadioButton.Equals("RdbOff"))
            {
                _modeSearch = 2;
                _status = false;
            }

            string message = LoadEmployees();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private string SearchEmployees()
        {
            string message = "";
            try
            {
                string keyWord = txtSearch.Text;
                List<DbEmployeesOut> dbEmOuts = DbEmployees.SearchEmployees(_modeSearch, _status, keyWord);
                if (dbEmOuts == null)
                {
                    message = DbEmployees.Message;
                    goto TheEnd;
                }  

                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbEmOuts.Count; rowIdx++)
                {
                    DbEmployeesOut rowdt = dbEmOuts[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = rowdt;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["id"].Value = rowdt.Id;
                    row.Cells["fullName"].Value = rowdt.FullName;
                    row.Cells["phoneNumber"].Value = rowdt.PhoneNumber;
                    row.Cells["address"].Value = rowdt.Address;
                    row.Cells["idCard"].Value = rowdt.IdCard;
                    row.Cells["dateWork"].Value = rowdt.DateWork;
                    row.Cells["img"].Value = rowdt.Img == null ? null : rowdt.Img;

                    string statusView = SHOW_IS_ACTIVE;
                    bool status = rowdt.Status;

                    if (status == false)
                    {
                        statusView = SHOW_INACTIVE;
                        row.Cells["status"].Style.ForeColor = Color.Red;
                    }
                    row.Cells["status"].Value = statusView;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string message = SearchEmployees();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAddOrEditEmployees frmEm = new FrmAddOrEditEmployees(ModeExe.Add, true, null);
                DialogResult dia = frmEm.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                RdbAll.Checked = true;

                string message = LoadEmployees();
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

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count != 1)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_EDIT);
                    goto TheEnd;
                }   
                
                DbEmployeesOut dbEmIn = (DbEmployeesOut)dgvMain.SelectedRows[0].Tag;
                FrmAddOrEditEmployees frmEm = new FrmAddOrEditEmployees(ModeExe.Update, true, dbEmIn);
                DialogResult dia = frmEm.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                RdbAll.Checked = true;

                string message = LoadEmployees();
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

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count != 1)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                DbEmployeesOut dbEmIn = (DbEmployeesOut)dgvMain.SelectedRows[0].Tag;

                DataTable dt = DbEmployees.CheckUserOfEmployeesId(dbEmIn.Id);
                if (dt == null)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }    

                if (dt.Rows.Count > 0)
                {
                    MsgBox.ErrProcess(MSG_DELETE_LOGIN_FIRST);
                    goto TheEnd;
                }    

                DialogResult quest = MsgBox.CfmProcessing(dbEmIn.FullName + MSG_WILL_DELETE);
                if (quest != DialogResult.Yes)
                {
                    goto TheEnd;
                }

                int del = DbEmployees.DeleteEms(dbEmIn.Id);
                if (del < 1)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }   
                
                RdbAll.Checked = true;

                string message = LoadEmployees();
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

        private void TsmiAdd_Click(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void TsmiView_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count != 1)
            {
                goto TheEnd;
            }

            DbEmployeesOut dbEmIn = (DbEmployeesOut)dgvMain.SelectedRows[0].Tag;
            FrmAddOrEditEmployees frmEm = new FrmAddOrEditEmployees(ModeExe.View, false, dbEmIn);
            DialogResult dia = frmEm.ShowDialog();

        TheEnd:
            return;
        }

        private void btnXProduct_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
    }  

}



