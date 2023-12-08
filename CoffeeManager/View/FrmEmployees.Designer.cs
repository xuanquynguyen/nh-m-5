
namespace CoffeeManager
{
    partial class FrmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmployees));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateWork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img = new System.Windows.Forms.DataGridViewImageColumn();
            this.ctmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.RdbOff = new System.Windows.Forms.RadioButton();
            this.RdbOn = new System.Windows.Forms.RadioButton();
            this.RdbAll = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXProduct = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.ctmsMain.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Controls.Add(this.PnlTop);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fullName,
            this.phoneNumber,
            this.address,
            this.idCard,
            this.dateWork,
            this.status,
            this.img});
            this.dgvMain.ContextMenuStrip = this.ctmsMain;
            resources.ApplyResources(this.dgvMain, "dgvMain");
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 40;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // fullName
            // 
            this.fullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullName.DataPropertyName = "fullName";
            resources.ApplyResources(this.fullName, "fullName");
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            // 
            // phoneNumber
            // 
            this.phoneNumber.DataPropertyName = "phoneNumber";
            resources.ApplyResources(this.phoneNumber, "phoneNumber");
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // idCard
            // 
            this.idCard.DataPropertyName = "idCard";
            resources.ApplyResources(this.idCard, "idCard");
            this.idCard.Name = "idCard";
            this.idCard.ReadOnly = true;
            // 
            // dateWork
            // 
            this.dateWork.DataPropertyName = "dateWork";
            resources.ApplyResources(this.dateWork, "dateWork");
            this.dateWork.Name = "dateWork";
            this.dateWork.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // img
            // 
            this.img.DataPropertyName = "img";
            resources.ApplyResources(this.img, "img");
            this.img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.img.Name = "img";
            this.img.ReadOnly = true;
            // 
            // ctmsMain
            // 
            resources.ApplyResources(this.ctmsMain, "ctmsMain");
            this.ctmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiDel,
            this.TsmiAdd,
            this.TsmiView});
            this.ctmsMain.Name = "ctmsMain";
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.Image = global::CoffeeManager.Properties.Resources.edit16;
            this.tsmiEdit.Name = "tsmiEdit";
            resources.ApplyResources(this.tsmiEdit, "tsmiEdit");
            this.tsmiEdit.Click += new System.EventHandler(this.tsmiEdit_Click);
            // 
            // tsmiDel
            // 
            this.tsmiDel.Image = global::CoffeeManager.Properties.Resources.del16;
            this.tsmiDel.Name = "tsmiDel";
            resources.ApplyResources(this.tsmiDel, "tsmiDel");
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // TsmiAdd
            // 
            this.TsmiAdd.Image = global::CoffeeManager.Properties.Resources.add16;
            this.TsmiAdd.Name = "TsmiAdd";
            resources.ApplyResources(this.TsmiAdd, "TsmiAdd");
            this.TsmiAdd.Click += new System.EventHandler(this.TsmiAdd_Click);
            // 
            // TsmiView
            // 
            this.TsmiView.Image = global::CoffeeManager.Properties.Resources.view16;
            this.TsmiView.Name = "TsmiView";
            resources.ApplyResources(this.TsmiView, "TsmiView");
            this.TsmiView.Click += new System.EventHandler(this.TsmiView_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PnlTop.Controls.Add(this.RdbOff);
            this.PnlTop.Controls.Add(this.RdbOn);
            this.PnlTop.Controls.Add(this.RdbAll);
            this.PnlTop.Controls.Add(this.btnAdd);
            this.PnlTop.Controls.Add(this.panel5);
            resources.ApplyResources(this.PnlTop, "PnlTop");
            this.PnlTop.Name = "PnlTop";
            // 
            // RdbOff
            // 
            resources.ApplyResources(this.RdbOff, "RdbOff");
            this.RdbOff.Name = "RdbOff";
            this.RdbOff.UseVisualStyleBackColor = true;
            this.RdbOff.CheckedChanged += new System.EventHandler(this.RdbAll_CheckedChanged);
            // 
            // RdbOn
            // 
            resources.ApplyResources(this.RdbOn, "RdbOn");
            this.RdbOn.Name = "RdbOn";
            this.RdbOn.UseVisualStyleBackColor = true;
            this.RdbOn.CheckedChanged += new System.EventHandler(this.RdbAll_CheckedChanged);
            // 
            // RdbAll
            // 
            resources.ApplyResources(this.RdbAll, "RdbAll");
            this.RdbAll.Checked = true;
            this.RdbAll.Name = "RdbAll";
            this.RdbAll.TabStop = true;
            this.RdbAll.UseVisualStyleBackColor = true;
            this.RdbAll.CheckedChanged += new System.EventHandler(this.RdbAll_CheckedChanged);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Image = global::CoffeeManager.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel5.Controls.Add(this.btnXProduct);
            this.panel5.Controls.Add(this.txtSearch);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // btnXProduct
            // 
            resources.ApplyResources(this.btnXProduct, "btnXProduct");
            this.btnXProduct.ForeColor = System.Drawing.Color.Red;
            this.btnXProduct.Name = "btnXProduct";
            this.btnXProduct.UseVisualStyleBackColor = true;
            this.btnXProduct.Click += new System.EventHandler(this.btnXProduct_Click);
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // FrmEmployees
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmEmployees";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEmployees_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ctmsMain.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnXProduct;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip ctmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.RadioButton RdbAll;
        private System.Windows.Forms.RadioButton RdbOff;
        private System.Windows.Forms.RadioButton RdbOn;
        private System.Windows.Forms.ToolStripMenuItem TsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem TsmiView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewImageColumn img;
    }
}