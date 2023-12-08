
namespace CoffeeManager
{
    partial class FrmConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnect));
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadServer = new System.Windows.Forms.Button();
            this.rdbSqlServer = new System.Windows.Forms.RadioButton();
            this.rdbWindows = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbServerName = new System.Windows.Forms.ComboBox();
            this.cbbDatabaseName = new System.Windows.Forms.ComboBox();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Name = "lblHeader";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadServer);
            this.panel1.Controls.Add(this.rdbSqlServer);
            this.panel1.Controls.Add(this.rdbWindows);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbServerName);
            this.panel1.Controls.Add(this.cbbDatabaseName);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnLoadServer
            // 
            resources.ApplyResources(this.btnLoadServer, "btnLoadServer");
            this.btnLoadServer.Name = "btnLoadServer";
            this.btnLoadServer.UseVisualStyleBackColor = true;
            this.btnLoadServer.Click += new System.EventHandler(this.btnLoadServer_Click);
            // 
            // rdbSqlServer
            // 
            resources.ApplyResources(this.rdbSqlServer, "rdbSqlServer");
            this.rdbSqlServer.Name = "rdbSqlServer";
            this.rdbSqlServer.UseVisualStyleBackColor = true;
            this.rdbSqlServer.CheckedChanged += new System.EventHandler(this.rdbSqlServer_CheckedChanged);
            // 
            // rdbWindows
            // 
            resources.ApplyResources(this.rdbWindows, "rdbWindows");
            this.rdbWindows.Checked = true;
            this.rdbWindows.Name = "rdbWindows";
            this.rdbWindows.TabStop = true;
            this.rdbWindows.UseVisualStyleBackColor = true;
            this.rdbWindows.CheckedChanged += new System.EventHandler(this.rdbWindows_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbbServerName
            // 
            resources.ApplyResources(this.cbbServerName, "cbbServerName");
            this.cbbServerName.FormattingEnabled = true;
            this.cbbServerName.Name = "cbbServerName";
            this.cbbServerName.SelectedIndexChanged += new System.EventHandler(this.cbbServerName_SelectedIndexChanged);
            // 
            // cbbDatabaseName
            // 
            resources.ApplyResources(this.cbbDatabaseName, "cbbDatabaseName");
            this.cbbDatabaseName.FormattingEnabled = true;
            this.cbbDatabaseName.Name = "cbbDatabaseName";
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.label4);
            this.pnlUser.Controls.Add(this.label3);
            this.pnlUser.Controls.Add(this.txtPassword);
            this.pnlUser.Controls.Add(this.txtUser);
            resources.ApplyResources(this.pnlUser, "pnlUser");
            this.pnlUser.Name = "pnlUser";
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
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // txtUser
            // 
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.Name = "txtUser";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTestConnect);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnSave);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnTestConnect
            // 
            resources.ApplyResources(this.btnTestConnect, "btnTestConnect");
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmConnect
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.MaximizeBox = false;
            this.Name = "FrmConnect";
            this.Load += new System.EventHandler(this.FrmConnect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadServer;
        private System.Windows.Forms.RadioButton rdbSqlServer;
        private System.Windows.Forms.RadioButton rdbWindows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbServerName;
        private System.Windows.Forms.ComboBox cbbDatabaseName;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
    }
}