
namespace CoffeeManager
{
    partial class FrmProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGroupProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img = new System.Windows.Forms.DataGridViewImageColumn();
            this.ctmsProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddPr = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXProduct = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grbGroup = new System.Windows.Forms.GroupBox();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.idGr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameGr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionGr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmsGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.txtSearchGroup = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.ctmsProduct.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.grbGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.ctmsGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.grbGroup);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMain);
            this.groupBox2.Controls.Add(this.panel3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idGroupProduct,
            this.name,
            this.unit,
            this.unitPrice,
            this.description,
            this.img});
            this.dgvMain.ContextMenuStrip = this.ctmsProduct;
            resources.ApplyResources(this.dgvMain, "dgvMain");
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 40;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.SelectionChanged += new System.EventHandler(this.dgvMain_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // idGroupProduct
            // 
            resources.ApplyResources(this.idGroupProduct, "idGroupProduct");
            this.idGroupProduct.Name = "idGroupProduct";
            this.idGroupProduct.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            resources.ApplyResources(this.unit, "unit");
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // unitPrice
            // 
            this.unitPrice.DataPropertyName = "unitPrice";
            resources.ApplyResources(this.unitPrice, "unitPrice");
            this.unitPrice.Name = "unitPrice";
            this.unitPrice.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // img
            // 
            this.img.DataPropertyName = "img";
            resources.ApplyResources(this.img, "img");
            this.img.Name = "img";
            this.img.ReadOnly = true;
            // 
            // ctmsProduct
            // 
            resources.ApplyResources(this.ctmsProduct, "ctmsProduct");
            this.ctmsProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEditProduct,
            this.tsmiDelProduct,
            this.TsmiAdd});
            this.ctmsProduct.Name = "ctmsMain";
            // 
            // tsmiEditProduct
            // 
            this.tsmiEditProduct.Image = global::CoffeeManager.Properties.Resources.edit16;
            this.tsmiEditProduct.Name = "tsmiEditProduct";
            resources.ApplyResources(this.tsmiEditProduct, "tsmiEditProduct");
            this.tsmiEditProduct.Click += new System.EventHandler(this.tsmiEditProduct_Click);
            // 
            // tsmiDelProduct
            // 
            this.tsmiDelProduct.Image = global::CoffeeManager.Properties.Resources.del16;
            this.tsmiDelProduct.Name = "tsmiDelProduct";
            resources.ApplyResources(this.tsmiDelProduct, "tsmiDelProduct");
            this.tsmiDelProduct.Click += new System.EventHandler(this.tsmiDelProduct_Click);
            // 
            // TsmiAdd
            // 
            this.TsmiAdd.Image = global::CoffeeManager.Properties.Resources.add16;
            this.TsmiAdd.Name = "TsmiAdd";
            resources.ApplyResources(this.TsmiAdd, "TsmiAdd");
            this.TsmiAdd.Click += new System.EventHandler(this.TsmiAdd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.btnAddPr);
            this.panel3.Controls.Add(this.panel5);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnAddPr
            // 
            resources.ApplyResources(this.btnAddPr, "btnAddPr");
            this.btnAddPr.Image = global::CoffeeManager.Properties.Resources.add;
            this.btnAddPr.Name = "btnAddPr";
            this.btnAddPr.UseVisualStyleBackColor = true;
            this.btnAddPr.Click += new System.EventHandler(this.btnAddPr_Click);
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
            // grbGroup
            // 
            this.grbGroup.Controls.Add(this.dgvGroup);
            this.grbGroup.Controls.Add(this.panel2);
            resources.ApplyResources(this.grbGroup, "grbGroup");
            this.grbGroup.ForeColor = System.Drawing.Color.Blue;
            this.grbGroup.Name = "grbGroup";
            this.grbGroup.TabStop = false;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idGr,
            this.nameGr,
            this.descriptionGr});
            this.dgvGroup.ContextMenuStrip = this.ctmsGroup;
            resources.ApplyResources(this.dgvGroup, "dgvGroup");
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.RowHeadersVisible = false;
            this.dgvGroup.RowTemplate.Height = 40;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // idGr
            // 
            this.idGr.DataPropertyName = "idGr";
            resources.ApplyResources(this.idGr, "idGr");
            this.idGr.Name = "idGr";
            this.idGr.ReadOnly = true;
            // 
            // nameGr
            // 
            this.nameGr.DataPropertyName = "nameGr";
            resources.ApplyResources(this.nameGr, "nameGr");
            this.nameGr.Name = "nameGr";
            this.nameGr.ReadOnly = true;
            // 
            // descriptionGr
            // 
            this.descriptionGr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionGr.DataPropertyName = "descriptionGr";
            resources.ApplyResources(this.descriptionGr, "descriptionGr");
            this.descriptionGr.Name = "descriptionGr";
            this.descriptionGr.ReadOnly = true;
            // 
            // ctmsGroup
            // 
            resources.ApplyResources(this.ctmsGroup, "ctmsGroup");
            this.ctmsGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEdit,
            this.tsmiDel,
            this.TsmiAddGroup});
            this.ctmsGroup.Name = "ctmsMain";
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
            // TsmiAddGroup
            // 
            this.TsmiAddGroup.Image = global::CoffeeManager.Properties.Resources.add16;
            this.TsmiAddGroup.Name = "TsmiAddGroup";
            resources.ApplyResources(this.TsmiAddGroup, "TsmiAddGroup");
            this.TsmiAddGroup.Click += new System.EventHandler(this.TsmiAddGroup_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnHelp);
            this.panel2.Controls.Add(this.btnAddGroup);
            this.panel2.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Image = global::CoffeeManager.Properties.Resources.help;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnAddGroup
            // 
            resources.ApplyResources(this.btnAddGroup, "btnAddGroup");
            this.btnAddGroup.Image = global::CoffeeManager.Properties.Resources.add;
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel4.Controls.Add(this.btnX);
            this.panel4.Controls.Add(this.txtSearchGroup);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // btnX
            // 
            resources.ApplyResources(this.btnX, "btnX");
            this.btnX.ForeColor = System.Drawing.Color.Red;
            this.btnX.Name = "btnX";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // txtSearchGroup
            // 
            resources.ApplyResources(this.txtSearchGroup, "txtSearchGroup");
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.TextChanged += new System.EventHandler(this.txtSearchGroup_TextChanged);
            // 
            // FrmProduct
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "FrmProduct";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProduct_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ctmsProduct.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.grbGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ctmsGroup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grbGroup;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearchGroup;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnXProduct;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnAddPr;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ContextMenuStrip ctmsGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.ContextMenuStrip ctmsProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelProduct;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolStripMenuItem TsmiAddGroup;
        private System.Windows.Forms.ToolStripMenuItem TsmiAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGroupProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewImageColumn img;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGr;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameGr;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionGr;
    }
}