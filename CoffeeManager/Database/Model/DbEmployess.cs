using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbEmployees
    {
        private static string _message = "";
       
        /// <summary>
        /// <para>Lấy danh sách người dùng</para>
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<DbEmployeesOut> GetAllEm(int mode, bool status)
        {
            List<DbEmployeesOut> dbEmOuts = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select *").Append(" ");
                sql.Append("From Employees").Append(" ");
                if (mode != 0)
                {
                    sql.Append("Where status = '"+ status + "' ").Append(" ");
                }

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                dbEmOuts = new List<DbEmployeesOut>();
                DbEmployeesOut dbEmOut = null;
                while(rdr.Read() != false)
                {
                    dbEmOut = new DbEmployeesOut();
                    dbEmOut.Id = Common.GetDbNull<long>(rdr, "id");
                    dbEmOut.FullName = Common.GetDbNull<string>(rdr, "fullName");
                    dbEmOut.PhoneNumber = Common.GetDbNull<string>(rdr, "phoneNumber");
                    dbEmOut.Address = Common.GetDbNull<string>(rdr, "address");
                    dbEmOut.IdCard = Common.GetDbNull<string>(rdr, "idCard");
                    dbEmOut.DateWork = Common.GetDbNull<DateTime>(rdr, "dateWork");
                    dbEmOut.Img = Common.GetDbNull<byte[]>(rdr, "img");
                    dbEmOut.Status = Common.GetDbNull<bool>(rdr, "status");
                    dbEmOuts.Add(dbEmOut);
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
            return dbEmOuts;
        }

        public static string GetNameEmById(long idEms)
        {
            string name = "";
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select name").Append(" ");
                sql.Append("From Employees").Append(" ");
                sql.Append("Where id = "+idEms+" ").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read() != false)
                {
                    name = (string)rdr[0];
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
            return name;
        }

        public static int InserOrUpdatetUser(ModeExe mode, DbEmployeesIn dbEmIn)
        {
            int insert = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Insert Into Employees (id, fullName, phoneNumber, address, idCard, dateWork, img, status)" +
                    "Values (@id, @name, @phone, @address, @idCard, @dateWork, @img, @status)";

                long id = ConnectSql.CreateId();

                if (mode == ModeExe.Update)
                {
                    sql = "Update Employees " +
                   "Set fullName =  @name, " +
                   "phoneNumber = @phone, address = @address, " +
                   "idCard = @idCard, " +
                   "dateWork = @dateWork, img = @img, status = @status " +
                   "Where id = @id";

                    id = dbEmIn.Id;
                }    

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", dbEmIn.FullName);
                command.Parameters.AddWithValue("@phone", dbEmIn.PhoneNumber);
                command.Parameters.AddWithValue("@address", dbEmIn.Address);
                command.Parameters.AddWithValue("@idCard", dbEmIn.IdCard);
                command.Parameters.AddWithValue("@dateWork", dbEmIn.DateWord);
                command.Parameters.AddWithValue("@img", dbEmIn.Img);
                command.Parameters.AddWithValue("@status", dbEmIn.Status);
                insert = command.ExecuteNonQuery();
                if (insert < 1)
                {
                    _message = ERROR_MANIPULATING_USER;
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

        public static DataTable CheckUserOfEmployeesId(long idEmployees)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            try
            {
                string sql = "Select * from Login where idEmployees = " + idEmployees + " ";
                conn = ConnectSql.GetConnect();
                conn.Open();

                dt = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.Fill(dt);
                if (dt == null)
                {
                    _message = ERROR_ACCESS_DATA;
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

        public static int DeleteEms(long id)
        {
            int del = 0;
            try
            {
                string sql = "Delete From Employees Where id = "+id+"";
                del = ConnectSql.ExecNonQuerySql(sql);
                if (del < 1)
                {
                    _message = ERROR_DELETING_USER;
                    goto TheEnd;
                }    
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }
        public static List<DbEmployeesOut> SearchEmployees(int modeSearch, bool status, string keyWord)
        {
            List<DbEmployeesOut> dbEmOuts = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select *").Append(" ");
                sql.Append("From Employees").Append(" ");
                sql.Append("Where (id like '%"+keyWord+"%' ").Append(" ");
                sql.Append("Or fullName like N'%" + keyWord + "%' ").Append(" ");
                sql.Append("Or phoneNumber like '%" + keyWord + "%' ").Append(" ");
                sql.Append("Or address like N'%" + keyWord + "%' ").Append(" ");
                sql.Append("Or idCard like '%" + keyWord + "%' )").Append(" ");
                if (modeSearch != 0)
                {
                    sql.Append("And status = '"+status+"' ").Append(" ");
                }

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = command.ExecuteReader();
                dbEmOuts = new List<DbEmployeesOut>();
                DbEmployeesOut dbEmOut = null;
                while (rdr.Read() != false)
                {
                    dbEmOut = new DbEmployeesOut();
                    dbEmOut.Id = Common.GetDbNull<long>(rdr, "id");
                    dbEmOut.FullName = Common.GetDbNull<string>(rdr, "fullName");
                    dbEmOut.PhoneNumber = Common.GetDbNull<string>(rdr, "phoneNumber");
                    dbEmOut.Address = Common.GetDbNull<string>(rdr, "address");
                    dbEmOut.IdCard = Common.GetDbNull<string>(rdr, "idCard");
                    dbEmOut.DateWork = Common.GetDbNull<DateTime>(rdr, "dateWork");
                    dbEmOut.Img = Common.GetDbNull<byte[]>(rdr, "img");
                    dbEmOut.Status = Common.GetDbNull<bool>(rdr, "status");
                    dbEmOuts.Add(dbEmOut);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                dbEmOuts = null;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dbEmOuts;
        }

        public static string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
