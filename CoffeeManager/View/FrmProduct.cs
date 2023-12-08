using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmProduct : Form
    {
        private long _idProduct = 0;

        public FrmProduct()
        {
            InitializeComponent();
            SetToolTip();
        }

        private void SetToolTip()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            //toolTip.InitialDelay = 1000;
            //toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
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
                
                message = LoadProduct();
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

        private string LoadProduct()
        {
            string message = "";
            try
            {
                List<DbProductOut> dbProductOuts = DbProduct.GetAllProduct();
                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbProductOuts.Count; rowIdx++)
                {
                    DbProductOut rowdt = dbProductOuts[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = rowdt;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["id"].Value = rowdt.Id;
                    row.Cells["idGroupProduct"].Value = rowdt.IdGroup;
                    row.Cells["name"].Value = rowdt.Name;
                    row.Cells["unit"].Value = rowdt.Unit;
                    row.Cells["unitPrice"].Value = rowdt.UnitPrice;
                    row.Cells["description"].Value = rowdt.Description;
                    row.Cells["img"].Value = rowdt.Img == null ? null : rowdt.Img;
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

        private string LoadProductSearch()
        {
            string message = "";
            try
            {
                string search = txtSearch.Text;
                List<DbProductOut> dbProductOuts = DbProduct.GetAllProductSearch(search);
                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbProductOuts.Count; rowIdx++)
                {
                    DbProductOut rowdt = dbProductOuts[rowIdx];
                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = rowdt;

                    DataGridViewRow row = dgvMain.Rows[rowIdx];
                    row.Cells["id"].Value = rowdt.Id;
                    row.Cells["idGroupProduct"].Value = rowdt.IdGroup;
                    row.Cells["name"].Value = rowdt.Name;
                    row.Cells["unit"].Value = rowdt.Unit;
                    row.Cells["unitPrice"].Value = rowdt.UnitPrice;
                    row.Cells["description"].Value = rowdt.Description;
                    row.Cells["img"].Value = rowdt.Img == null ? null : rowdt.Img;
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

        private Image ByteToImage(byte[] byteIn)
        {
            MemoryStream ms = new MemoryStream(byteIn);
            Image rt = Image.FromStream(ms);
            return rt;
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count != 1)
                {
                    goto TheEnd;
                }

                DbProductOut dbproductOut = new DbProductOut();
                dbproductOut = (DbProductOut)dgvMain.SelectedRows[0].Tag;
                if (dbproductOut == null)
                {
                    goto TheEnd;
                }

                _idProduct = dbproductOut.Id;
                //txtName.Text = dbproductOut.Name;
                //txtUnit.Text = dbproductOut.Unit;
                //txtUnitPrice.Text = dbproductOut.UnitPrice.ToString();
                //txtDescription.Text = dbproductOut.Description;
                //Image imgView = ByteToImage(dbproductOut.Img) == null ? null : ByteToImage(dbproductOut.Img);
                //ptbImg.Image = imgView;

                //txtDescription.Text = dbHandleMsgInfo.Description == null ? NULL_VALUE
                //    : dbHandleMsgInfo.Description;
                //lblSendTo.Text = _dbRoomOut.RoomName;
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return;
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count <= 0)
            {
                MsgBox.CfmInfomation(SHOW_SELECT_FOR_EDIT);
                goto TheEnd;
            }
            long idGr = (long)dgvGroup.SelectedRows[0].Cells["idGr"].Value;
            string name = (string)dgvGroup.SelectedRows[0].Cells["nameGr"].Value;
            string des = dgvGroup.SelectedRows[0].Cells["descriptionGr"].Value 
                == null ? "": dgvGroup.SelectedRows[0].Cells["descriptionGr"].Value.ToString();
            
            FrmGroup frmAdd = new FrmGroup(ModeExe.Update, idGr, name, des);
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

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dgvGroup.SelectedRows.Count <= 0) || (dgvGroup.SelectedRows.Count > 1))
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                long idGr = (long)dgvGroup.SelectedRows[0].Cells["idGr"].Value;
                string name = (string)dgvGroup.SelectedRows[0].Cells["nameGr"].Value;
                DialogResult ask = MsgBox.CfmProcessing(name + MSG_WILL_DELETE);
                if (ask != DialogResult.Yes)
                {
                    goto TheEnd;
                }    

                int del = DbProduct.DelGroupProduct(idGr);
                if  (del != 1)
                {
                    MsgBox.ErrProcess(ERROR_WHEN_DEL + name + Environment.NewLine + DbProduct.Message);
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

        private void tsmiEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dgvMain.SelectedRows.Count <= 0) || (dgvMain.SelectedRows.Count >1))
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_EDIT);
                    goto TheEnd;
                }

                DbProductOut dbproductOut = (DbProductOut)dgvMain.SelectedRows[0].Tag;
                FrmAddProduct frmAdd = new FrmAddProduct(ModeExe.Update, dbproductOut);
                DialogResult dia = frmAdd.ShowDialog();
                if (dia != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadProduct();
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

        private void tsmiDelProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count <= 0)
                {
                    MsgBox.CfmInfomation(SHOW_SELECT_FOR_DEL);
                    goto TheEnd;
                }

                DbProductOut dbProductOut = (DbProductOut)dgvMain.SelectedRows[0].Tag;
                long id = dbProductOut.Id;
                string name = dbProductOut.Name;
                DialogResult ques = MsgBox.CfmProcessing(name + MSG_WILL_DELETE);
                if (ques != DialogResult.Yes)
                {
                    goto TheEnd;
                }

                int del = DbProduct.DelProduct(id);
                if (del != 1)
                {
                    MsgBox.ErrProcess(ERROR_WHEN_DEL + name);
                    goto TheEnd;
                }

                MsgBox.CfmInfomation(MSG_DELETED + name);

                string message = LoadProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }

            TheEnd:
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGroup frmAdd = new FrmGroup(ModeExe.Add, 0,  "", "");
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
                DataTable dt = DbProduct.GetAllGroupProduct();
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
                DataTable dt = DbProduct.GetAllGroupProductSearch(search);
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

        private void btnAddPr_Click(object sender, EventArgs e)
        {
            try
            {
                DbProductOut dbProductOut = new DbProductOut();
                FrmAddProduct frmAdd = new FrmAddProduct(ModeExe.Add, dbProductOut);
                DialogResult dialog = frmAdd.ShowDialog();
                if (dialog != DialogResult.OK)
                {
                    goto TheEnd;
                }

                string message = LoadProduct();
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

        private void txtSearchGroup_TextChanged(object sender, EventArgs e)
        {
            string message = "";

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string message = "";

            if (txtSearch.Text.Equals(string.Empty))
            {
                message = LoadProduct();
                if (message.Length > 0)
                {
                    MessageBox.Show(message);
                    goto TheEnd;
                }
            }

            message = LoadProductSearch();
            if (message.Length > 0)
            {
                MessageBox.Show(message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            txtSearchGroup.Text = "";
        }

        private void btnXProduct_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void TsmiAddGroup_Click(object sender, EventArgs e)
        {
            // Nhấn button add
            btnAddGroup.PerformClick();
        }

        private void TsmiAdd_Click(object sender, EventArgs e)
        {
            btnAddPr.PerformClick();
        }
    }
}
