using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmConnect : Form
    {
        private string _connectionString = string.Empty;
        private FrmWait _frmWait = null;

        private string _message = string.Empty;
        private string _serverName = string.Empty;
        private string _database = string.Empty;
        private string _user = string.Empty;
        private string _password = string.Empty;
        private int _curentHeight = 100;

        public FrmConnect()
        {
            InitializeComponent();
        }

        private void btnLoadServer_Click(object sender, EventArgs e)
        {
            try
            {
                Task task = new Task(delegate
                {
                    _frmWait = new FrmWait();
                    _frmWait.SetTitle(INF_WAIT_LOAD_SERVER);
                    _frmWait.ShowDialog();
                });
                task.Start();

                string message = GetServerName();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
            }
            finally
            {
                _frmWait.BeginInvoke((Action)delegate
                {
                    _frmWait.Close();
                });
            }

        TheEnd:
            return;
        }

        private void cbbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string message = GetDatabaseName();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Kiểm tra nhập liệu</para>
        /// </summary>
        /// <returns>Message lỗi nếu có</returns>
        private string CheckValidData()
        {
            string message = string.Empty;
            _serverName = cbbServerName.Text.Trim();
            _database = cbbDatabaseName.Text.Trim();
            _user = txtUser.Text.Trim();
            _password = txtPassword.Text.Trim();

            if (_serverName.Length == 0)
            {
                message = ERROR_EMPTY_SERVERNAME;
                goto TheEnd;
            }
            else if (_database.Length == 0)
            {
                message = ERR_EMPTY_DBNNAME;
                goto TheEnd;
            }

            if (rdbSqlServer.Checked == false)
            {
                goto TheEnd;
            }

            if (_user.Length == 0)
            {
                message = ERROR_ENTER_USER;
                goto TheEnd;
            }
            else if (_password.Length == 0)
            {
                message = ERROR_ENTER_PASSWORD;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        /// <summary>
        /// <para>Lấy danh sách database</para>
        /// </summary>
        /// <returns>Message lỗi nếu có</returns>
        private string GetServerName()
        {
            string message = string.Empty;

            try
            {
                string myServer = Environment.MachineName;

                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                for (int serverIdx = 0; serverIdx < servers.Rows.Count; serverIdx++)
                {
                    if (myServer == servers.Rows[serverIdx]["ServerName"].ToString())
                    {
                        if ((servers.Rows[serverIdx]["InstanceName"] as string) != null)
                        {
                            cbbServerName.Items.Add(servers.Rows[serverIdx]["ServerName"] + "\\"
                                                        + servers.Rows[serverIdx]["InstanceName"]);
                        }
                        else
                        {
                            cbbServerName.Items.Add(servers.Rows[serverIdx]["ServerName"].ToString());
                        }

                        cbbServerName.SelectedIndex = 0;
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

        /// <summary>
        /// <para>Get database name</para>
        /// </summary>
        /// <returns>Message lỗi nếu có</returns>
        private string GetDatabaseName()
        {
            string message = string.Empty;
            SqlConnection conn = null;
            try
            {
                string dataSource = cbbServerName.Text.Trim();
                string connectionString = "Data Source= " + dataSource + "; Integrated Security=True;";
                conn = new SqlConnection(connectionString);
                conn.Open();

                StringBuilder sql = new StringBuilder();
                sql.Append("Select name").Append(" ");
                sql.Append("From sys.databases").Append(" ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtDatabase = new DataTable();
                adapter.Fill(dtDatabase);
                if (dtDatabase == null)
                {
                    message = ERROR_LOAD_DB;
                    goto TheEnd;
                }

                cbbDatabaseName.DataSource = dtDatabase;
                cbbDatabaseName.DisplayMember = "name";
                cbbDatabaseName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                Common.CloseConnect(conn);
            }

        TheEnd:
            return message;
        }

        /// <summary>
        /// <para>Test connect</para>
        /// </summary>
        /// <returns>Message lỗi nếu có</returns>
        private string TestConnect()
        {
            string message = string.Empty;
            SqlConnection conn = null;

            try
            {
                _connectionString = @"Data Source = " + _serverName + ";";
                _connectionString += "Initial Catalog = " + _database + ";";
                _connectionString += "Integrated Security = True;";

                if (rdbSqlServer.Checked != false)
                {
                    _connectionString = _connectionString.Replace("Integrated Security", "Persist Security Info");
                    _connectionString += "User ID =" + _user + ";";
                    _connectionString += "Password = " + _password;
                }

                conn = new SqlConnection(_connectionString);
                conn.Open();

                message = INF_CONNECT_SUCCESS;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                Common.CloseConnect(conn);
            }

        TheEnd:
            return message;
        }

        /// <summary>
        /// <para>Ẩn panel user</para>
        /// </summary>
        private void HidePanelUser()
        {
            txtUser.Text = "";
            txtPassword.Text = "";
            pnlUser.Visible = false;           
            Height = Height - pnlUser.Height;
        }

        /// <summary>
        /// <para>Ghi file kết nối</para>
        /// </summary>
        /// <param name="server">Tên server</param>
        /// <param name="database">Tên database</param>
        /// <param name="uid">Người dùng</param>
        /// <param name="pass">Mật khẩu</param>
        /// <returns></returns>
        private string WriteFile(string server, string database, string uid, string pass)
        {
            string message = string.Empty;

            try
            {
                string dirPath = Common.GetPathDatabaseConnection();
                StreamWriter writer = new StreamWriter(dirPath);
                string allText = server + ";" + database + ";" + uid + ";" + pass;
                writer.Write(allText);
                writer.Close();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private void FrmConnect_Load(object sender, EventArgs e)
        {
            
            HidePanelUser();
            _curentHeight = Height + pnlUser.Height;
        }

        private void rdbWindows_CheckedChanged(object sender, EventArgs e)
        {
            HidePanelUser();
        }

        private void rdbSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            Height = _curentHeight;
            pnlUser.Visible = true;
            ActiveControl = txtUser;
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string message = CheckValidData();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                message = TestConnect();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string message = CheckValidData();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }

                message = WriteFile(
                    _serverName,
                    _database,
                    Common.Encrypt(SHOW_KEY_ENCRYPT, _user),
                    Common.Encrypt(SHOW_KEY_ENCRYPT, _password));
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            //Application.Exit();
        }
    }
}
