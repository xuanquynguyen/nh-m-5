using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoffeeManager
{
    public partial class FrmUserSel : Form
    {
        private DbEmployeesOut _dbUserInfo = null;
        public FrmUserSel()
        {
            InitializeComponent();
            _dbUserInfo = new DbEmployeesOut();
        }

        private void FrmUserSel_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách nhân viên (chỉ load đang sử dụng)
                List<DbEmployeesOut> dbUserInfos = DbEmployees.GetAllEm(1, true);
                if (dbUserInfos == null)
                {
                    MsgBox.ErrProcess(DbEmployees.Message);
                    DialogResult = DialogResult.Abort;
                    goto TheEnd;
                }

                // Hiển thị lên list
                dgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbUserInfos.Count; rowIdx++)
                {
                    DbEmployeesOut dbUserInfo = dbUserInfos[rowIdx];

                    dgvMain.Rows.Add();
                    dgvMain.Rows[rowIdx].Tag = dbUserInfo;

                    dgvMain.Rows[rowIdx].Cells["ColName"].Value = dbUserInfo.FullName;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                DialogResult = DialogResult.Abort;
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Bỏ qua khi click bên ngoài
                if ((e.RowIndex < 0) || (e.ColumnIndex < 0))
                {
                    goto TheEnd;
                }

                // Get thông tin nhân viên row click vào biến global
                _dbUserInfo = (DbEmployeesOut)dgvMain.Rows[e.RowIndex].Tag;

                // Đóng giao diện
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

        /// <summary>
        /// <para>Thông tin nhân viên</para>
        /// </summary>
        public DbEmployeesOut UserInfo
        {
            get
            {
                return _dbUserInfo;
            }
        }
    }
}
