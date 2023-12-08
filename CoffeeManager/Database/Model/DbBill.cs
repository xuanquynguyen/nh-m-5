using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbBill
    {
        private string _message = "";
        public  long SaveBill(DbBillIn dbBillIn)
        {
            long insertBill = 0;
            SqlConnection conn = null;

            try
            {
                string sql = "Insert Into tbBill (id, idTable, billDate, totalMoney, status, description, idUser, idCustomer)" +
                    "Values (@id, @idTable, @date, @money, @status, @description, @user, @customer)";

                conn = ConnectSql.GetConnect();
                conn.Open();

                long id = ConnectSql.CreateId();
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@idTable", dbBillIn.IdTable);
                command.Parameters.AddWithValue("@date", dbBillIn.Date);
                command.Parameters.AddWithValue("@money", dbBillIn.TotalMoney);
                command.Parameters.AddWithValue("@status", dbBillIn.Status);
                command.Parameters.AddWithValue("@description", dbBillIn.Description);
                command.Parameters.AddWithValue("@user", dbBillIn.IdUser);
                command.Parameters.AddWithValue("@customer", dbBillIn.IdCustomer);
                insertBill = command.ExecuteNonQuery();

                insertBill = id;
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return insertBill;
        }

        public  int UpdateBill(DbBillIn dbBillIn)
        {
            int insertBill = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Update tbBill Set id = @id, idTable = @idTable, billDate = @date, totalMoney = @money, status = @stasus, description = @description";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", dbBillIn.Id);
                command.Parameters.AddWithValue("@idTable", dbBillIn.IdTable);
                command.Parameters.AddWithValue("@date", dbBillIn.Date);
                command.Parameters.AddWithValue("@money", dbBillIn.TotalMoney);
                command.Parameters.AddWithValue("@status", dbBillIn.Status);
                command.Parameters.AddWithValue("@description", dbBillIn.Description);
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

        /// <summary>
        /// <para>Cập nhật tổng tiền hóa đơn</para>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totalMoney"></param>
        /// <returns></returns>
        public  int UpdateTotalMoneyBill(long id, double totalMoney)
        {
            int insertBill = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Update tbBill Set totalMoney = @total where id = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@total", totalMoney);
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

        /// <summary>
        /// <para>Cập nhật trạng thái</para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  int UpdateStatusBill(long id)
        {
            int insertBill = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Update tbBill Set status = 'true' where id = @id";

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

        
        private  DataTable GetBillDetailtByIdBillAndIdPr(long idBill, long idProduct)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select * from tbBillDetailt").Append(" ");
                sql.Append(" where idBill = " + idBill + " ").Append(" ");
                sql.Append(" and idProduct = " + idProduct + " ").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conn);
                dt = new DataTable();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dt;
        }

        public  long SaveBillDetailt(DbBillDetailtIn dbBillIn)
        {
            long insertBill = 0;
            SqlConnection conn = null;
            try
            {
                conn = ConnectSql.GetConnect();
                conn.Open();

                string sql = "";
                SqlCommand command = null;
                DataTable dt = GetBillDetailtByIdBillAndIdPr(dbBillIn.IdBill, dbBillIn.IdProduct);
                if (dt.Rows.Count > 0)
                {
                    sql = "Update tbBillDetailt " +
                    "Set quantity = quantity + @quantity, intoMoney = (quantity + @quantity)*unitPrice " +
                    "where idBill = @idBill and idProduct = @idProduct";

                    command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@quantity", dbBillIn.Quantity);
                    command.Parameters.AddWithValue("@idBill", dbBillIn.IdBill);
                    command.Parameters.AddWithValue("@idProduct", dbBillIn.IdProduct);
                    insertBill = command.ExecuteNonQuery();

                    goto TheEnd;
                }    

                sql = "Insert Into tbBillDetailt (id, unitPrice, quantity, idBill, idProduct, intoMoney, description)" +
                    "Values (@id, @unitPrice,@quantity, @idBill, @idProduct,  @intoMoney, @description)";

                long id = ConnectSql.CreateId();
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@unitPrice", dbBillIn.UnitPrice);
                command.Parameters.AddWithValue("@quantity", dbBillIn.Quantity);
                command.Parameters.AddWithValue("@idBill", dbBillIn.IdBill);
                command.Parameters.AddWithValue("@idProduct", dbBillIn.IdProduct);               
                command.Parameters.AddWithValue("@intoMoney", dbBillIn.IntoMoney);
                command.Parameters.AddWithValue("@description", dbBillIn.Description);
                insertBill = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return insertBill;
        }

        public  DataTable InsertBillDetailt(DataTable dtIn)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            try
            {
                conn = ConnectSql.GetConnect();
                conn.Open();
                dtIn.TableName = "tbBillDetailt";

                SqlBulkCopy bulkcopy = new SqlBulkCopy(conn);
                bulkcopy.DestinationTableName = dtIn.TableName;
                bulkcopy.WriteToServer(dtIn);
                //using (SqlCommand command = new SqlCommand("sp_InsertTable", conn){CommandType = CommandType.StoredProcedure })
                //{                  
                   
                //    command.Parameters.Add(new SqlParameter("@forBillDetailt1", dtIn));
                //    command.ExecuteNonQuery();
                //}

                dt = new DataTable();
                dt = dtIn;
            }
            catch (Exception ex)
            {
                dt = null;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dt;
        }

        public  DataTable GetAllBillDetailt(long idTable)
        {
            DataTable dt = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select tbpr.name as [drink], tbbd.*").Append(" ");
                sql.Append("from tbBillDetailt tbbd ").Append(" ");
                sql.Append("inner join tbBill tbb On tbbd.idBill = tbb.id  ").Append(" ");
                sql.Append("inner join tbProduct tbpr on tbbd.idProduct = tbpr.id").Append(" ");
                sql.Append("inner join tbTable tbtb on tbb.idTable = tbtb.id").Append(" ");
                sql.Append("where tbb.idTable = "+idTable+"").Append(" ");
                sql.Append("and tbb.status = 'false'").Append(" ");
                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conn);
                dt = new DataTable();
                adapter.Fill(dt);   
                if (dt == null)
                {
                    _message = ERROR_LOAD_DATA_BILL;
                    goto TheEnd;
                }    
            }
            catch (Exception ex)
            {
                dt = null;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dt;
        }

        public  DataTable GetAllBillDetailtByIdCustomer(long idcustomer)
        {
            DataTable dt = null;
            SqlConnection conn = null;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select tbpr.name as [drink], tbbd.*").Append(" ");
                sql.Append("from tbBillDetailt tbbd ").Append(" ");
                sql.Append("inner join tbBill tbb On tbbd.idBill = tbb.id  ").Append(" ");
                sql.Append("inner join tbProduct tbpr on tbbd.idProduct = tbpr.id").Append(" ");
                sql.Append("inner join tbCustomer tbtb on tbb.idCustomer = tbtb.id").Append(" ");
                sql.Append("where tbb.idCustomer = " + idcustomer + "").Append(" ");
                sql.Append("and tbb.status = 'false'").Append(" ");
                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conn);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt == null)
                {
                    _message = ERROR_LOAD_DATA_BILL;
                    goto TheEnd;
                }    
            }
            catch (Exception ex)
            {
                dt = null;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dt;
        }

        public  int UpdateNumberBillDetailt(int quantity, string des, long idBillDetailt)
        {
            int update = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Update tbBillDetailt " +
                    "Set quantity = @quantity, " +
                    "intoMoney = (@quantity*UnitPrice), " +
                    "description = @des " +
                    "where id = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@des", des);
                command.Parameters.AddWithValue("@id", idBillDetailt);
                update = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return update;
        }

        /// <summary>
        /// <para>Update Số lượng khi gộp bàn</para>
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="idBillDetailt"></param>
        /// <returns></returns>
        public int UpdateNumBillDetailt(int quantity, long idBillDetailt)
        {
            int update = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Update tbBillDetailt " +
                    "Set quantity = @quantity, " +
                    "intoMoney = (@quantity*UnitPrice), " +
                    "description = @des " +
                    "where id = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@id", idBillDetailt);
                update = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return update;
        }

        public  int DelNumberBillDetailt(long idBillDetailt)
        {
            int update = 0;
            SqlConnection conn = null;
            try
            {
                string sql = "Delete from tbBillDetailt where id = @id";

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", idBillDetailt);
                update = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return update;
        }

        public  DataTable PrintBil(long idBill)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select tbdt.*, tbl.nameTb,prd.name as ProductName, cus.name, emp.fullName, tbb.billDate, cus.phone").Append(" ");
                sql.Append("from dbo.tbBill tbb inner join dbo.tbBillDetailt tbdt").Append(" ");
                sql.Append("on tbb.id = tbdt.idBill").Append(" ");
                sql.Append("left join Employees emp").Append(" ");
                sql.Append("on tbb.idUser = emp.id").Append(" ");
                sql.Append("left join tbCustomer cus").Append(" ");
                sql.Append("on tbb.idCustomer = cus.id").Append(" ");
                sql.Append("left join tbTable tbl").Append(" ");
                sql.Append("on tbb.idTable = tbl.id").Append(" ");
                sql.Append("inner join tbProduct prd").Append(" ");
                sql.Append("on tbdt.idProduct = prd.id").Append(" ");
                sql.Append("where tbb.id = "+idBill+" ").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql.ToString(), conn);
                dt = new DataTable();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                goto TheEnd;
                throw ex;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dt;
        }   
        
        /// <summary>
        /// <para>Xóa bill</para>
        /// </summary>
        /// <param name="idBill"></param>
        /// <returns></returns>
        public  int DelBill(long idBill)
        {
            int del = 0;

            try
            {
                string sql = "Delete from tbBill Where id = " + idBill + " ";
                del = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return del;
        }

        /// <summary>
        /// <para>Cập nhật lại số tiền khi gộp bàn</para>
        /// </summary>
        /// <param name="idBill"></param>
        /// <returns></returns>
        public  int UpdateMoney(long idBill)
        {
            int up = 0;
            try
            {
                string sql = "Update tbBill Set totalMoney = (select sum(intoMoney) from tbBillDetailt where idBill = " + idBill + ") where idBill = " + idBill + " ";
                up = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return up;
        }

        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }

    }
}
