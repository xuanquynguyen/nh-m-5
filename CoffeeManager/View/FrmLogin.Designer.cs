
namespace CoffeeManager
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.CkbSavePassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ToolStripMain = new System.Windows.Forms.ToolStrip();
            this.TstBtnSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRestore = new System.Windows.Forms.ToolStripButton();
            this.TsbtnExecSql = new System.Windows.Forms.ToolStripButton();
            this.CkbRemovePassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.ToolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtUsername
            // 
            resources.ApplyResources(this.TxtUsername, "TxtUsername");
            this.TxtUsername.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Click += new System.EventHandler(this.TxtUsername_Click);
            // 
            // CkbSavePassword
            // 
            resources.ApplyResources(this.CkbSavePassword, "CkbSavePassword");
            this.CkbSavePassword.BackColor = System.Drawing.Color.Transparent;
            this.CkbSavePassword.ForeColor = System.Drawing.Color.White;
            this.CkbSavePassword.Name = "CkbSavePassword";
            this.CkbSavePassword.UseVisualStyleBackColor = false;
            this.CkbSavePassword.Click += new System.EventHandler(this.CkbSavePassword_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // TxtPassword
            // 
            resources.ApplyResources(this.TxtPassword, "TxtPassword");
            this.TxtPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Click += new System.EventHandler(this.TxtPassword_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CoffeeManager.Properties.Resources.user_icon;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CoffeeManager.Properties.Resources._lock;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // ToolStripMain
            // 
            this.ToolStripMain.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TstBtnSetting,
            this.toolStripBtnRestore,
            this.TsbtnExecSql});
            resources.ApplyResources(this.ToolStripMain, "ToolStripMain");
            this.ToolStripMain.Name = "ToolStripMain";
            // 
            // TstBtnSetting
            // 
            this.TstBtnSetting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TstBtnSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TstBtnSetting.Image = global::CoffeeManager.Properties.Resources.connect_icon;
            resources.ApplyResources(this.TstBtnSetting, "TstBtnSetting");
            this.TstBtnSetting.Name = "TstBtnSetting";
            this.TstBtnSetting.Click += new System.EventHandler(this.TstBtnSetting_Click);
            // 
            // toolStripBtnRestore
            // 
            this.toolStripBtnRestore.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripBtnRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRestore.Image = global::CoffeeManager.Properties.Resources.Restore_Window_icon;
            resources.ApplyResources(this.toolStripBtnRestore, "toolStripBtnRestore");
            this.toolStripBtnRestore.Name = "toolStripBtnRestore";
            this.toolStripBtnRestore.Click += new System.EventHandler(this.toolStripBtnRestore_Click);
            // 
            // TsbtnExecSql
            // 
            this.TsbtnExecSql.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsbtnExecSql.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnExecSql.Image = global::CoffeeManager.Properties.Resources.exec;
            resources.ApplyResources(this.TsbtnExecSql, "TsbtnExecSql");
            this.TsbtnExecSql.Name = "TsbtnExecSql";
            this.TsbtnExecSql.Click += new System.EventHandler(this.TsbtnExecSql_Click);
            // 
            // CkbRemovePassword
            // 
            resources.ApplyResources(this.CkbRemovePassword, "CkbRemovePassword");
            this.CkbRemovePassword.BackColor = System.Drawing.Color.Transparent;
            this.CkbRemovePassword.ForeColor = System.Drawing.Color.White;
            this.CkbRemovePassword.Name = "CkbRemovePassword";
            this.CkbRemovePassword.UseVisualStyleBackColor = false;
            this.CkbRemovePassword.Click += new System.EventHandler(this.ChkRemovePassword_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoffeeManager.Properties.Resources.unnamed;
            this.ControlBox = false;
            this.Controls.Add(this.CkbRemovePassword);
            this.Controls.Add(this.ToolStripMain);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.CkbSavePassword);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ToolStripMain.ResumeLayout(false);
            this.ToolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.CheckBox CkbSavePassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStrip ToolStripMain;
        private System.Windows.Forms.ToolStripButton TstBtnSetting;
        private System.Windows.Forms.ToolStripButton toolStripBtnRestore;
        private System.Windows.Forms.CheckBox CkbRemovePassword;
        private System.Windows.Forms.ToolStripButton TsbtnExecSql;
    }
}