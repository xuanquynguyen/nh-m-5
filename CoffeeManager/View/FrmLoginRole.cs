using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmLoginRole : Form
    {
        private long _idLogin = 0;
        private int _idMenu = 0;
        private string _userName = "";
        public FrmLoginRole()
        {
            InitializeComponent();
        }

        private void FrmLoginRole_Load(object sender, EventArgs e)
        {
            try
            {
                string message = LoadUserLogin();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                message = LoadMenuItems();
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

        /// <summary>
        /// <para>Hiển thị danh sách menu</para>
        /// </summary>
        /// <returns>Message lỗi nếu có</returns>
        private string LoadMenuItems()
        {
            string message = "";
            try
            {
                List<DbMenuItemOut> dbUserInfos = DbLogin.GetAllMenuItems();
                if (dbUserInfos == null)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }
                // Hiển thị lên list
                DgvRight.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbUserInfos.Count; rowIdx++)
                {
                    DbMenuItemOut dbUserInfo = dbUserInfos[rowIdx];

                    DgvRight.Rows.Add();
                    DgvRight.Rows[rowIdx].Tag = dbUserInfo;

                    DgvRight.Rows[rowIdx].Cells["ColNameMenu"].Value = dbUserInfo.NameMenu;
                    DgvRight.Rows[rowIdx].Cells["ColNameShow"].Value = dbUserInfo.NameShow;
                    DgvRight.Rows[rowIdx].Cells["ColId"].Value = dbUserInfo.Id;
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

        /// <summary>
        /// <para>Hiển thị menu đã được cấp quyền theo id login</para>
        /// </summary>
        /// <returns></returns>
        private string LoadMenuItemsById()
        {
            string message = "";
            try
            {
                List<DbMenuItemOut> dbUserInfos = DbLogin.GetAllMenuItems();
                if (dbUserInfos == null)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }
                // Hiển thị lên list
                DgvRight.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbUserInfos.Count; rowIdx++)
                {
                    DbMenuItemOut dbUserInfo = dbUserInfos[rowIdx];

                    DgvRight.Rows.Add();
                    DgvRight.Rows[rowIdx].Tag = dbUserInfo;
                    DataGridViewRow row = DgvRight.Rows[rowIdx];

                    row.Cells["ColNameMenu"].Value = dbUserInfo.NameMenu;
                    row.Cells["ColNameShow"].Value = dbUserInfo.NameShow;
                    row.Cells["ColId"].Value = dbUserInfo.Id;
                    _idMenu = dbUserInfo.Id;
                    DbLoginRoleOut check = DbLogin.CheckRoleAllowBy2Id(_idLogin, _idMenu);
                    row.Cells["ColIsRoom"].Value = false;
                    if (check != null)
                    {
                        row.Cells["ColIsRoom"].Value = true;
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

        private string LoadUserLogin()
        {
            string message = "";
            try
            {
                // Load danh sách nhân viên (chỉ load đang sử dụng)
                List<DbLoginOut> dbUserInfos = DbLogin.GetAllLogin();
                if (dbUserInfos == null)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    goto TheEnd;
                }

                // Hiển thị lên list
                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbUserInfos.Count; rowIdx++)
                {
                    DbLoginOut dbUserInfo = dbUserInfos[rowIdx];

                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = dbUserInfo;

                    dgvMain.Rows[rowIdx].Cells["ColName"].Value = dbUserInfo.UserName;
                    dgvMain.Rows[rowIdx].Cells["ColFullName"].Value = dbUserInfo.FullName;
                }

                dgvMain.ClearSelection();
            }
            catch (Exception ex)
            {
                message = (ex.Message);
                DialogResult = DialogResult.Abort;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DbLoginOut dbUserInfo = (DbLoginOut)dgvMain.SelectedRows[0].Tag;
              

            lblNameHeader.Text = dbUserInfo.FullName;
            _idLogin = dbUserInfo.Id;
            _userName = dbUserInfo.UserName;
            string message = LoadMenuItemsById();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
                goto TheEnd;
            }

            btnAccept.Enabled = true;
            if (dbUserInfo.UserName.Equals("admin"))
            {
                btnAccept.Enabled = false;
                goto TheEnd;
            }

            CkbCheckAll.CheckedChanged += new EventHandler(CkbCheckAll_CheckedChanged);

        TheEnd:
            return;
        }

        private void DgvRight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count != 1)
                {
                    MsgBox.CfmInfomation(ERROR_SELECT_AC);                  
                    goto TheEnd;
                }   
                
                // Bỏ qua khi click bên ngoài
                if ((e.RowIndex < 0) || (e.ColumnIndex < 0))
                {
                    goto TheEnd;
                }

                // Kiểm tra có phải click ở checkbox không
                bool isClickCheck = DgvRight.Columns[e.ColumnIndex].Name.Equals("ColIsRoom");
                if (isClickCheck == false)
                {
                    goto TheEnd;
                }

                // Thay đổi trạng thái value từ true sang false và ngược lại
                bool iStatus = (bool)DgvRight.Rows[e.RowIndex].Cells["ColIsRoom"].Value;
                DgvRight.Rows[e.RowIndex].Cells["ColIsRoom"].Value = !iStatus;

                // CkbCheckAll.Checked = false;
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.ToString());
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void CkbCheckAll_CheckedChanged(object sender, EventArgs e)
        {           
            if (dgvMain.SelectedRows.Count != 1)
            {
                MsgBox.CfmInfomation(ERROR_SELECT_AC);
                CkbCheckAll.CheckedChanged -= new EventHandler(CkbCheckAll_CheckedChanged);
                CkbCheckAll.Checked = false;              
                goto TheEnd;
            }

            bool isChecked = false;
            if (CkbCheckAll.Checked != false)
            {
                isChecked = true;
            }  

            for (int idxCheck = 0; idxCheck < DgvRight.Rows.Count; idxCheck++)
            {
                DataGridViewRow row = DgvRight.Rows[idxCheck];
                row.Cells["ColIsRoom"].Value = isChecked;
            }

        TheEnd:
            return;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMain.SelectedRows.Count != 1)
                {
                    MsgBox.CfmInfomation(ERROR_SELECT_AC);                   
                    goto TheEnd;
                }

                List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();
                int coutRows = 0;
                foreach (DataGridViewRow row in DgvRight.Rows)
                {
                    bool isChecked = (bool)DgvRight.Rows[coutRows].Cells["ColIsRoom"].Value;
                    coutRows += 1;
                    if (isChecked != false)
                    {
                        checkedRows.Add(row);
                    }
                }

                // Xóa quyền cũ của người dùng để cập nhật lại
                DbLogin.DelUserRole(_idLogin);  

                for (int i = 0; i < checkedRows.Count; i++)
                {
                    int menuId = (int)checkedRows[i].Cells["ColId"].Value;
                    int insr = DbLogin.InsertLoginRole(_idLogin, menuId);
                    
                    if (insr < 1)
                    {
                        MsgBox.ErrProcess(DbEmployees.Message);
                        goto TheEnd;
                    }

                    Thread.Sleep(10);
                }

                MsgBox.CfmInfomation(MSG_DONE);
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userName.Equals("admin"))
                {
                    MsgBox.ErrProcess(ERROR_DEL_ADMIN);
                    goto TheEnd;
                }

                if (dgvMain.SelectedRows.Count != 1)
                {
                    MsgBox.CfmInfomation(MSG_SELECT_AC);
                    goto TheEnd;
                }

                DialogResult quest = MsgBox.CfmProcessing(MSG_DEL_AC);
                if (quest != DialogResult.Yes)
                {
                    goto TheEnd;
                }
                
                DbLogin.DeleteLogin(_idLogin);
                MsgBox.CfmInfomation(MSG_DONE);

                string message = LoadUserLogin();
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
