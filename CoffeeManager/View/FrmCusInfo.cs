using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmCusInfo : Form
    {
        private DbCustomer _dbCustomer = null;
        public FrmCusInfo()
        {
            InitializeComponent();
            _dbCustomer = new DbCustomer();
        }

        private void FrmCusInfo_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadCus();
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

        private string LoadCus()
        {
            string message = "";
            string search = txtSearch.Text.Trim();
            try
            {
                List<DbCustomerOut> dbCustomerOuts = _dbCustomer.GetAllCus(search);
                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbCustomerOuts.Count; rowIdx++)
                {
                    DbCustomerOut rowdt = dbCustomerOuts[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = rowdt;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["id"].Value = rowdt.ID;
                    row.Cells["name"].Value = rowdt.Name;
                    row.Cells["address"].Value = rowdt.Address;
                    row.Cells["phone"].Value = rowdt.PhoneNumber;
                    row.Cells["description"].Value = rowdt.Description;
                    
                    if (rowdt.Status == false)
                    {
                        row.Cells["status"].Value = SHOW_INACTIVE;
                    }      
                    else
                    {
                        row.Cells["status"].Value = SHOW_IS_ACTIVE;
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

        private void TsmiAdd_Click(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void TsmiEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                DbCustomerOut dbCustomerOut = (DbCustomerOut)dgvMain.SelectedRows[0].Tag;
                FrmCus frmCus = new FrmCus(ModeExe.Update, dbCustomerOut);
                DialogResult dia = frmCus.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadCus();
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

        private void TsmiDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                DbCustomerOut dbCustomerOut = (DbCustomerOut)dgvMain.SelectedRows[0].Tag;
                long id = dbCustomerOut.ID;
                string name = dbCustomerOut.Name;
                bool status = dbCustomerOut.Status;
                if (status != false)
                {
                    MsgBox.ErrProcess(SHOW_CANT_DEL);
                    goto TheEnd;
                }

                DialogResult ques = MsgBox.CfmProcessing(name + MSG_DEL_QUES);
                if (ques != DialogResult.Yes)
                {
                    goto TheEnd;
                }

                bool del = _dbCustomer.DelCustomer(id);
                if (del == false)
                {
                    MsgBox.ErrProcess(ERROR_WHEN_DEL + name);
                    goto TheEnd;
                }

                MsgBox.CfmInfomation(MSG_DELETED + name);

                string message = LoadCus();
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

        private void btnXProduct_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string message = LoadCus();
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
                DbCustomerOut dbCustomerOut = new DbCustomerOut();
                FrmCus frmCus = new FrmCus(ModeExe.Add, dbCustomerOut);
                DialogResult dia = frmCus.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadCus();
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
    }
}
