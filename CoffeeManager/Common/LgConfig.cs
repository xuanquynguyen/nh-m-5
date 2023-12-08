using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CoffeeManager
{
    public class LgConfig
    {
        private static string _langName = "";
        public static string SetLanguage()
        {
            string message = string.Empty;

            try
            {
                string language = string.Empty;
                string configFilePath = Application.StartupPath + "\\SetLanguage.ini";

                // Nếu file thiết định ngôn ngữ tồn tại
                bool isExistPath = File.Exists(configFilePath);
                if (isExistPath != false)
                {
                    // Set ngôn ngữ theo file thiết định
                    language = ReadIniFile(
                        configFilePath, "Language", "CurrentName");
                    _langName = language;
                }

                if (language.Length > 0)
                {
                    // Set ngôn ngữ cho form theo "language"
                    CultureInfo culture = CultureInfo.GetCultureInfo(language);
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
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
        /// <para>Ghi file ini bằng lib kernel32</para>
        /// </summary>
        /// <param name="section">Section đối tượng</param>
        /// <param name="key">Key đối tượng</param>
        /// <param name="value">Giá trị cần ghi</param>
        /// <param name="filePath">Đường dẫn đến file ini</param>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int WritePrivateProfileString(
            string section, string key, string value, string filePath);

        /// <summary>
        /// <para>Đọc file ini bằng lib kernel32</para>
        /// </summary>
        /// <param name="section">Section đối tượng</param>
        /// <param name="key">Key đối tượng</param>
        /// <param name="defaultVal">Giá trị mặc định khi không đọc được dữ liệu</param>
        /// <param name="retVal">Giá trị trả về</param>
        /// <param name="size">Độ dài chuỗi được trả về</param>
        /// <param name="filePath">Đường dẫn đến file ini</param>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
            string section,
            string key,
            string defaultVal,
            string retVal,
            int size,
            string filePath);

        /// <summary>
        /// <para>Đọc dữ liệu file ini</para>
        /// </summary>
        /// <param name="filePath">Đường dẫn đến file ini</param>
        /// <param name="section">Section đối tượng</param>
        /// <param name="key">Key đối tượng</param>
        /// <returns>Dữ liệu đã đọc (trả về empty nếu không đọc được)</returns>
        public static string ReadIniFile(
            string filePath, string section, string key)
        {
            string value = new string(' ', 255);
            GetPrivateProfileString(
                section, key, string.Empty, value, value.Length, filePath);
            return value;
        }

        /// <summary>
        /// <para>Ghi file ini</para>
        /// </summary>
        /// <param name="filePath">Đường dẫn đến file ini</param>
        /// <param name="section">Section đối tượng</param>
        /// <param name="key">Key đối tượng</param>
        /// <param name="value">Giá trị cần ghi</param>
        public static void WriteIniFile(
            string filePath, string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// <para>Lưu ngôn ngữ vào file ini</para>
        /// </summary>
        /// <param name="langName">Tên viết tắt của ngôn ngữ</param>
        /// <returns>Thông điệp lỗi</returns>
        public static string SetLangToIni(string langName)
        {
            string message = string.Empty;

            try
            {
                string configFilePath = Application.StartupPath + "\\SetLanguage.ini";
                WriteIniFile(configFilePath, "Language", "CurrentName", langName);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        public static string LangName
        {
            get { return _langName; }
            set { _langName = value; }
        }
    }
}
