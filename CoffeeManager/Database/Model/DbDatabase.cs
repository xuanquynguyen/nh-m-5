using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbDatabase
    {
        private static string _message = "";

        public static int Backup(string fileName)
        {
            int bak = 0;
            try
            {
                string sql = "BACKUP DATABASE Coffee TO DISK='" + fileName + "' ";
                bak = ConnectSql.ExecNonQuerySql(sql);
                if (bak == 0)
                {
                    _message = MSG_DONT_SAVE_C;
                    goto TheEnd;
                }    
            }
            catch (Exception ex)
            {
                bak = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return bak;
        }

        public static int Restore(string fileName)
        {
            int res = 0;
            try
            {
                SqlConnection conn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
                string sql = "USE MASTER ALTER DATABASE [Coffee] " +
                    "set single_User WITH Rollback Immediate " +
                    "ALTER DATABASE [Coffee] set Multi_User " +
                    "RESTORE DATABASE [Coffee] " +
                    "FROM DISK ='" + fileName + "' " +
                    "WITH REPLACE ";
                res = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                res = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return res;           
        }

        /// <summary>
        /// <para>Kiểm tra tồn tại Database</para>
        /// </summary>
        /// <param name="databaseName">Tên database</param>
        /// <returns></returns>
        public static bool CheckDatabaseExists()
        {
            bool result = false;
            SqlConnection conn = null;
            try
            {
                string databaseName = "Coffee";
                conn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
                string sql = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
        
                using (conn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        object resultObj = sqlCmd.ExecuteScalar();
                        int databaseID = 0;
                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                conn.Close();
            }

        TheEnd:
            return result;
        }

        /// <summary>
        /// <para>Chạy file script</para>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExecScriptSql(string path)
        {
            bool success = false;
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
                string script = File.ReadAllText(path);
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                conn.Open();
                foreach (string commandString in commandStrings)
                {
                    if (!string.IsNullOrWhiteSpace(commandString.Trim()))
                    {
                        using (var command = new SqlCommand(commandString, conn))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }

                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                conn.Close();
            }

        TheEnd:
            return success;
        }

        public static string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
