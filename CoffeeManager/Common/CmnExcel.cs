using Microsoft.Office.Interop.Excel;
using System;
using System.Runtime.InteropServices;
using static CoffeeManager.Properties.Resource;

namespace CoffeeManager
{
    /// <summary>
    /// <para>Chức năng chung của excel</para>
    /// </summary>
    public class CmnExcel
    {
        private static string _message = string.Empty;

        /// <summary>
        /// <para>Release Excel</para>
        /// </summary>
        /// <param name="obj">Release object</param>
        internal static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }
            finally
            {
                GC.Collect();
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Workbook Close</para>
        /// </summary>
        /// <param name="xlWorkbook">Workbook</param>
        internal static void WorkbookClose(Workbook xlWorkbook)
        {
            try
            {
                if (xlWorkbook != null)
                {
                    xlWorkbook.Close();
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>App Quit</para>
        /// </summary>
        /// <param name="xlApp">Application</param>
        internal static void AppQuit(Application xlApp)
        {
            try
            {
                if (xlApp != null)
                {
                    xlApp.Quit();
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Lấy vị trí chuỗi trong mảng</para>
        /// </summary>
        /// <param name="arrayString">Mảng cần tìm</param>
        /// <param name="title">Chuỗi cần tìm</param>
        /// <returns>-1: Lỗi hoặc không tìm thấy</returns>
        internal static int GetPositionStringOf(string[] arrayString, string title)
        {
            int position = -1;

            try
            {
                for (int idxArray = 0; idxArray < arrayString.Length; idxArray++)
                {
                    bool isExist = arrayString[idxArray].Equals(title);
                    if (isExist != false)
                    {
                        position = idxArray;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                position = -1;
                goto TheEnd;
            }

        TheEnd:
            return position;
        }

        /// <summary>
        /// <para>Lấy giá trị double trong mảng object</para>
        /// </summary>
        /// <param name="inputDatas">Mảng object 2 chiều</param>
        /// <param name="row">Dòng cần lấy</param>
        /// <param name="col">Cột cần lấy</param>
        /// <returns>0: Nếu không tìm thấy</returns>
        internal static double GetDouble(object[,] inputDatas, int row, int col)
        {
            double value = 0;

            try
            {
                // Dừng nếu == null
                if (inputDatas[row, col] == null)
                {
                    goto TheEnd;
                }

                value = (double)inputDatas[row, col];
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return value;
        }

        /// <summary>
        /// <para>Thiết định màu cho kết quả tính toán</para>
        /// </summary>
        /// <param name="xlWorksheet">Sheet trong excel</param>
        /// <param name="row">Dòng cần set</param>
        /// <param name="col">Cột cần set</param>
        /// <param name="value">Nội dung cần set</param>
        internal static void SetLightGray(_Worksheet xlWorksheet, int row, int col, object value)
        {
            try
            {
                // Dừng nếu == null
                if (xlWorksheet == null)
                {
                    goto TheEnd;
                }

                xlWorksheet.Cells[row, col] = value;
                xlWorksheet.Cells[row, col].Style.Font.Name = "Microsoft Sans Serif";
                xlWorksheet.Cells[row, col].Interior.Color =
                    System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return;
        }

        /// <summary>
        /// <para>Tính tổng giá trị trong cột của mảng 2 chiều</para>
        /// </summary>
        /// <param name="arr">Mảng 2 chiều</param>
        /// <param name="colIdx">Index của cột</param>
        /// <returns>Tổng giá trị cột</returns>
        internal static decimal SumColValue(object[,] arr, int colIdx)
        {
            decimal result = 0;

            try
            {
                int rowCount = arr.GetLength(0);
                for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
                {
                    decimal numValue = Convert.ToDecimal(arr[rowIdx, colIdx]);
                    result += numValue;
                }
            }
            catch (Exception ex)
            {
                _message = ex.Message;
                result = 0;
                goto TheEnd;
            }

        TheEnd:
            return result;
        }

        /// <summary>
        /// <para>Message lỗi</para>
        /// </summary>
        public static string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
