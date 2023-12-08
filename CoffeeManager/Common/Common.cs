using Microsoft.Win32;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using static CoffeeManager.Properties.Resource;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public class Common
    {
        private static string _message = "";
        /// <summary>
        /// <para>Get version app hiện tại</para>
        /// </summary>
        /// <returns>Chuỗi ký tự version</returns>
        public static string GetAppVersion()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return fieVersionInfo.FileVersion;
        }

        /// <summary>
        /// <para>Get giá trị của keyname tại "PC\HKEY_CURRENT_USER\Software\Tên App"</para>
        /// </summary>
        /// <param name="keyName">Tên key đối tượng đọc</param>
        /// <returns>Giá trị của keyname</returns>
        public static string RegistryRead(string keyName)
        {
            try
            {
                string subKey = "SOFTWARE\\" + Application.ProductName;

                RegistryKey sk = Registry.CurrentUser.OpenSubKey(subKey);
                if (sk == null)
                {
                    return string.Empty;
                }

                int count = sk.ValueCount;
                if (count < 1)
                {
                    return string.Empty;
                }
                return sk.GetValue(keyName).ToString();
            }
            catch (Exception)
            {
                throw;
            }                  
        }

        public static bool DeleteKey(string KeyName)
        {
            bool del = false;
            try
            {
                string subKey = "SOFTWARE\\" + Application.ProductName;
                RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(subKey);
                
                if (sk1 == null)
                {
                    del = true;
                    goto TheEnd;
                }

                sk1.DeleteValue(KeyName);
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

        /// <summary>
        /// <para>Tạo SubKey bằng tên app tại "PC\HKEY_CURRENT_USER\Software\Tên App"</para>
        /// </summary>
        /// <param name="keyName">Tên key đối tượng ghi</param>
        /// <param name="value">Giá trị ghi</param>
        public static void RegistryWrite(string keyName, string value)
        {
            string subKey = "SOFTWARE\\" + Application.ProductName;

            RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(subKey);
            sk1.SetValue(keyName, value);
        }

        /// <summary>
        /// <para>Get dữ liệu db nếu null thì trả về null</para>
        /// </summary>
        /// <param name="rdr">SqlDataReader</param>
        /// <param name="colName">Tên cột get dữ liệu</param>
        /// <returns>Giá trị null nếu db null</returns>
        public static T GetDbNull<T>(SqlDataReader rdr, string colName)
        {
            if (rdr[colName] == DBNull.Value)
            {
                return default(T);
            }
            return (T)rdr[colName];
        }

        public static T GetDbNull1<T>(DataRow rdr, string colName)
        {
            if (rdr[colName] == DBNull.Value)
            {
                return default(T);
            }
            return (T)rdr[colName];
        }

        /// <summary>
        /// <para>Get file path của file DatabaseConnection.con</para>
        /// </summary>
        /// <returns>File path của file DatabaseConnection.con</returns>
        public static string GetPathDatabaseConnection()
        {
            string fileListPath = Directory.GetCurrentDirectory() +
                                    Path.DirectorySeparatorChar + CONNECT_FILE_PATH;
            string dirFileList = Path.GetDirectoryName(fileListPath);

            Directory.CreateDirectory(dirFileList);
            string fileName = Path.GetFileName(dirFileList);
            return fileListPath;
        }

        /// <summary>
        /// <para>Đóng kết nối</para>
        /// </summary>
        /// <param name="conn">Chuỗi kết nối</param>
        public static void CloseConnect(SqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static long CreateId()
        {
            string id = DateTime.Now.ToString("yyyyMMddhhmmssff");
            return long.Parse(id);
        }

        /// <summary>
        /// <para>Mã hóa dữ liệu</para>
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="toEncrypt">Chuỗi dữ liệu</param>
        /// <returns></returns>
        public static string Encrypt(string key, string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            TripleDESCryptoServiceProvider tdes =
             new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                  toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// <para>Giải mã dữ liệu</para>
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="toDecrypt">Chuỗi dữ liệu</param>
        /// <returns></returns>
        public static string Decrypt(string key, string toDecrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
             toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
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

        public static void KillExcel()
        {
            Process[] processes = Process.GetProcesses();

            if (processes.Length <= 1)
            {
                goto TheEnd;
            }

            for (int n = 0; n <= processes.Length - 1; n++)
            {
                if (((Process)processes[n]).ProcessName == "EXCEL")
                {
                    ((Process)processes[n]).Kill();
                }
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Chuyển byte thành hình ảnh</para>
        /// </summary>
        /// <param name="byteIn"></param>
        /// <returns></returns>
        public static Image ByteToImage(byte[] byteIn)
        {
            MemoryStream ms = new MemoryStream(byteIn);
            Image rt = Image.FromStream(ms);
            return rt;
        }

        /// <summary>
        /// <para>Chuyển đổi hình ảnh thành byte</para>
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        /// <summary>
        /// <para>Thực hiện xuất dữ liệu vào file excel</para>
        /// <para>- Xuất file xlsx từ resource vào directory chỉ định</para>
        /// <para>- Nếu đã có file thì ghi đè</para>
        /// <para>- Đổi tên file nơi "00xx" là tiêu đề Sheet1 như</para>
        /// <para>     "DANH SÁCH DỰ BÁO DÒNG TIỀN"</para>
        /// <para>- Thực hiện tính toán nơi cell màu xám</para>
        /// <para>- Nếu inputDatas là null hoặc rỗng thì chỉ xuất file từ resource</para>
        /// </summary>
        /// <param name="directory">Đường dẫn lưu file</param>
        /// <param name="inputDatas">Dữ liệu xuất vào file</param>
        /// <returns>false : thất bại</returns>
        public static bool Export(string plusTime, string directory, object[,] inputDatas)
        {
            bool isSuccess = false;
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;

            try
            {
                // Xuất file xlsx từ resource vào directory chỉ định
                string filePath = directory + @"\" + SHOW_XLS_TITLE_NAME + ".xlsx";
                File.WriteAllBytes(filePath, Sell_0008);

                // Khởi tạo file excel theo đường dẫn
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(filePath);
                xlWorksheet = xlWorkbook.Sheets[1];

                // Set tiêu đề chính ở dòng đầu tiên
                int rowInsert = 1;
                xlWorksheet.Cells[rowInsert, 1] = SHOW_XLS_TITLE_NAME + Environment.NewLine + plusTime;
                xlWorksheet.Cells[rowInsert, 1].Style.Font.Name = "Microsoft Sans Serif";
                xlWorksheet.Cells[rowInsert, 1].Style.WrapText = true;

                // Add danh sách tiêu đề bảng ở dòng tiếp theo
                rowInsert++;
                string[] titleTable = new string[] {
                    SHOW_XLS_ID,
                    SHOW_XLS_TB,
                    SHOW_XLS_CUS,
                    SHOW_XLS_PR,
                    SHOW_XLS_EM,
                    SHOW_XLS_DATE,
                    SHOW_XLS_UN_PRC,
                    SHOW_XLS_QUANTILY,
                    SHOW_XLS_INTO_MN
                };
                for (int idxTitle = 0; idxTitle < titleTable.Length; idxTitle++)
                {
                    xlWorksheet.Cells[rowInsert, idxTitle + 1] = titleTable[idxTitle];
                    xlWorksheet.Cells[rowInsert, idxTitle + 1].Style.Font.Name = "Microsoft Sans Serif";
                }

                // Tính tổng "Giá trị hoá đơn"
                double totalInvoice = 0;
                int posInvoice = CmnExcel.GetPositionStringOf(titleTable,
                    SHOW_XLS_INTO_MN);

                // Nếu inputDatas là null hoặc rỗng thì chỉ xuất file từ resource
                rowInsert++;
                int rowNumber = 0;
                if ((inputDatas != null) && (inputDatas.Length > 0))
                {
                    // Thêm nội dung file
                    rowNumber = inputDatas.GetLength(0);                 
                    Excel.Range target1 = xlWorksheet.Range[
                        xlWorksheet.Cells[rowInsert, 1],
                        xlWorksheet.Cells[rowInsert + rowNumber - 1, titleTable.Length]];
                    target1.Value2 = inputDatas;
                    rowInsert = rowInsert + rowNumber;

                    // Tính tổng "Giá trị hoá đơn"
                    for (int row = 0; row < rowNumber; row++)
                    {
                        // Tính tổng "Giá trị hoá đơn"
                        totalInvoice += CmnExcel.GetDouble(inputDatas, row, posInvoice);
                    }
                    
                }

                // Thêm tính số dòng
                // CmnExcel.SetLightGray(xlWorksheet, rowInsert, 1, "Số dòng: " + rowNumber);

                // Thêm kết quả tính tổng "Giá trị hoá đơn"
                CmnExcel.SetLightGray(xlWorksheet, rowInsert, posInvoice, SHOW_TOTAL_MN);
                CmnExcel.SetLightGray(xlWorksheet, rowInsert, posInvoice + 1, totalInvoice);
                xlWorksheet.Rows.AutoFit();
                xlWorksheet.Columns.AutoFit();
                xlWorkbook.Save();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                CmnExcel.WorkbookClose(xlWorkbook);
                CmnExcel.AppQuit(xlApp);
                CmnExcel.ReleaseObject(xlWorksheet);
                CmnExcel.ReleaseObject(xlWorkbook);
                CmnExcel.ReleaseObject(xlRange);
                CmnExcel.ReleaseObject(xlApp);
            }

        TheEnd:
            return isSuccess;
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
