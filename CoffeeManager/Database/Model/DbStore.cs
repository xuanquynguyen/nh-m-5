using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbStore
    {
        private static string _message = "";

        public static DataTable GetInfoStore()
        {
            DataTable dt = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Select *").Append(" ");
                sql.Append("From tbStore").Append(" ");
                dt = ConnectSql.ExecQuerySql(sql.ToString());
                if(dt == null)
                {
                    _message = ERROR_ENTRIEVING_DATA;
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

        public static int UpdateStore(DbStoreOut dbStore)
        {
            int update = 0;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("Update tbStore").Append(" ");
                sql.Append("Set nameStore = @name,").Append(" ");
                sql.Append("addressStore = @adress,").Append(" ");
                sql.Append("phoneStore = @phone,").Append(" ");
                sql.Append("taxCode = @code").Append(" ");
                sql.Append("Where id = @id").Append(" ");

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                command.Parameters.AddWithValue("@id", dbStore.Id);
                command.Parameters.AddWithValue("@name", dbStore.NameStore);
                command.Parameters.AddWithValue("@adress", dbStore.AddressStore);
                command.Parameters.AddWithValue("@phone", dbStore.PhoneStore);
                command.Parameters.AddWithValue("@code", dbStore.TaxCode);

                update = command.ExecuteNonQuery();
                if (update < 1)
                {
                    _message = ERROR_ENTRIEVING_DATA;
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
            return update;
        }

        public static string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
