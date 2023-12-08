
namespace CoffeeManager
{
    partial class FrmSalesChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesChart));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CbbChoseStyle = new System.Windows.Forms.ComboBox();
            this.chrMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DtpMonthFrom = new System.Windows.Forms.DateTimePicker();
            this.DtpYearFrom = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DtpMonthFrom);
            this.panel1.Controls.Add(this.DtpYearFrom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CbbChoseStyle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CbbChoseStyle
            // 
            this.CbbChoseStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.CbbChoseStyle, "CbbChoseStyle");
            this.CbbChoseStyle.FormattingEnabled = true;
            this.CbbChoseStyle.Items.AddRange(new object[] {
            resources.GetString("CbbChoseStyle.Items"),
            resources.GetString("CbbChoseStyle.Items1"),
            resources.GetString("CbbChoseStyle.Items2")});
            this.CbbChoseStyle.Name = "CbbChoseStyle";
            this.CbbChoseStyle.SelectedIndexChanged += new System.EventHandler(this.CbbChoseStyle_SelectedIndexChanged);
            // 
            // chrMain
            // 
            resources.ApplyResources(this.chrMain, "chrMain");
            chartArea2.Name = "ChartArea1";
            this.chrMain.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrMain.Legends.Add(legend2);
            this.chrMain.Name = "chrMain";
            this.chrMain.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.LegendText = "sales";
            series2.Name = "Salary";
            series2.YValuesPerPoint = 2;
            this.chrMain.Series.Add(series2);
            // 
            // lblMain
            // 
            resources.ApplyResources(this.lblMain, "lblMain");
            this.lblMain.Name = "lblMain";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DtpMonthFrom
            // 
            resources.ApplyResources(this.DtpMonthFrom, "DtpMonthFrom");
            this.DtpMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMonthFrom.Name = "DtpMonthFrom";
            this.DtpMonthFrom.ShowUpDown = true;
            this.DtpMonthFrom.ValueChanged += new System.EventHandler(this.DtpMonthFrom_ValueChanged);
            // 
            // DtpYearFrom
            // 
            resources.ApplyResources(this.DtpYearFrom, "DtpYearFrom");
            this.DtpYearFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpYearFrom.Name = "DtpYearFrom";
            this.DtpYearFrom.ShowUpDown = true;
            this.DtpYearFrom.ValueChanged += new System.EventHandler(this.DtpYearFrom_ValueChanged);
            // 
            // FrmSalesChart
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.chrMain);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSalesChart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSalesChart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrMain;
        private System.Windows.Forms.ComboBox CbbChoseStyle;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker DtpMonthFrom;
        private System.Windows.Forms.DateTimePicker DtpYearFrom;
    }
}