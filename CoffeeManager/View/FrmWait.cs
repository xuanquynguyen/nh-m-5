using System;
using System.Windows.Forms;

namespace CoffeeManager
{
    public partial class FrmWait : Form
    {
        public FrmWait()
        {
            InitializeComponent();
        }

        private void FrmWait_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// <para>Set tiêu đề</para>
        /// </summary>
        /// <param name="title">Tiêu đề</param>
        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }
    }
}
