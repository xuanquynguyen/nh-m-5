using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbCustomer
    {
        private string _message = "";
        public DataTable GetAllCustomer()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select tb.* from tbCustomer as tb where tb.status = 'false' ";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }
        public DataTable GetAllCustomerBusy()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select tb.* from tbCustomer as tb where tb.status = 'true' ";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public int InsertCustomer(string name, string address, string phone, string des)
        {
            int Res = 0;
            try
            {
                string id = DateTime.Now.ToString("yyyyMMddhhmmssff");
                string sql = "Insert into tbCustomer " +
                    "Values (" + id + ", N'" + name + "', N'"+address+", '"+phone+"', N'" + des + "', 0)";
                Res = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Res;
        }

        public int UpdateStatusCustomer(long id)
        {
            int status = 0;
            try
            {
                string sql = "Update tbCustomer Set status = 'false' Where id = " + id + " ";
                status = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return status;
        }

        public int UpdateStatusCustomer2(long id)
        {
            int insertBill = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Update tbCustomer Set status = 'true' where id = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                insertBill = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return insertBill;
        }

        public List<DbCustomerOut> GetAllCus(string search)
        {
            List<DbCustomerOut> dbproductOuts = null;
            SqlConnection conn = null;
            try
            {
                string sql = "Select * from tbCustomer ";
                if (search.Length > 0)
                {
                    sql += "Where name like N'%"+search+"%' ";
                    sql += "Or address like N'%"+search+"%' ";
                    sql += "Or phone like '%"+search+"%' ";
                    sql += "Or description like N'%"+search+"%' ";
                }   
                
                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                DbCustomerOut dbCusOut = null;
                dbproductOuts = new List<DbCustomerOut>();
                while (rdr.Read() != false)
                {
                    dbCusOut = new DbCustomerOut();
                    dbCusOut.ID = (long)rdr["id"];
                    dbCusOut.Name = (string)rdr["name"];
                    dbCusOut.Address = Common.GetDbNull<string>(rdr, "address");
                    dbCusOut.PhoneNumber = Common.GetDbNull<string>(rdr, "phone");
                    dbCusOut.Description = Common.GetDbNull<string>(rdr, "description");
                    dbCusOut.Status = Common.GetDbNull<bool>(rdr, "status");
                    dbproductOuts.Add(dbCusOut);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                dbproductOuts = null;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dbproductOuts;
        }

        /// <summary>
        /// <para>Xóa khách hàng</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelCustomer(long id)
        {
            bool delComp = false;
            try
            {
                string sql = "Delete From tbCustomer Where id = " + id + "";
                ConnectSql.ExecNonQuerySql(sql);
                delComp = true;
            }
            catch (Exception ex)
            {
                delComp = false;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return delComp;
        }

        public int UpdatetCus(ModeExe modeExe, DbCustomerIn dbCusIn)
        {
            int insert = 0;
            SqlConnection conn = null;
            try
            {
                
                string sql = "Update tbCustomer " +
                "Set name =  @name, " +
                "address = @address, phone = @phone, " +
                "description = @description, status = @status " +
                "Where id = @id";
                
                if (modeExe == ModeExe.Add)
                {
                    long id = ConnectSql.CreateId();
                    sql = "Insert into tbCustomer (id, name, address, phone, description, status) " +
                    "Values (" + id + ", @name, @address, @phone, @description, 0)";
                }    

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", dbCusIn.ID);
                command.Parameters.AddWithValue("@name", dbCusIn.Name);
                command.Parameters.AddWithValue("@address", dbCusIn.Address);
                command.Parameters.AddWithValue("@phone", dbCusIn.PhoneNumber);
                command.Parameters.AddWithValue("@description", dbCusIn.Description);
                command.Parameters.AddWithValue("@status", dbCusIn.Status);
                insert = command.ExecuteNonQuery();
                if (insert < 1)
                {
                    _message = ERROR_WHEN_UPDATING;
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

        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
