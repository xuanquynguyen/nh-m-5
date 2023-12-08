
namespace CoffeeManager
{
    partial class FrmCusInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCusInfo));
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CtmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXProduct = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.CtmsMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            resources.ApplyResources(this.dgvMain, "dgvMain");
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.address,
            this.phone,
            this.description,
            this.status});
            this.dgvMain.ContextMenuStrip = this.CtmsMain;
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
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "fullName";
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            resources.ApplyResources(this.address, "address");
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phoneNumber";
            resources.ApplyResources(this.phone, "phone");
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "idCard";
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "dateWork";
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // CtmsMain
            // 
            resources.ApplyResources(this.CtmsMain, "CtmsMain");
            this.CtmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiAdd,
            this.TsmiEdit,
            this.TsmiDel});
            this.CtmsMain.Name = "CtmsMain";
            // 
            // TsmiAdd
            // 
            resources.ApplyResources(this.TsmiAdd, "TsmiAdd");
            this.TsmiAdd.Image = global::CoffeeManager.Properties.Resources.add16;
            this.TsmiAdd.Name = "TsmiAdd";
            this.TsmiAdd.Click += new System.EventHandler(this.TsmiAdd_Click);
            // 
            // TsmiEdit
            // 
            resources.ApplyResources(this.TsmiEdit, "TsmiEdit");
            this.TsmiEdit.Image = global::CoffeeManager.Properties.Resources.edit16;
            this.TsmiEdit.Name = "TsmiEdit";
            this.TsmiEdit.Click += new System.EventHandler(this.TsmiEdit_Click);
            // 
            // TsmiDel
            // 
            resources.ApplyResources(this.TsmiDel, "TsmiDel");
            this.TsmiDel.Image = global::CoffeeManager.Properties.Resources.del16;
            this.TsmiDel.Name = "TsmiDel";
            this.TsmiDel.Click += new System.EventHandler(this.TsmiDel_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Controls.Add(this.PnlTop);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // PnlTop
            // 
            resources.ApplyResources(this.PnlTop, "PnlTop");
            this.PnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PnlTop.Controls.Add(this.btnAdd);
            this.PnlTop.Controls.Add(this.panel5);
            this.PnlTop.Name = "PnlTop";
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
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel5.Controls.Add(this.btnXProduct);
            this.panel5.Controls.Add(this.txtSearch);
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
            // FrmCusInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCusInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCusInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.CtmsMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnXProduct;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ContextMenuStrip CtmsMain;
        private System.Windows.Forms.ToolStripMenuItem TsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem TsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem TsmiDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}