using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbLogin
    {
        public static string _message = "";

        public static DataTable GetLogin(string user, string password)
        {
            DataTable dt = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" Select * from Login").Append(" ");
                sql.Append(" Where userName = @user").Append(" ");
                sql.Append(" And password = @password").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password", password);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt == null)
                {
                    _message = ERROR_ACCESS_DATA;
                    goto TheEnd;
                }

                if (dt.Rows.Count < 1)
                {
                    _message = ERROR_WRONG_USERNAME;                   
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                dt = null;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return dt;
        }

        public static DataTable GetFullNameLogin(long idEms)
        {
            DataTable dt = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();               
                conn = ConnectSql.GetConnect();
                conn.Open();

                sql.Append("Select *").Append(" ");
                sql.Append("From").Append(" ");
                sql.Append("Employees").Append(" ");
                sql.Append("Where id = @idEm").Append(" ");
                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@idEm", idEms);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt == null)
                {
                    _message = ERROR_USER_NOTFOUND;
                    goto TheEnd;
                }

                DataRow dr = dt.Rows[0];
                long idEmployees = (long)dr["idEmployees"];

                sql.Clear();

            
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return dt;
        }

        public static DataTable CheckIdEmployees(long idEms)
        {
            DataTable dt = null;
            try
            {
                string sql = "Select * From Login Where idEmployees = " + idEms + " ";
                dt = new DataTable();
                dt = ConnectSql.ExecQuerySql(sql);
                if (dt == null)
                {
                    _message = ERROR_RETRIEVING_LOGIN_INFO;
                    goto TheEnd;
                }

                if (dt.Rows.Count > 0)
                {
                    _message = ERROR_CREATED_ACCOUNT;
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return dt;
        }

        /// <summary>
        /// <para>Insert or Update Login</para>
        /// </summary>
        /// <param name="modeExe"></param>
        /// <param name="dbLogIn"></param>
        /// <returns></returns>
        public static int InsertOrUpdateLogin(ModeExe modeExe, DbLoginIn dbLogIn)
        {
            int insert = 0;
            SqlConnection conn = null;
            try
            {
                long id = ConnectSql.CreateId();

                StringBuilder sql = new StringBuilder();
                sql.Append("Insert Into Login (").Append(" ");
                sql.Append("id,").Append(" ");
                sql.Append("idEmployees,").Append(" ");
                sql.Append("userName,").Append(" ");
                sql.Append("password,").Append(" ");
                sql.Append("isUse)").Append(" ");
                sql.Append("Values(").Append(" ");
                sql.Append("@id,").Append(" ");
                sql.Append("@idEmployees,").Append(" ");
                sql.Append("@userName,").Append(" ");
                sql.Append("@password,").Append(" ");
                sql.Append("@isUse)").Append(" ");

                if (modeExe == ModeExe.Update)
                {
                    sql.Clear();
                    sql.Append("Update Login Set").Append(" ");
                    sql.Append("idEmployees = @idEmployees,").Append(" ");
                    sql.Append("userName = @userName,").Append(" ");
                    sql.Append("password = @password,").Append(" ");
                    sql.Append("isUse = @isUse").Append(" ");
                    sql.Append("Where id = @id").Append(" ");
                }

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@idEmployees", dbLogIn.IdEmployees);
                command.Parameters.AddWithValue("@userName", dbLogIn.UserName);
                command.Parameters.AddWithValue("@password", dbLogIn.Password);
                command.Parameters.AddWithValue("@isUse", dbLogIn.IsUse);
                insert = command.ExecuteNonQuery();
                if (insert < 1)
                {
                    _message = ERROR_SHOW_ERROR;
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return insert;
        }

        public static List<DbLoginOut> GetAllLogin()
        {
            List<DbLoginOut> dbLogOuts = null;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select lg.id,").Append(" ");
                sql.Append("lg.idEmployees,").Append(" ");
                sql.Append("lg.userName,").Append(" ");
                sql.Append("em.fullName").Append(" ");
                sql.Append("From Login lg").Append(" ");
                sql.Append("Inner Join Employees em").Append(" ");
                sql.Append("On lg.idEmployees = em.id").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                dbLogOuts = new List<DbLoginOut>();
                DbLoginOut dbLogOut = null;
                while (rdr.Read() != false)
                {
                    dbLogOut = new DbLoginOut();
                    dbLogOut.Id = Common.GetDbNull<long>(rdr, "id");
                    dbLogOut.IdEmployees = Common.GetDbNull<long>(rdr, "idEmployees");
                    dbLogOut.UserName = Common.GetDbNull<string>(rdr, "userName");
                    //dbLogOut.IsUse = Common.GetDbNull<bool>(rdr, "isUse");
                    dbLogOut.FullName = Common.GetDbNull<string>(rdr, "fullName");
                    dbLogOuts.Add(dbLogOut);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                dbLogOuts = null;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dbLogOuts;
        }

        public static List<DbMenuItemOut> GetAllMenuItems()
        {
            List<DbMenuItemOut> dbLogOuts = null;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select *").Append(" ");
                sql.Append("from MenuItems ").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                dbLogOuts = new List<DbMenuItemOut>();
                DbMenuItemOut dbLogOut = null;
                while (rdr.Read() != false)
                {
                    dbLogOut = new DbMenuItemOut();
                    dbLogOut.Id = Common.GetDbNull<int>(rdr, "id");
                    dbLogOut.NameMenu = Common.GetDbNull<string>(rdr, "nameMenu");
                    dbLogOut.NameShow = Common.GetDbNull<string>(rdr, "nameShow");
                    dbLogOuts.Add(dbLogOut);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                dbLogOuts = null;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dbLogOuts;
        }

        public static DbLoginRoleOut CheckRoleAllowBy2Id(long idLogin, int idMenu)
        {
            DbLoginRoleOut dbLogRoleOut = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select *").Append(" ");
                sql.Append("From LoginRole").Append(" ");
                sql.Append("Where idLogin = " + idLogin + "").Append(" ");
                sql.Append("And idMenuItems = " + idMenu + "").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read() != false)
                {
                    dbLogRoleOut = new DbLoginRoleOut();
                    dbLogRoleOut.Id = Common.GetDbNull<long>(rdr, "id");
                    dbLogRoleOut.IdLogin = Common.GetDbNull<long>(rdr, "idLogin");
                    dbLogRoleOut.IdMenuItems = Common.GetDbNull<int>(rdr, "idMenuItems");
                    break;
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dbLogRoleOut;
        }

        /// <summary>
        /// <para>Xóa dữ liệu cũ để cập nhật</para>
        /// </summary>
        /// <param name="idLogin"></param>
        /// <returns></returns>
        public static int DelUserRole(long idLogin)
        {
            int del = 0;

            try
            {
                string sql = "Delete From LoginRole Where idLogin = " + idLogin + " ";
                del = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }

        public static int InsertLoginRole(long idLogin, int idMenu)
        {
            int insert = 0;

            try
            {
                long id = ConnectSql.CreateId();
                string sql = "Insert Into LoginRole (id, idLogin, idMenuItems)" +
                    "Values (" + id + ", " + idLogin + ", " + idMenu + ") ";
                insert = ConnectSql.ExecNonQuerySql(sql);
                if (insert < 1)
                {
                    _message = ERROR_SAVE_DATA;
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return insert;
        }

        public static List<DbLoginRoleOut> GetLoginRoleByIdLogin(long idLogin)
        {
            List<DbLoginRoleOut> dbLoginRoleOuts = null;
            SqlConnection conn = null;

            try
            {
                string sql = "Select * from LoginRole Where idLogin = " + idLogin + " ";
                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                dbLoginRoleOuts = new List<DbLoginRoleOut>();
                DbLoginRoleOut dbLoginRoleOut = null;
                while (rdr.Read() != false)
                {
                    dbLoginRoleOut = new DbLoginRoleOut();
                    dbLoginRoleOut.Id = Common.GetDbNull<long>(rdr, "id");
                    dbLoginRoleOut.IdLogin = Common.GetDbNull<long>(rdr, "idLogin");
                    dbLoginRoleOut.IdMenuItems = Common.GetDbNull<int>(rdr, "idMenuItems");
                    dbLoginRoleOuts.Add(dbLoginRoleOut);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }
        TheEnd:
            return dbLoginRoleOuts;
        }

        public static string GetMenuNameById(long idMenu)
        {
            string name = "";
            SqlConnection conn = null;

            try
            {
                string sql = "Select * From MenuItems Where id = " + idMenu + " ";
                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read() != false)
                {
                    name = (string)rdr["nameMenu"];
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                name = "";
                _message = ex.Message;
                goto TheEnd;
            }
        TheEnd:
            return name;
        }

        public static int DeleteLogin(long idLogin)
        {
            int del = 0;

            try
            {
                string sql = "Delete From Login Where id = "+idLogin+" ";
                del = ConnectSql.ExecNonQuerySql(sql);
                
                sql = "Delete From LoginRole Where idLogin  = " + idLogin + " ";
                del = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }

        public static int ChangePassword(long idLogin, string newPassword)
        {
            int change = 0;
            try
            {
                string sql = "Update Login set password = '" + newPassword + "' Where id = " + idLogin + " ";
                change = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                change = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return change;
        }
     
        public static string Message
        {
            set { _message = value; }
            get { return _message; }
        }

    }
}
