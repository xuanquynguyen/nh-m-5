using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.IO;
using System.Data;
using static CoffeeManager.Properties.Resource;
using static CoffeeManager.Properties.Resources;
using System.ComponentModel;

namespace CoffeeManager
{
    public partial class FrmSaleReport : Form
    {
        private DateTime _dateFrom = DateTime.Now;
        //private DateTime _dateTo = DateTime.Now.AddDays(1);
        private DateTime _dateTo = DateTime.Now;
        private double _totalMoney = 0;
        private int _modeSearch = 0;
        private FrmWait _frmWait = null;
        private string _plusTime = "";
        private DataTable _dataForReport = new DataTable();
        private string _infoStore = "";
        private DbSaleReport _dbSaleReport = null;
        public FrmSaleReport()
        {
            InitializeComponent();
            _dbSaleReport = new DbSaleReport();
        }

        private void FrmSaleReport_Load(object sender, EventArgs e)
        {
            try
            {
                CbbChoseStyle.SelectedIndex = 0;
                GrbDateTime.Enabled = false;
                DgvMain.RowsDefaultCellStyle.BackColor = Color.Bisque;
                DgvMain.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.Beige;
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void SetEnableControl()
        {
            string fromDate = DtpDayFrom.Value.Day + "/" + DtpMonthFrom.Value.Month + "/" + DtpYearFrom.Value.Year;
            string toDate = dtpDayTo.Value.Day + "/" + DtpMonthTo.Value.Month + "/" + DtpYearTo.Value.Year;
            switch (CbbChoseStyle.SelectedIndex)
            {
                case 0: // Hôm nay
                    GrbDateTime.Enabled = false;
                    _modeSearch = 0;
                    _plusTime = SHOW_DAY + DateTime.Now.ToString("dd/MM/yyyy");
                    break;

                case 1: // Ngày...Tháng...Năm
                    GrbDateTime.Enabled = true;
                    DtpDayFrom.Enabled = true;
                    DtpMonthFrom.Enabled = true;
                    DtpYearFrom.Enabled = true;

                    dtpDayTo.Enabled    = false;
                    DtpMonthTo.Enabled  = false;
                    DtpYearTo.Enabled   = false;
                    _modeSearch = 1;
                    //_plusTime = "Ngày " + _dateFrom.ToString("dd/MM/yyyy");
                    _plusTime = SHOW_DAY + fromDate;
                    break;

                case 2: // Từ ngày... đến ngày...
                    GrbDateTime.Enabled = true;
                    DtpDayFrom.Enabled = true;
                    DtpMonthFrom.Enabled = true;
                    DtpYearFrom.Enabled = true;

                    dtpDayTo.Enabled = true;
                    DtpMonthTo.Enabled = true;
                    DtpYearTo.Enabled = true;
                    _modeSearch = 2;
                    _plusTime = SHOW_DAY + fromDate + SHOW_TO_DAY  + toDate;
                    break;

                case 3: // Năm
                    GrbDateTime.Enabled = true;
                    DtpDayFrom.Enabled = false;
                    DtpMonthFrom.Enabled = false;
                    DtpYearFrom.Enabled = true;

                    dtpDayTo.Enabled = false;
                    DtpMonthTo.Enabled = false;
                    DtpYearTo.Enabled = false;
                    _modeSearch = 3;
                    _plusTime = SHOW_YEAR + DtpYearFrom.Value.Year;
                    break;

                case 4:  // Từ năm... Đến năm
                    GrbDateTime.Enabled = true;
                    DtpDayFrom.Enabled = false;
                    DtpMonthFrom.Enabled = false;
                    DtpYearFrom.Enabled = true;

                    dtpDayTo.Enabled = false;
                    DtpMonthTo.Enabled = false;
                    DtpYearTo.Enabled = true;
                    _plusTime = SHOW_FROM_YEAR + DtpYearFrom.Value.Year + SHOW_TO_YEAR + DtpYearTo.Value.Year;
                    _modeSearch = 4;
                    break;
            }    
        }

        private void CbbChoseStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CbbChoseStyle.SelectedIndex == 0)
                {
                    _modeSearch = 0;
                    GrbDateTime.Enabled = false;
                    string message = ShowData();
                    if (message.Length > 0)
                    {
                        MsgBox.ErrProcess(message);
                    }

                    goto TheEnd;
                }   
                
                SetEnableControl();
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private string ShowData()
        {
            string message = "";
            try
            {
                if (_modeSearch != 0 && _modeSearch != 3)
                {
                    int result = DateTime.Compare(_dateFrom, _dateTo);
                    if (result > 0)
                    {
                        lblShowErr.Text = ERROR_NOT_LESS_TIME;
                        goto TheEnd;
                    }
                }

                lblShowErr.Text = "";

                List<DbSaleReportOut> dbSaleReportOuts = new List<DbSaleReportOut>();
                dbSaleReportOuts = _dbSaleReport.GetBillNow(_modeSearch, TxtProduct.Text.Trim(), _dateFrom, _dateTo);
                if (dbSaleReportOuts == null)
                {
                    message = (DbEmployees.Message);
                    goto TheEnd;
                } 
                
                _totalMoney = 0;

                DgvMain.Rows.Clear();
                for (int rowIdx = 0; rowIdx < dbSaleReportOuts.Count; rowIdx++)
                {
                    DbSaleReportOut rowdt = dbSaleReportOuts[rowIdx];
                    DgvMain.Rows.Add();
                    DgvMain.Rows[rowIdx].Tag = rowdt;

                    DataGridViewRow row = DgvMain.Rows[rowIdx];

                    row.Cells["ColNameTb"].Value = rowdt.NameTb == null ? null : rowdt.NameTb;
                    row.Cells["ColCusName"].Value = rowdt.NameCus == null ? null : rowdt.NameCus;
                    row.Cells["drink"].Value = rowdt.Name;
                    row.Cells["ColFullName"].Value = rowdt.FullName;
                    row.Cells["ColDate"].Value = rowdt.BillDate;
                    row.Cells["unitPrice"].Value = rowdt.UnitPrice;
                    row.Cells["quantity"].Value = rowdt.Quantity;
                    row.Cells["intoMoney"].Value = rowdt.IntoMoney;
                    _totalMoney += rowdt.IntoMoney;
                    row.Cells["idBill"].Value = rowdt.IdBill;
                }

                TxtTotalMoney.Text = _totalMoney.ToString();
                _dataForReport = GetDataTableFromDGV(DgvMain);
                
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
        TheEnd:
            return message;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void DgvMain_Leave(object sender, EventArgs e)
        {
            DgvMain.ClearSelection();
        }

        private string getDayFrom()
        {
            string message = "";

            try
            {
                string day = DtpDayFrom.Value.Day.ToString();
                if (day.Length < 2)
                {
                    day = "0" + day;
                }  
                
                string month = DtpMonthFrom.Value.Month.ToString();
                if (month.Length < 2)
                {
                    month = "0" + month;
                }

                string year = DtpYearFrom.Value.Year.ToString();
                string dayFrom = day + "/" + month + "/" + year;
                _dateFrom = 
                DateTime.ParseExact(dayFrom, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);                                    
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private string getDayTo()
        {
            string message = "";

            try
            {
                string day = dtpDayTo.Value.Day.ToString();
                if (day.Length < 2)
                {
                    day = "0" + day;
                }

                string month = DtpMonthTo.Value.Month.ToString();
                if (month.Length < 2)
                {
                    month = "0" + month;
                }

                string year = DtpYearTo.Value.Year.ToString();
                string dayTo = day + "/" + month + "/" + year;
                _dateTo = DateTime.ParseExact(dayTo, "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

                //message = ShowData();
                //if (message.Length > 0)
                //{
                //    goto TheEnd;
                //}
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private void DtpDayFrom_ValueChanged(object sender, EventArgs e)
        {
            string message = getDayFrom();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
            }

            goto TheEnd;

        TheEnd:
            return;
        }

        private void DtpMonthFrom_ValueChanged(object sender, EventArgs e)
        {
            string message = getDayFrom();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
            }

            goto TheEnd;

        TheEnd:
            return;
        }

        private void DtpYearFrom_ValueChanged(object sender, EventArgs e)
        {
            string message = getDayFrom();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
            }

            goto TheEnd;

        TheEnd:
            return;
        }

        private void dtpDayTo_ValueChanged(object sender, EventArgs e)
        {
            string message = getDayTo();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
            }

            goto TheEnd;

        TheEnd:
            return;
        }

        private void DtpMonthTo_ValueChanged(object sender, EventArgs e)
        {
            string message = getDayTo();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
            }

            goto TheEnd;

        TheEnd:
            return;
        }

        private void DtpYearTo_ValueChanged(object sender, EventArgs e)
        {
            string message = getDayTo();
            if (message.Length > 0)
            {
                MsgBox.ErrProcess(message);
            }

            goto TheEnd;

        TheEnd:
            return;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TxtProduct.Clear();
                //string message = ShowData();
                //if (message.Length > 0)
                //{
                //    MsgBox.ErrProcess(message);
                //}
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private void DtpDayFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void DtpDayFrom_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void DtpMonthFrom_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void DtpYearFrom_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void dtpDayTo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void DtpMonthTo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void DtpYearTo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.CfmInfomation(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd: return;
        }

        private void TxtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string message = ShowData();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(message);
                    goto TheEnd;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        private object[,] createObjectArr()
        {
            object[,] cellValues = new object[DgvMain.Rows.Count, DgvMain.Columns.Count];
            int rows = 0;
            foreach (DataGridViewRow row in DgvMain.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[rows, i] = row.Cells[i].Value;
                }
                rows++;
            }

            return cellValues;
        }

        private void tlsbtnExportXls_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                string time = DateTime.Now.ToString("yyyyMMdd");
                save.FileName = SHOW_RP_SALES_PDF_NAME;
                save.Filter = SHOW_PDF_FILTER;
                if (save.ShowDialog() != DialogResult.OK)
                {
                    goto TheEnd;
                }

                SetEnableControl();
                StartProc();
                //Task task = new Task(delegate
                //{
                //    _frmWait = new FrmWait();
                //    _frmWait.SetTitle(SHOW_WAIT_EXPORT);
                //    _frmWait.ShowDialog();
                //});
                //task.Start();

                string path = Path.GetDirectoryName(save.FileName);
                int rowNum = _dataForReport.Rows.Count;
                int colNum = _dataForReport.Columns.Count;

                string message = GetInfoStore();
                if (message.Length > 0)
                {
                    MsgBox.ErrProcess(ERROR_GETTING_STORE_INFO);
                    goto TheEnd;
                }    

                DbSaleReport dbsale = new DbSaleReport(_infoStore, _plusTime, _dataForReport);
                object[,] data = createObjectArr();
                bool success = dbsale.Export(path, data);
                if (success == false)
                {
                    //_frmWait.BeginInvoke((Action)delegate
                    //{
                    //    _frmWait.Close();
                    //});
                    MsgBox.CfmInfomation(ERROR_EXPORTING_PDF);                   
                    goto TheEnd;
                }

                //_frmWait.BeginInvoke((Action)delegate
                //{
                //    _frmWait.Close();
                //});
                MsgBox.CfmInfomation(MSG_DONE);
                PrbWait.Value = 0;
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        BackgroundWorker mWorker;
        private void StartProc()
        {
            mWorker = new BackgroundWorker();
            mWorker.DoWork += new DoWorkEventHandler(worker_DoWork);
            mWorker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            mWorker.WorkerReportsProgress = true;
            mWorker.WorkerSupportsCancellation = true;
            mWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            mWorker.RunWorkerAsync();

        }

        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                mWorker.ReportProgress(i);

                // Do some part of the work
                System.Threading.Thread.Sleep(100);

                // Check if the user wants to abort
                if (mWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }

            mWorker.ReportProgress(100);  // Done
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PrbWait.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check the result
            if (e.Cancelled)
            {
                // show the message box that the task has been canceled
            }

            // Reset Progress bar
            PrbWait.Value = 100;
        }

        private string GetInfoStore()
        {
            string message = "";

            try
            {
                DataTable dt = DbStore.GetInfoStore();
                DataRow dr = dt.Rows[0];
                _infoStore = (string)dr["nameStore"] + Environment.NewLine;
                _infoStore += "Địa chỉ: " + (string)dr["addressStore"] + Environment.NewLine;
                _infoStore += "Phone Number: " + (string)dr["phoneStore"] + Environment.NewLine;
                _infoStore += "Tax code: " +  (string)dr["taxCode"];
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
        /// <para>Lưu dữ liệu DataTable vào file excel</para>
        /// </summary>
        /// <param name="filePath">Đường dẫn file cần save</param>
        /// <param name="dataGridView">Đối tượng dữ liệu</param>
        /// <returns>Message lỗi</returns>
        public static string SaveToExcel(string filePath, DataGridView dataGridView)
        {
            string message = string.Empty;
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(Missing.Value);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Ghi tên cột vào hàng đầu tiên
                for (int colIdx = 0; colIdx < dataGridView.ColumnCount; colIdx++)
                {
                    string colName = dataGridView.Columns[colIdx].HeaderText;
                    xlWorkSheet.Cells[1, colIdx + 1] = colName;
                    xlWorkSheet.Columns.ColumnWidth = 15;
                    //xlWorkSheet.Columns[colIdx].AutoFit();
                    //xlWorkSheet.Cells.Style.EntireColumn.AutoFit();
                }

                // Ghi dữ liệu DataGridView từ hàng thứ 2
                for (int rowIdx = 0; rowIdx < dataGridView.RowCount; rowIdx++)
                {
                    for (int colIdx = 0; colIdx < dataGridView.ColumnCount; colIdx++)
                    {
                        DataGridViewCell cell = dataGridView[colIdx, rowIdx];
                        xlWorkSheet.Cells[rowIdx + 2, colIdx + 1] = cell.Value;
                    }
                }
               
                xlWorkBook.SaveAs(
                    filePath,
                    Excel.XlFileFormat.xlWorkbookNormal,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Excel.XlSaveAsAccessMode.xlExclusive,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value,
                    Missing.Value);
                xlWorkBook.Close(true, Missing.Value, Missing.Value);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }

        TheEnd:
            return message;
        }

        /// <summary>
        /// <para>Release Excel</para>
        /// </summary>
        /// <param name="obj">Release object</param>
        private static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                }
            }
            catch (Exception)
            {
                goto TheEnd;
            }
            finally
            {
                GC.Collect();
            }

        TheEnd:
            return;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TsbTest_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            string time = DateTime.Now.ToString("yyyyMMdd");
            save.FileName = SHOW_RP_SALES_XLS_NAME + time + SHOW_EXTENTION_XLS;
            save.Filter = SHOW_XLS_FILTER;
            if (save.ShowDialog() != DialogResult.OK)
            {
                goto TheEnd;
            }

            Task task = new Task(delegate
            {
                _frmWait = new FrmWait();
                _frmWait.SetTitle(SHOW_WAIT_EXPORT_FILE);
                _frmWait.ShowDialog();
            });
            task.Start();

            string path = Path.GetDirectoryName(save.FileName);
            
            object[,] cellValues = new object[DgvMain.Rows.Count, DgvMain.Columns.Count];
            int rows = 0;

            foreach (DataGridViewRow row in DgvMain.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == 0)
                    {
                        cellValues[rows, i] = SIG_APOSTROPHE + row.Cells[i].Value;
                        continue;
                    }
                    cellValues[rows, i] = row.Cells[i].Value;
                }
                rows++;
            }

            SetEnableControl();
            Common.Export(_plusTime, path, cellValues);

            _frmWait.BeginInvoke((Action)delegate
            {
                _frmWait.Close();
            });

            MsgBox.CfmInfomation(MSG_DONE);

        TheEnd:
            return;
        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add(column.Name);
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        private void TxtTotalMoney_TextChanged(object sender, EventArgs e)
        {
            TxtTotalMoney.Text = string.Format("{0:#,##0}", double.Parse(TxtTotalMoney.Text));
        }

    }
}
