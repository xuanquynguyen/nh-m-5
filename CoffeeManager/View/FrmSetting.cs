using System;
using System.IO;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;
namespace CoffeeManager
{
    public partial class FrmSetting : Form
    {
        private int _mode = 0;
        private int _height = 0;
        private int _width = 0;
        private int _fontSize = 10;
        private string _text = "";
        public FrmSetting(string text, int mode, int fontSize, int height, int width)
        {
            InitializeComponent();
            _mode = mode;
            _fontSize = fontSize;
            _height = height;
            _width = width;
            _text = text;
        }

        private void LblAccept_Click(object sender, EventArgs e)
        {
            try
            {
                int fontSize = int.Parse(TxtFontSize.Text);
                int height = int.Parse(TxtHeight.Text);
                int width = int.Parse(TxtWidth.Text);
                if ((height > 150) || (width > 160))
                {
                    MsgBox.ErrProcess(MSG_MAX_NUMBER);
                    goto TheEnd;
                }

                if ((height == 0) || (width == 0) || (fontSize == 0))
                {
                    MsgBox.ErrProcess(MSG_NOT_ALLOWED);
                    goto TheEnd;
                }

                string totalSettings = TxtHeight.Text + ";";
                totalSettings += TxtWidth.Text + ";";
                totalSettings += TxtFontSize.Text + ";";

                string message = "";
                switch(_mode)
                {
                    case 0:
                        break;
                    case 1:
                        message = SetModeProduct(totalSettings);
                        if  (message.Length > 0)
                        {
                            MsgBox.ErrProcess(MSG_ERROR_SETTING_UP);
                            goto TheEnd;
                        }    
                        break;
                        
                    case 2:
                        message = SetModeTables(totalSettings);
                        if (message.Length > 0)
                        {
                            MsgBox.ErrProcess(MSG_ERROR_SETTING_UP);
                            goto TheEnd;
                        }
                        break;
                    default:
                        break;
                } 
                
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        TheEnd:
            return;
        }

        private string SetModeProduct(string totalSetting)
        {
            string message = "";
            try
            {
                string fileDefaultSetting = Application.StartupPath + "\\DefaultSettings.tb";
                if (File.Exists(fileDefaultSetting) == false)
                {
                    File.Create(fileDefaultSetting);
                }

                File.WriteAllText(fileDefaultSetting, totalSetting);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }

        TheEnd:
            return message;
        }

        private string SetModeTables(string totalSetting)
        {
            string message = "";
            try
            {
                string fileDefaultSetting = Application.StartupPath + "\\DefaultSettingTables.tb";
                if (File.Exists(fileDefaultSetting) == false)
                {
                    File.Create(fileDefaultSetting);
                }

                File.WriteAllText(fileDefaultSetting, totalSetting);
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
        /// <para>Không cho di chuyển form</para>
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;
            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                goto TheEnd;
            }
            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                goto TheEnd;
            }

            base.WndProc(ref m);

        TheEnd:
            return;
        }

        private void LblCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            Text = _text;
            TxtHeight.Text = _height.ToString();
            TxtWidth.Text = _width.ToString();
            TxtFontSize.Text = _fontSize.ToString();
        }

        private void LblIncreaseHeight_Click(object sender, EventArgs e)
        {
            int currentHeght = int.Parse(TxtHeight.Text);
            currentHeght = currentHeght + 10;
            TxtHeight.Text = currentHeght.ToString();

            TxtHeight.SelectionStart = TxtHeight.Text.Length;
            TxtHeight.SelectionLength = 0;
        }

        private void LblIncreaseWidth_Click(object sender, EventArgs e)
        {
            int currentWidth = int.Parse(TxtWidth.Text);
            currentWidth = currentWidth + 10;
            TxtWidth.Text = currentWidth.ToString();

            TxtWidth.SelectionStart = TxtWidth.Text.Length;
            TxtWidth.SelectionLength = 0;
        }

        private void LblReductionHeight_Click(object sender, EventArgs e)
        {
            int currentHeght = int.Parse(TxtHeight.Text);
            if (currentHeght <= 10)
            {
                goto TheEnd;
            }
            
            currentHeght = currentHeght - 10;
            TxtHeight.Text = currentHeght.ToString();

        TheEnd:
            return;
        }

        private void LblReductionWidth_Click(object sender, EventArgs e)
        {
            int currentWidth = int.Parse(TxtWidth.Text);
            if (currentWidth <= 10)
            {
                goto TheEnd;
            }

            currentWidth = currentWidth - 10;
            TxtWidth.Text = currentWidth.ToString();

        TheEnd:
            return;
        }

        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isControl = char.IsControl(e.KeyChar);
            bool isDigit = char.IsDigit(e.KeyChar);
            if ((isControl == false) && (isDigit == false))
            {
                e.Handled = true;
                MsgBox.ErrProcess(MSG_PRESS_NUMBER);
            }
        }

        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isControl = char.IsControl(e.KeyChar);
            bool isDigit = char.IsDigit(e.KeyChar);
            if ((isControl == false) && (isDigit == false))
            {
                e.Handled = true;
                MsgBox.ErrProcess(MSG_PRESS_NUMBER);
            }
        }

        private void TxtFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isControl = char.IsControl(e.KeyChar);
            bool isDigit = char.IsDigit(e.KeyChar);
            if ((isControl == false) && (isDigit == false))
            {
                e.Handled = true;
                MsgBox.ErrProcess(MSG_PRESS_NUMBER);
            }
        }
    }
}
