using System.Windows.Forms;

namespace CoffeeManager
{
    /// <summary>
    /// <para>Hiển thị messagebox</para>
    /// </summary>
    public class MsgBox
    {
        /// <summary>
        /// <para>Xác nhận Yes/No</para>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DialogResult CfmProcessing(string message)
        {
            return MessageBox.Show(message, "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// <para>Xác nhận Ok</para>
        /// </summary>
        /// <param name="message"></param>
        public static void CfmInfomation(string message)
        {
            MessageBox.Show(message, "Notification",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// <para>Xác nhận lỗi</para>
        /// </summary>
        /// <param name="message"></param>
        public static void ErrProcess(string message)
        {
            MessageBox.Show(message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
