
namespace CoffeeManager
{
    partial class FrmSaleReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaleReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnClear = new System.Windows.Forms.Button();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlsbtnExportXls = new System.Windows.Forms.ToolStripButton();
            this.TsbTest = new System.Windows.Forms.ToolStripButton();
            this.GrbDateTime = new System.Windows.Forms.GroupBox();
            this.lblShowErr = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDayTo = new System.Windows.Forms.DateTimePicker();
            this.DtpMonthTo = new System.Windows.Forms.DateTimePicker();
            this.DtpYearTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDayFrom = new System.Windows.Forms.DateTimePicker();
            this.DtpMonthFrom = new System.Windows.Forms.DateTimePicker();
            this.DtpYearFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbbChoseStyle = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtProduct = new System.Windows.Forms.TextBox();
            this.DgvMain = new System.Windows.Forms.DataGridView();
            this.idBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNameTb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnOk = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtTotalMoney = new System.Windows.Forms.TextBox();
            this.PrbWait = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.GrbDateTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnClear);
            this.panel1.Controls.Add(this.tlsMain);
            this.panel1.Controls.Add(this.GrbDateTime);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TxtProduct);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // BtnClear
            // 
            resources.ApplyResources(this.BtnClear, "BtnClear");
            this.BtnClear.Image = global::CoffeeManager.Properties.Resources.del16;
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // tlsMain
            // 
            resources.ApplyResources(this.tlsMain, "tlsMain");
            this.tlsMain.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsbtnExportXls,
            this.TsbTest});
            this.tlsMain.Name = "tlsMain";
            // 
            // tlsbtnExportXls
            // 
            this.tlsbtnExportXls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbtnExportXls.Image = global::CoffeeManager.Properties.Resources.pdf32;
            resources.ApplyResources(this.tlsbtnExportXls, "tlsbtnExportXls");
            this.tlsbtnExportXls.Name = "tlsbtnExportXls";
            this.tlsbtnExportXls.Click += new System.EventHandler(this.tlsbtnExportXls_Click);
            // 
            // TsbTest
            // 
            this.TsbTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbTest.Image = global::CoffeeManager.Properties.Resources.excel32;
            resources.ApplyResources(this.TsbTest, "TsbTest");
            this.TsbTest.Name = "TsbTest";
            this.TsbTest.Click += new System.EventHandler(this.TsbTest_Click);
            // 
            // GrbDateTime
            // 
            this.GrbDateTime.Controls.Add(this.lblShowErr);
            this.GrbDateTime.Controls.Add(this.label6);
            this.GrbDateTime.Controls.Add(this.label7);
            this.GrbDateTime.Controls.Add(this.label8);
            this.GrbDateTime.Controls.Add(this.dtpDayTo);
            this.GrbDateTime.Controls.Add(this.DtpMonthTo);
            this.GrbDateTime.Controls.Add(this.DtpYearTo);
            this.GrbDateTime.Controls.Add(this.label4);
            this.GrbDateTime.Controls.Add(this.label3);
            this.GrbDateTime.Controls.Add(this.label5);
            this.GrbDateTime.Controls.Add(this.label2);
            this.GrbDateTime.Controls.Add(this.DtpDayFrom);
            this.GrbDateTime.Controls.Add(this.DtpMonthFrom);
            this.GrbDateTime.Controls.Add(this.DtpYearFrom);
            resources.ApplyResources(this.GrbDateTime, "GrbDateTime");
            this.GrbDateTime.Name = "GrbDateTime";
            this.GrbDateTime.TabStop = false;
            // 
            // lblShowErr
            // 
            resources.ApplyResources(this.lblShowErr, "lblShowErr");
            this.lblShowErr.ForeColor = System.Drawing.Color.Red;
            this.lblShowErr.Name = "lblShowErr";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // dtpDayTo
            // 
            resources.ApplyResources(this.dtpDayTo, "dtpDayTo");
            this.dtpDayTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDayTo.Name = "dtpDayTo";
            this.dtpDayTo.ShowUpDown = true;
            this.dtpDayTo.ValueChanged += new System.EventHandler(this.dtpDayTo_ValueChanged);
            this.dtpDayTo.MouseLeave += new System.EventHandler(this.dtpDayTo_MouseLeave);
            // 
            // DtpMonthTo
            // 
            resources.ApplyResources(this.DtpMonthTo, "DtpMonthTo");
            this.DtpMonthTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMonthTo.Name = "DtpMonthTo";
            this.DtpMonthTo.ShowUpDown = true;
            this.DtpMonthTo.ValueChanged += new System.EventHandler(this.DtpMonthTo_ValueChanged);
            this.DtpMonthTo.MouseLeave += new System.EventHandler(this.DtpMonthTo_MouseLeave);
            // 
            // DtpYearTo
            // 
            resources.ApplyResources(this.DtpYearTo, "DtpYearTo");
            this.DtpYearTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpYearTo.Name = "DtpYearTo";
            this.DtpYearTo.ShowUpDown = true;
            this.DtpYearTo.ValueChanged += new System.EventHandler(this.DtpYearTo_ValueChanged);
            this.DtpYearTo.MouseLeave += new System.EventHandler(this.DtpYearTo_MouseLeave);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Name = "label5";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // DtpDayFrom
            // 
            resources.ApplyResources(this.DtpDayFrom, "DtpDayFrom");
            this.DtpDayFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDayFrom.Name = "DtpDayFrom";
            this.DtpDayFrom.ShowUpDown = true;
            this.DtpDayFrom.ValueChanged += new System.EventHandler(this.DtpDayFrom_ValueChanged);
            this.DtpDayFrom.MouseLeave += new System.EventHandler(this.DtpDayFrom_MouseLeave);
            // 
            // DtpMonthFrom
            // 
            resources.ApplyResources(this.DtpMonthFrom, "DtpMonthFrom");
            this.DtpMonthFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMonthFrom.Name = "DtpMonthFrom";
            this.DtpMonthFrom.ShowUpDown = true;
            this.DtpMonthFrom.ValueChanged += new System.EventHandler(this.DtpMonthFrom_ValueChanged);
            this.DtpMonthFrom.MouseLeave += new System.EventHandler(this.DtpMonthFrom_MouseLeave);
            // 
            // DtpYearFrom
            // 
            resources.ApplyResources(this.DtpYearFrom, "DtpYearFrom");
            this.DtpYearFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpYearFrom.Name = "DtpYearFrom";
            this.DtpYearFrom.ShowUpDown = true;
            this.DtpYearFrom.ValueChanged += new System.EventHandler(this.DtpYearFrom_ValueChanged);
            this.DtpYearFrom.MouseLeave += new System.EventHandler(this.DtpYearFrom_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CbbChoseStyle);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CbbChoseStyle
            // 
            this.CbbChoseStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.CbbChoseStyle, "CbbChoseStyle");
            this.CbbChoseStyle.FormattingEnabled = true;
            this.CbbChoseStyle.Items.AddRange(new object[] {
            resources.GetString("CbbChoseStyle.Items"),
            resources.GetString("CbbChoseStyle.Items1"),
            resources.GetString("CbbChoseStyle.Items2"),
            resources.GetString("CbbChoseStyle.Items3"),
            resources.GetString("CbbChoseStyle.Items4")});
            this.CbbChoseStyle.Name = "CbbChoseStyle";
            this.CbbChoseStyle.SelectedIndexChanged += new System.EventHandler(this.CbbChoseStyle_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // TxtProduct
            // 
            resources.ApplyResources(this.TxtProduct, "TxtProduct");
            this.TxtProduct.Name = "TxtProduct";
            this.TxtProduct.TextChanged += new System.EventHandler(this.TxtProduct_TextChanged);
            // 
            // DgvMain
            // 
            this.DgvMain.AllowUserToAddRows = false;
            this.DgvMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idBill,
            this.ColNameTb,
            this.ColCusName,
            this.drink,
            this.ColFullName,
            this.ColDate,
            this.unitPrice,
            this.quantity,
            this.intoMoney});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.DgvMain, "DgvMain");
            this.DgvMain.GridColor = System.Drawing.Color.White;
            this.DgvMain.Name = "DgvMain";
            this.DgvMain.RowHeadersVisible = false;
            this.DgvMain.RowTemplate.Height = 30;
            this.DgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMain.Leave += new System.EventHandler(this.DgvMain_Leave);
            // 
            // idBill
            // 
            this.idBill.DataPropertyName = "id";
            resources.ApplyResources(this.idBill, "idBill");
            this.idBill.Name = "idBill";
            // 
            // ColNameTb
            // 
            this.ColNameTb.DataPropertyName = "nameTb";
            resources.ApplyResources(this.ColNameTb, "ColNameTb");
            this.ColNameTb.Name = "ColNameTb";
            // 
            // ColCusName
            // 
            this.ColCusName.DataPropertyName = "nameCus";
            resources.ApplyResources(this.ColCusName, "ColCusName");
            this.ColCusName.Name = "ColCusName";
            // 
            // drink
            // 
            this.drink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.drink.DataPropertyName = "name";
            resources.ApplyResources(this.drink, "drink");
            this.drink.Name = "drink";
            this.drink.ReadOnly = true;
            // 
            // ColFullName
            // 
            this.ColFullName.DataPropertyName = "fullName";
            resources.ApplyResources(this.ColFullName, "ColFullName");
            this.ColFullName.Name = "ColFullName";
            // 
            // ColDate
            // 
            this.ColDate.DataPropertyName = "billDate";
            resources.ApplyResources(this.ColDate, "ColDate");
            this.ColDate.Name = "ColDate";
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            resources.ApplyResources(this.unitPrice, "unitPrice");
            this.unitPrice.Name = "unitPrice";
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            resources.ApplyResources(this.quantity, "quantity");
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // intoMoney
            // 
            this.intoMoney.DataPropertyName = "intoMoney";
            resources.ApplyResources(this.intoMoney, "intoMoney");
            this.intoMoney.Name = "intoMoney";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PrbWait);
            this.panel2.Controls.Add(this.BtnOk);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.TxtTotalMoney);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.BtnOk, "BtnOk");
            this.BtnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // TxtTotalMoney
            // 
            resources.ApplyResources(this.TxtTotalMoney, "TxtTotalMoney");
            this.TxtTotalMoney.ForeColor = System.Drawing.Color.Red;
            this.TxtTotalMoney.Name = "TxtTotalMoney";
            this.TxtTotalMoney.TextChanged += new System.EventHandler(this.TxtTotalMoney_TextChanged);
            // 
            // PrbWait
            // 
            resources.ApplyResources(this.PrbWait, "PrbWait");
            this.PrbWait.Name = "PrbWait";
            // 
            // FrmSaleReport
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DgvMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSaleReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSaleReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.GrbDateTime.ResumeLayout(false);
            this.GrbDateTime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtProduct;
        private System.Windows.Forms.DataGridView DgvMain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlsbtnExportXls;
        private System.Windows.Forms.GroupBox GrbDateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDayTo;
        private System.Windows.Forms.DateTimePicker DtpMonthTo;
        private System.Windows.Forms.DateTimePicker DtpYearTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDayFrom;
        private System.Windows.Forms.DateTimePicker DtpMonthFrom;
        private System.Windows.Forms.DateTimePicker DtpYearFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbbChoseStyle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtTotalMoney;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Label lblShowErr;
        private System.Windows.Forms.ToolStripButton TsbTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNameTb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn drink;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn intoMoney;
        private System.Windows.Forms.ProgressBar PrbWait;
    }
}