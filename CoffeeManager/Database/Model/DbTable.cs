using System;
using System.Data;
using System.Text;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbTable
    {
        private string _message = "";

        public int InsertTb(string name, string des, long idGr)
        {
            int Res;
            try
            {
                string id = DateTime.Now.ToString("yyyyMMddhhmmssff");
                string sql = "Insert into tbTable Values (" + id + ", N'" + name + "', N'" + des + "',"+idGr+" , 0)";
                Res = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                Res = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return Res;
        }

        /// <summary>
        /// <para>Check Exist name table</para>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable CheckExistNameTable(string name, long areaId)
        {
            DataTable dt = null;
            try
            {
                string sql = "Select * from tbTable Where nameTb = N'"+name+ "' And idGroup = "+areaId+" ";
                dt = new DataTable();
                dt = ConnectSql.ExecQuerySql(sql);
                if (dt == null)
                {
                    _message = ERROR_ACCESS_DATA;
                    goto TheEnd;
                }    

                if (dt.Rows.Count > 0)
                {
                    _message = ERROR_EXISTS_NAME;
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

        public DataTable CheckExistNameTable(string name, long idTb, long areaId)
        {
            DataTable dt = null;
            try
            {
                string sql = "Select * from tbTable Where nameTb = N'" + name + "' And idGroup = " + areaId + " And id <> "+idTb+" ";
                dt = new DataTable();
                dt = ConnectSql.ExecQuerySql(sql);
                if (dt == null)
                {
                    _message = ERROR_ACCESS_DATA;
                    goto TheEnd;
                }

                if (dt.Rows.Count > 0)
                {
                    _message = ERROR_EXISTS_NAME;
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

        public int UpdateStatusTable(long id)
        {
            int status;
            try
            {
                string sql = "Update tbTable Set status = 'true' Where id = "+id+" ";
                status = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                status = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return status;
        }

        public int UpdateStatusTableToFalse(long id)
        {
            int status = 0;
            try
            {
                string sql = "Update tbTable Set status = 'false' Where id = " + id + " ";
                status = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                status = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return status;
        }

        public int UpdateTable(string name, string des, long idGr, long id)
        {
            int status = 0;
            try
            {
                string sql = "Update tbTable " +
                    " Set nameTb = '"+name+ "', " +
                    " description = '"+des+ "', " +
                    " idGroup = "+idGr+" " +
                    " Where id = " + id + " ";
                status = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                status = 0;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return status;
        }

        public  DataTable GetAllGroupTable()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from tbGroupTb order by name asc";
                dt = ConnectSql.ExecQuerySql(sql);
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

        public  DataTable GetAllTable(int mode, long id)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select tb.*").Append(" ");
                sql.Append("from tbTable as tb").Append(" ");
                sql.Append("where tb.status = 'false'").Append(" ");

                if (mode != 1)
                {
                    sql.Append("and tb.idGroup = " + id + "").Append(" ");
                }    
                
                dt = ConnectSql.ExecQuerySql(sql.ToString());
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

        public  DataTable GetAllTableBusy(int mode, long id)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select tb.*").Append(" ");
                sql.Append("from tbTable as tb").Append(" ");
                sql.Append("where tb.status = 'true'").Append(" ");

                if (mode != 1)
                {
                    sql.Append("and tb.idGroup = " + id + "").Append(" ");
                }

                dt = ConnectSql.ExecQuerySql(sql.ToString());
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

        public DataTable GetAllTableBusyNoId()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select tb.* from tbTable as tb where tb.status = 'true'";
                dt = ConnectSql.ExecQuerySql(sql);
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

        public DataTable GetAllGroupProduct()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from tbGroupProduct";
                dt = ConnectSql.ExecQuerySql(sql);
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

        public DataTable GetAllProduct(long id)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from tbProduct where idGroupProduct = "+id+"";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                dt = null;
                _message = ex.Message; ;
                goto TheEnd;
            }

        TheEnd:
            return dt;
        }

        public DataTable GetAllTableNew()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select tb.id as idTb, tb.nameTb, tb.description as descriptionTb, tb.idGroup as idgr, tb.status, gr.name as nameGr " +
                    " from tbTable as tb Inner join tbGroupTb as gr " +
                    " On tb.idGroup = gr.id";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                dt = null;
                _message = ex.Message; ;
                goto TheEnd;
            }

        TheEnd:
            return dt;
        }

        public DataTable SearchGroupTb(string search)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "Select * from tbGroupTb " +
                    " Where id like '%"+search+"%' " +
                    " Or name like N'%"+search+"%' " +
                    " Or description like N'%"+search+"%' ";
                dt = ConnectSql.ExecQuerySql(sql);
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

        public DataTable SearchTbTable(string search)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select tb.id as idTb, tb.nameTb, tb.description as descriptionTb, tb.idGroup as idgr, tb.status, gr.name as nameGr " +
                    " from tbTable as tb Inner join tbGroupTb as gr " +
                    " On tb.idGroup = gr.id " +
                    " Where tb.id like '%"+search+"%' Or tb.nameTb like N'%"+search+"%' Or tb.description like N'%"+search+"%' Or gr.name like N'%"+search+"%' ";
                dt = ConnectSql.ExecQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return dt;
        }

        public bool DelTable(long id)
        {
            bool del = false;
            try
            {
                string sql = "Delete from tbTable Where id = " + id + " ";
                ConnectSql.ExecNonQuerySql(sql);
                del = true;
            }
            catch (Exception ex)
            {
                del = false;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }

        public bool DelGrTable(long id)
        {
            bool del = false;
            try
            {
                string sql = "Delete from tbGroupTb Where id = " + id + " ";
                ConnectSql.ExecNonQuerySql(sql);
                del = true;
            }
            catch (Exception ex)
            {
                del = false;
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return del;
        }

        public long InsertGroupTb(string name, string des)
        {
            long ins = 0;
            try
            {
                long id = ConnectSql.CreateId();
                string sql = "Insert into tbGroupTb (id, name, description) Values (" + id + ", N'" + name + "', N'" + des + "') ";
                ConnectSql.ExecNonQuerySql(sql);
                ins = id;
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return ins;
        }

        public int UpdateGroupTb(string name, string des, long id)
        {
            int ins = 0;
            try
            {
                string sql = "Update tbGroupTb Set name = N'" + name + "', description = N'" + des + "' Where id = " + id + " ";
                ins = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return ins;
        }

        /// <summary>
        /// <para>Cập nhật khi đổi bàn</para>
        /// </summary>
        /// <param name="idTableChange">id bàn để đổi</param>
        /// <param name="idBill">id Hóa đơn</param>
        /// <returns></returns>
        public int UpdateChangeTable(long idTableChange, long idBill)
        {
            int change = 0;
            try
            {
                string sql = "Update tbBill Set idTable = " + idTableChange + " Where id = "+idBill+" ";
                change = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return change;
        }

        /// <summary>
        /// <para>Update Trạng thái thành false (chưa sử dụng)</para>
        /// </summary>
        /// <param name="idNeedChange"></param>
        /// <returns></returns>
        public int UpdateStatusTableWhenChangeFalse(long idNeedChange)
        {
            int change = 0;
            try
            {
                string sql = "Update tbTable Set status = 'false' Where id = " + idNeedChange + " ";
                change = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                goto TheEnd;
                throw ex;
            }

        TheEnd:
            return change;
        }

        /// <summary>
        /// <para>Update trạng thái thành true (đang sử dụng)</para>
        /// </summary>
        /// <param name="idNeedChange"></param>
        /// <returns></returns>
        public int UpdateStatusTableWhenChangeTrue(long idToChange)
        {
            int change = 0;
            try
            {
                string sql = "Update tbTable Set status = 'true' Where id = " + idToChange + " ";
                change = ConnectSql.ExecNonQuerySql(sql);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return change;
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
