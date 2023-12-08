
namespace CoffeeManager
{
    partial class FrmLoginRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginRole));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNameHeader = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDel = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeader = new System.Windows.Forms.Label();
            this.DgvRight = new System.Windows.Forms.DataGridView();
            this.ColNameMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNameShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsRoom = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CkbCheckAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.ctmsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.Image = global::CoffeeManager.Properties.Resources.accept24;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::CoffeeManager.Properties.Resources.cancel24;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNameHeader
            // 
            this.lblNameHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.lblNameHeader, "lblNameHeader");
            this.lblNameHeader.ForeColor = System.Drawing.Color.Maroon;
            this.lblNameHeader.Name = "lblNameHeader";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMain);
            this.panel2.Controls.Add(this.lblHeader);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.dgvMain, "dgvMain");
            this.dgvMain.ColumnHeadersVisible = false;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColFullName});
            this.dgvMain.ContextMenuStrip = this.ctmsMain;
            this.dgvMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 40;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ColName.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.ColName, "ColName");
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColFullName
            // 
            resources.ApplyResources(this.ColFullName, "ColFullName");
            this.ColFullName.Name = "ColFullName";
            this.ColFullName.ReadOnly = true;
            // 
            // ctmsMain
            // 
            resources.ApplyResources(this.ctmsMain, "ctmsMain");
            this.ctmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDel});
            this.ctmsMain.Name = "ctmsMain";
            // 
            // tsmiDel
            // 
            this.tsmiDel.Image = global::CoffeeManager.Properties.Resources.del16;
            this.tsmiDel.Name = "tsmiDel";
            resources.ApplyResources(this.tsmiDel, "tsmiDel");
            this.tsmiDel.Click += new System.EventHandler(this.tsmiDel_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeader.Name = "lblHeader";
            // 
            // DgvRight
            // 
            this.DgvRight.AllowUserToAddRows = false;
            this.DgvRight.AllowUserToDeleteRows = false;
            this.DgvRight.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DgvRight, "DgvRight");
            this.DgvRight.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNameMenu,
            this.ColNameShow,
            this.ColIsRoom,
            this.ColId});
            this.DgvRight.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRight.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvRight.GridColor = System.Drawing.Color.Gray;
            this.DgvRight.MultiSelect = false;
            this.DgvRight.Name = "DgvRight";
            this.DgvRight.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRight.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvRight.RowHeadersVisible = false;
            this.DgvRight.RowTemplate.Height = 40;
            this.DgvRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRight.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRight_CellClick);
            // 
            // ColNameMenu
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColNameMenu.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.ColNameMenu, "ColNameMenu");
            this.ColNameMenu.Name = "ColNameMenu";
            this.ColNameMenu.ReadOnly = true;
            // 
            // ColNameShow
            // 
            this.ColNameShow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ColNameShow.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.ColNameShow, "ColNameShow");
            this.ColNameShow.Name = "ColNameShow";
            this.ColNameShow.ReadOnly = true;
            // 
            // ColIsRoom
            // 
            resources.ApplyResources(this.ColIsRoom, "ColIsRoom");
            this.ColIsRoom.Name = "ColIsRoom";
            this.ColIsRoom.ReadOnly = true;
            this.ColIsRoom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsRoom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColId
            // 
            resources.ApplyResources(this.ColId, "ColId");
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            // 
            // CkbCheckAll
            // 
            resources.ApplyResources(this.CkbCheckAll, "CkbCheckAll");
            this.CkbCheckAll.ForeColor = System.Drawing.Color.Maroon;
            this.CkbCheckAll.Name = "CkbCheckAll";
            this.CkbCheckAll.UseVisualStyleBackColor = true;
            this.CkbCheckAll.CheckedChanged += new System.EventHandler(this.CkbCheckAll_CheckedChanged);
            // 
            // FrmLoginRole
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CkbCheckAll);
            this.Controls.Add(this.DgvRight);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblNameHeader);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLoginRole";
            this.Load += new System.EventHandler(this.FrmLoginRole_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ctmsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNameHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView DgvRight;
        private System.Windows.Forms.CheckBox CkbCheckAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullName;
        private System.Windows.Forms.ContextMenuStrip ctmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNameMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNameShow;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIsRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
    }
}