using System;
using System.Data;
using System.Windows.Forms;
using static CoffeeManager.Properties.Resources;

namespace CoffeeManager
{
    public partial class FrmSalesChart : Form
    {
        private DbSaleReport _dbSalesRp = null;
        private int _modeGetData = 0;

        public FrmSalesChart()
        {
            InitializeComponent();
            _dbSalesRp = new DbSaleReport();
        }

        private void FrmSalesChart_Load(object sender, EventArgs e)
        {
            try
            {
                CbbChoseStyle.SelectedIndex = 0;
                lblMain.Text = CbbChoseStyle.Text;
                // chrMain.Palette = ChartColorPalette.SeaGreen;               
            }
            catch (Exception ex)
            {
                MsgBox.ErrProcess(ex.Message);
            }
        }

        private string GetData()
        {
            string message = "";
            try
            {
                chrMain.Titles.Clear();
                DataTable dt = _dbSalesRp.GetBillForChart(_modeGetData, DtpMonthFrom.Value, DtpYearFrom.Value);
                if (dt == null)
                {
                    MsgBox.ErrProcess(_dbSalesRp.Message);
                    goto TheEnd;
                }

                chrMain.DataSource = dt;
                chrMain.Series["Salary"].XValueMember = "billDate";
                chrMain.Series["Salary"].YValueMembers = "totalMoney";
                chrMain.Titles.Add(SHOW_SALES_CHART);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                goto TheEnd;
            }
        TheEnd:
            return message;
        }

        private void CbbChoseStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _modeGetData = CbbChoseStyle.SelectedIndex;
                DtpMonthFrom.Enabled = true;
                DtpYearFrom.Enabled = true;

                lblMain.Text = CbbChoseStyle.Text + " " + DateTime.Now.ToString("MM/yyyy");
                if  (_modeGetData == 1)
                {
                    lblMain.Text = CbbChoseStyle.Text + " " + DateTime.Now.ToString("yyyy");
                    DtpMonthFrom.Enabled = false;
                    DtpYearFrom.Enabled = true;
                }

                if (_modeGetData == 2)
                {
                    lblMain.Text = CbbChoseStyle.Text;
                    DtpMonthFrom.Enabled = false;
                    DtpYearFrom.Enabled = false;
                }

                string message = GetData();
                if(message.Length > 0)
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

        private void DtpMonthFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string message = GetData();
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

        private void DtpYearFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string message = GetData();
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
    }
}

