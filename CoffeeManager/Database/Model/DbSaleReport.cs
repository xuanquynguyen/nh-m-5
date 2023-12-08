using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using static CoffeeManager.Properties.Resource;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class DbSaleReport
    {
        public string _message = "";
        private string _infoStore = "";
        private string _setTime = "";
        private DataTable _dataForRs = null;

        public DbSaleReport(string infoStore, string setTime, DataTable dt)
        {
            _infoStore = infoStore;
            _setTime = setTime;
            _dataForRs = new DataTable();
            _dataForRs = dt;
        }

        public DbSaleReport()
        {

        }

        /// <summary>
        /// <para>Lấy báo cáo theo ngày hiện tại</para>
        /// </summary>
        /// <returns></returns>
        public List<DbSaleReportOut> GetBillNow(int mode, string search, DateTime dateFrom, DateTime dateTo)
        {
            List<DbSaleReportOut> dbSaleReports = null;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT bi.id, tb.nameTb,").Append(" ");
                sql.Append("	cus.name as nameCus,").Append(" ");
                sql.Append("	pr.name, ems.fullName,").Append(" ");
                sql.Append("	bi.billDate,").Append(" ");
                sql.Append("	bidt.unitPrice,").Append(" ");
                sql.Append("	bidt.quantity,").Append(" ");
                sql.Append("	bidt.intoMoney").Append(" ");
                sql.Append("FROM").Append(" ");
                sql.Append("	dbo.tbBill bi INNER JOIN").Append(" ");
                sql.Append("	dbo.tbBillDetailt bidt ON bi.id = bidt.idBill Left JOIN").Append(" ");
                sql.Append("	dbo.tbTable tb ON bi.idTable = tb.id Left JOIN").Append(" ");
                sql.Append("	dbo.tbCustomer cus ON bi.idCustomer = cus.id Left JOIN").Append(" ");
                sql.Append("	dbo.Employees ems  ON bi.idUser = ems.id  INNER JOIN").Append(" ");
                sql.Append("	dbo.tbProduct pr ON bidt.idProduct = pr.id").Append(" ");
                sql.Append("WHERE").Append(" ");
                if (mode == 0)
                {
                    sql.Append("	CONVERT(date, bi.billDate) = CAST(GETDATE() as DATE)").Append(" ");
                }

                // Ngày cụ thể
                if (mode == 1)
                {
                    sql.Append("	CONVERT(date, bi.billDate) = '" + dateFrom+"'").Append(" ");
                }

                // Từ ngày đến ngày
                if (mode == 2)
                {
                    sql.Append("	(CONVERT(date, bi.billDate) Between '" + dateFrom + "' and '" + dateTo + "' )").Append(" ");
                }

                // Năm cụ thể
                if (mode == 3)
                {
                    sql.Append("	year(bi.billDate) =  YEAR( '" + dateFrom + "')").Append(" ");
                }

                // Từ năm đến năm
                if (mode == 4)
                {
                    sql.Append("	year(bi.billDate) Between  YEAR( '" + dateFrom + "') And YEAR( '" + dateTo + "')").Append(" ");
                }

                if (search.Length > 0)
                {
                    sql.Append("AND (tb.nameTb like N'%"+search+"%' ").Append(" ");
                    sql.Append("OR cus.name like N'%" + search+"%' ").Append(" ");
                    sql.Append("OR pr.name like N'%" + search+"%' ").Append(" ");
                    sql.Append("OR ems.fullName like N'%" + search+"%' )").Append(" ");
                }    

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                dbSaleReports = new List<DbSaleReportOut>();
                DbSaleReportOut dbSaleReport = null;
                while (rdr.Read() != false)
                {
                    dbSaleReport = new DbSaleReportOut();
                    dbSaleReport.NameTb = Common.GetDbNull<string>(rdr, "nameTb");
                    dbSaleReport.IdBill = Common.GetDbNull<long>(rdr, "id");
                    dbSaleReport.NameCus = Common.GetDbNull<string>(rdr, "nameCus");
                    dbSaleReport.Name = Common.GetDbNull<string>(rdr, "name");
                    dbSaleReport.FullName = Common.GetDbNull<string>(rdr, "fullName");
                    dbSaleReport.BillDate = Common.GetDbNull<DateTime>(rdr, "billDate");
                    dbSaleReport.UnitPrice = Common.GetDbNull<double>(rdr, "unitPrice");
                    dbSaleReport.Quantity = Common.GetDbNull<int>(rdr, "quantity");
                    dbSaleReport.IntoMoney = Common.GetDbNull<double>(rdr, "intoMoney");

                    dbSaleReports.Add(dbSaleReport);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                dbSaleReports = null;
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ConnectSql.CloseConnect(conn);
            }

        TheEnd:
            return dbSaleReports;
        }    

        /// <summary>
        /// <para>Xuất report</para>
        /// <para>- Xuất file pdf vào directory chỉ định</para>
        /// <para>- Nếu đã có file thì ghi đè</para>
        /// <para>- Nếu inputDatas là null hoặc rỗng thì chỉ xuất file từ resource</para>
        /// </summary>
        /// <param name="directory">Đường dẫn lưu file</param>
        /// <param name="inputDatas">Dữ liệu xuất vào</param>
        /// <returns>false : thất bại</returns>
        public bool Export(string directory, object[,] inputDatas)
        {
            bool isSuccess = false;

            try
            {
                LocalReport localReport = new LocalReport();
                localReport.ReportEmbeddedResource =
                                    "CoffeeManager.ReportTemplate.SalesReport.rdlc";

                // Tạo bảng tiêu đề
                DataTable dtTitle = new DataTable();
                string fullName = FrmMain.UserFullName;
                string dateExport = DateTime.Now.ToString("dd/MM/yyyy");
                dtTitle.Columns.Add("CompanyInfo", typeof(string));
                dtTitle.Columns.Add("ReportTime", typeof(string));
                dtTitle.Columns.Add("DateExport", typeof(string));
                dtTitle.Columns.Add("UserExport", typeof(string));
                // dtTitle.Columns.Add("MoneyUnit");

                // Thêm dữ liệu phần tiêu đề vào report
                dtTitle.Rows.Add(_infoStore, _setTime, dateExport, fullName);

                // Tạo bảng chứa data
                DataTable dtData = new DataTable();
                dtData.Columns.Add("idBill", typeof(Int64));
                dtData.Columns.Add("ColNameTb", typeof(string));
                dtData.Columns.Add("ColCusName", typeof(string));
                dtData.Columns.Add("drink", typeof(string));
                dtData.Columns.Add("ColFullName", typeof(string));
                dtData.Columns.Add("ColDate", typeof(DateTime));
                dtData.Columns.Add("unitPrice", typeof(decimal));
                dtData.Columns.Add("quantity", typeof(Int16));
                dtData.Columns.Add("intoMoney", typeof(decimal));

                // Thêm data vào bảng
                int rowCount = inputDatas?.GetLength(0) ?? 0;
                int colCount = inputDatas?.GetLength(1) ?? 0;
                for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
                {
                    object[] dataRow = new object[colCount];
                    for (int colIdx = 0; colIdx < colCount; colIdx++)
                    {
                        dataRow[colIdx] = inputDatas[rowIdx, colIdx];
                    }

                    dtData.Rows.Add(dataRow);
                }

                // Thêm datasource tiêu đề
                ReportDataSource reportDataSource =
                                        new ReportDataSource("DsTitle", dtTitle);
                localReport.DataSources.Add(reportDataSource);

                // Thêm datasource dữ liệu
                reportDataSource = new ReportDataSource("DsDataSales", dtData);
                localReport.DataSources.Add(reportDataSource);

                // Xuất ra pdf file
                string filePath = directory + @"\" + REPORT_SALE_REPORT_TITLE + ".pdf";
                var deviceInfo = @"<DeviceInfo>
                    <EmbedFonts>None</EmbedFonts>
                   </DeviceInfo>";
                Byte[] pdfByte = localReport.Render("PDF", deviceInfo);
                File.WriteAllBytes(filePath, pdfByte);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return isSuccess;
        }

        public DataTable GetBillForChart(int mode, DateTime getMonth, DateTime getYear)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select Day(billDate) as billDate,").Append(" ");
                sql.Append("sum(totalMoney) as totalMoney").Append(" ");
                sql.Append("from tbBill").Append(" ");
                sql.Append("where (MONTH(billDate) = MONTH('"+ getMonth + "')").Append(" ");
                sql.Append("and year(billDate) = year('"+ getYear + "'))").Append(" ");
                sql.Append("GROUP BY Day(billDate)").Append(" ");

                if (mode == 1)
                {
                    sql.Clear();
                    sql.Append("select month(billDate) as billDate,").Append(" ");
                    sql.Append("sum(totalMoney) as totalMoney").Append(" ");
                    sql.Append("from tbBill").Append(" ");
                    sql.Append("where year(billDate) = YEAR('"+ getYear + "')").Append(" ");
                    sql.Append("GROUP BY month(billDate)").Append(" ");
                }

                if (mode == 2)
                {
                    sql.Clear();
                    sql.Append("select year(billDate) as billDate,").Append(" ");
                    sql.Append("sum(totalMoney) as totalMoney").Append(" ");
                    sql.Append("from tbBill").Append(" ");
                    sql.Append("GROUP BY year(billDate)").Append(" ");
                }

                conn = ConnectSql.GetConnect();
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt == null)
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

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
