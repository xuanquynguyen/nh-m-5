using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbProduct
    {
        private  static string _message = "";

        /// <summary>
        /// <para>Thêm dữ liệu cho sản phẩm</para>
        /// </summary>
        /// <param name="dbprIn">Đối tượng chứa thông tin đầu vào</param>
        /// <returns></returns>
        public static int InsertProduct(DbProductIn dbprIn)
        {
            int insert = 0;
            SqlConnection conn = null;

            try
            {
                string sql = "Insert into tbProduct (id,idGroupProduct, name, unit, unitPrice, description, img) Values (@id,@idgr, @name, @unit , @unitPrice , @description, @img)";
                conn = ConnectSql.GetConnect();
                conn.Open();

                long id = ConnectSql.CreateId();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@idgr", dbprIn.IdGroup);
                command.Parameters.AddWithValue("@name", dbprIn.Name);
                command.Parameters.AddWithValue("@unit", dbprIn.Unit);
                command.Parameters.AddWithValue("@unitPrice", dbprIn.UnitPrice);
                command.Parameters.AddWithValue("@description", dbprIn.Description);
                command.Parameters.AddWithValue("@img", dbprIn.Img);
                
                insert = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;          
            }

        TheEnd:
            return insert;
        }

        public static int UpdateProduct(DbProductIn dbprIn)
        {
            int insert = 0;
            SqlConnection conn = null;

            try
            {
                string sql = "Update tbProduct " +
                    "Set idGroupProduct = @idgr, " +
                    "name = @name, unit = @unit, " +
                    "unitPrice = @unitPrice, " +
                    "description = @description, img = @img " +
                    "Where id = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                
                command.Parameters.AddWithValue("@idgr", dbprIn.IdGroup);
                command.Parameters.AddWithValue("@name", dbprIn.Name);
                command.Parameters.AddWithValue("@unit", dbprIn.Unit);
                command.Parameters.AddWithValue("@unitPrice", dbprIn.UnitPrice);
                command.Parameters.AddWithValue("@description", dbprIn.Description);
                command.Parameters.AddWithValue("@img", dbprIn.Img);
                command.Parameters.AddWithValue("@id", dbprIn.Id);

                insert = command.ExecuteNonQuery();
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

        public static List<DbProductOut> GetAllProduct()
        {
            List<DbProductOut> dbproductOuts = null;
            SqlConnection conn = null;
            try
            {
                string sql = "Select * from tbProduct";
                conn = ConnectSql.GetConnect();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                DbProductOut dbProductOut = null;
                dbproductOuts = new List<DbProductOut>();
                while (rdr.Read() != false)
                {
                    dbProductOut = new DbProductOut();
                    dbProductOut.Id = (long)rdr["id"];
                    dbProductOut.IdGroup = (long)rdr["idGroupProduct"];
                    dbProductOut.Name = (string)rdr["name"];
                    dbProductOut.Unit = (string)rdr["unit"];
                    dbProductOut.UnitPrice = (double)rdr["unitPrice"];
                    dbProductOut.Description = Common.GetDbNull<string>(rdr, "description");
                    dbProductOut.Img = Common.GetDbNull<byte[]>(rdr, "img");
                    dbproductOuts.Add(dbProductOut);
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
            return dbproductOuts;
        }

        public static List<DbProductOut> GetAllProductSearch( string search)
        {
            List<DbProductOut> dbproductOuts = null;
            SqlConnection conn = null;
            try
            {
                string sql = "Select * from tbProduct " +
                    "Where id like '%"+search+ "' " +
                    "Or idGroupProduct like '%" + search + "%' " +
                    "Or name like N'%" + search + "%' " +
                    "Or unit like N'%" + search + "%' " +
                    "Or unitPrice like '%" + search + "%' " +
                    "Or description like N'%" + search + "%' ";
                conn = ConnectSql.GetConnect();
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                DbProductOut dbProductOut = null;
                dbproductOuts = new List<DbProductOut>();
                while (rdr.Read() != false)
                {
                    dbProductOut = new DbProductOut();
                    dbProductOut.Id = (long)rdr["id"];
                    dbProductOut.IdGroup = (long)rdr["idGroupProduct"];
                    dbProductOut.Name = (string)rdr["name"];
                    dbProductOut.Unit = (string)rdr["unit"];
                    dbProductOut.UnitPrice = (double)rdr["unitPrice"];
                    dbProductOut.Description = Common.GetDbNull<string>(rdr, "description");
                    dbProductOut.Img = Common.GetDbNull<byte[]>(rdr, "img");
                    dbproductOuts.Add(dbProductOut);
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
            return dbproductOuts;
        }

        public static DataTable GetAllGroupProduct()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                string sql = "Select * from tbGroupProduct";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
            }

            return dt;
        }

        public static DataTable GetAllGroupProductSearch(string search)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable();
                string sql = "Select * from tbGroupProduct " +
                    "Where idGr like '%"+search+"%' Or nameGr like N'%"+search+ "%' Or descriptionGr like N'%" + search + "%'";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
            }

            return dt;
        }

        public static DataTable GetProductForSearch(long idGroup, string nameProduct)
        {
            DataTable dt = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select * from tbProduct ").Append(" ");
                sql.Append("Where idGroupProduct = "+idGroup+" ").Append(" ");
                sql.Append("And name like N'%"+ nameProduct + "%' ").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conn);
                dt = new DataTable();
                adapter.Fill(dt);
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

        public static int DelProduct(long id)
        {
            int del = 0;

            try
            {
                string sql = "Delete From tbProduct Where id = " + id + "";
                del = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                del = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }

        public static int DelGroupProduct(long id)
        {
            int del = 0;

            try
            {
                string sql = "Delete From tbGroupProduct Where idGr = " + id + "";
                del = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                del = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }

        public static int UpdateGroupProduct(long id, string name, string des)
        {
            int insert = 0;
            SqlConnection conn = null;

            try
            {
                string sql = "Update tbGroupProduct " +
                    "Set nameGr = @name, " +
                    "descriptionGr = @description " +
                    "Where idGr = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", des);
                command.Parameters.AddWithValue("@id", id);

                insert = command.ExecuteNonQuery();
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

        public static int InsertGroupProduct(string name, string des)
        {
            int insert = 0;
            SqlConnection conn = null;

            try
            {
                string sql = "Insert into tbGroupProduct (idGr, nameGr, descriptionGr) Values (@id, @name, @description)";
                conn = ConnectSql.GetConnect();
                conn.Open();

                long id = ConnectSql.CreateId();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", des);

                insert = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;              
            }

        TheEnd:
            return insert;
        }

        public static string CheckDoubleName(string nameAdd)
        {
            string nameCheck = "";
            try
            {
                string sql = "Select * From tbProduct Where name = N'" + nameAdd + "' ";
                DataTable dt = ConnectSql.ExecQuerySql(sql);
                if (dt == null)
                {
                    _message = ERROR_ENTRIEVING_DATA;
                    goto TheEnd;
                }    

                if (dt.Rows.Count < 1)
                {
                    goto TheEnd;
                }

                nameCheck = SHOW_ALREADY_EXIST;
            }
            catch (Exception ex)
            {
                nameCheck = "";
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return nameCheck;
        }

        public static string CheckDoubleNameByID(string nameAdd, long id)
        {
            string nameCheck = "";
            try
            {
                string sql = "Select * From tbProduct Where name = N'" + nameAdd + "' And id <> "+id+" ";
                DataTable dt = ConnectSql.ExecQuerySql(sql);
                if (dt == null)
                {
                    _message = ERROR_ENTRIEVING_DATA;
                    goto TheEnd;
                }

                if (dt.Rows.Count < 1)
                {
                    goto TheEnd;
                }

                nameCheck = SHOW_ALREADY_EXIST;
            }
            catch (Exception ex)
            {
                nameCheck = "";
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return nameCheck;
        }
        public static string Message
        {
            set { _message = value; }
            get { return _message; }
        }
    }
}
