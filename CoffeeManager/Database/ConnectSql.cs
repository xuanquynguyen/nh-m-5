using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class ConnectSql
    {
        private static string _message = string.Empty;
        private static string _serverName = @"Data Source=VPQN\QLSV;Initial Catalog=Coffee;Integrated Security=True";
        private static string _database = "Coffee";
        private static string _user = string.Empty;
        private static string _password = string.Empty;

        /// <summary>
        /// <para>Đọc chuỗi kết nối</para>
        /// </summary>
        /// <returns></returns>
        private static string ReadConnection()
        {
            string message = string.Empty;

            try
            {
                string dirPath = Common.GetPathDatabaseConnection();
                bool isExistDirPath = File.Exists(dirPath);
                if (isExistDirPath == false)
                {
                    MsgBox.CfmInfomation(MSG_CONNECT_STR_NONE);
                    FrmConnect frmConnect = new FrmConnect();
                    DialogResult showFrmConnect = frmConnect.ShowDialog();
                    if (showFrmConnect != DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }

                string fileConn = File.ReadAllText(dirPath);
                string[] stTb = fileConn.Split(new char[] { ';' });
                _serverName = stTb[0];
                _database = stTb[1];
                string user = stTb[2];
                string passaword = stTb[3];

                _user = Common.Decrypt(SHOW_KEY_ENCRYPT, user);
                _password = Common.Decrypt(SHOW_KEY_ENCRYPT, passaword);
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
        /// <para>Get connnect</para>
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnect()
        {
            string connectionString = string.Empty;

            try
            {
                _message = ReadConnection();
                if (_message.Length > 0)
                {
                    goto TheEnd;
                }

                connectionString = @"Data Source = " + _serverName + ";";
                connectionString += "Initial Catalog = " + _database + ";";
                connectionString += "Integrated Security = True;";

                if (_user.Length > 0)
                {
                    connectionString = connectionString.Replace("Integrated Security", "Persist Security Info");
                    connectionString += "User ID =" + _user + ";";
                    connectionString += "Password = " + _password;
                }

            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return new SqlConnection(connectionString);
        }      

        public static int ExecNonQuerySql(string sql)
        {
            int exec = 0;
            SqlConnection conn = null;
            try
            {
                conn = GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                exec = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                exec = 0;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                CloseConnect(conn);
            }

        TheEnd:
            return exec;
        }

        /// <summary>
        /// <para>Thực thi câu lệnh select</para>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecQuerySql(string sql)
        {
            DataTable dtExec = null;
            SqlConnection conn = null;

            try
            {
                conn = GetConnect();
                conn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sql, conn);
                dtExec = new DataTable();
                sqlAdapter.Fill(dtExec);
            }
            catch (Exception ex)
            {
                dtExec = null;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                CloseConnect(conn);
            }

        TheEnd:
            return dtExec;
        }

        public static long CreateId()
        {
            string id = DateTime.Now.ToString("yyyyMMddhhmmssffff");
            return long.Parse(id);
        }

        public static void CloseConnect(SqlConnection connect)
        {
            if (connect != null)
            {
                connect.Close();
                connect.Dispose();
            }
        }
    }
}
