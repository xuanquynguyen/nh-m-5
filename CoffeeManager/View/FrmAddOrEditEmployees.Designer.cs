
namespace CoffeeManager
{
    partial class FrmAddOrEditEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddOrEditEmployees));
            this.GrbInfo = new System.Windows.Forms.GroupBox();
            this.CkbStatus = new System.Windows.Forms.CheckBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpDateWork = new System.Windows.Forms.DateTimePicker();
            this.TxtIdCard = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtPhone = new System.Windows.Forms.TextBox();
            this.TxtFullName = new System.Windows.Forms.TextBox();
            this.PtbAvatar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.GrbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbAvatar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrbInfo
            // 
            resources.ApplyResources(this.GrbInfo, "GrbInfo");
            this.GrbInfo.BackColor = System.Drawing.Color.SandyBrown;
            this.GrbInfo.Controls.Add(this.CkbStatus);
            this.GrbInfo.Controls.Add(this.BtnBrowse);
            this.GrbInfo.Controls.Add(this.label6);
            this.GrbInfo.Controls.Add(this.label5);
            this.GrbInfo.Controls.Add(this.label4);
            this.GrbInfo.Controls.Add(this.label3);
            this.GrbInfo.Controls.Add(this.label2);
            this.GrbInfo.Controls.Add(this.label1);
            this.GrbInfo.Controls.Add(this.DtpDateWork);
            this.GrbInfo.Controls.Add(this.TxtIdCard);
            this.GrbInfo.Controls.Add(this.TxtAddress);
            this.GrbInfo.Controls.Add(this.TxtPhone);
            this.GrbInfo.Controls.Add(this.TxtFullName);
            this.GrbInfo.Controls.Add(this.PtbAvatar);
            this.GrbInfo.Name = "GrbInfo";
            this.GrbInfo.TabStop = false;
            // 
            // CkbStatus
            // 
            resources.ApplyResources(this.CkbStatus, "CkbStatus");
            this.CkbStatus.Checked = true;
            this.CkbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkbStatus.ForeColor = System.Drawing.Color.Blue;
            this.CkbStatus.Name = "CkbStatus";
            this.CkbStatus.UseVisualStyleBackColor = true;
            this.CkbStatus.CheckedChanged += new System.EventHandler(this.CkbStatus_CheckedChanged);
            // 
            // BtnBrowse
            // 
            resources.ApplyResources(this.BtnBrowse, "BtnBrowse");
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Name = "label1";
            // 
            // DtpDateWork
            // 
            resources.ApplyResources(this.DtpDateWork, "DtpDateWork");
            this.DtpDateWork.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateWork.Name = "DtpDateWork";
            // 
            // TxtIdCard
            // 
            resources.ApplyResources(this.TxtIdCard, "TxtIdCard");
            this.TxtIdCard.BackColor = System.Drawing.SystemColors.Window;
            this.TxtIdCard.ForeColor = System.Drawing.SystemColors.MenuText;
            this.TxtIdCard.Name = "TxtIdCard";
            // 
            // TxtAddress
            // 
            resources.ApplyResources(this.TxtAddress, "TxtAddress");
            this.TxtAddress.BackColor = System.Drawing.SystemColors.Window;
            this.TxtAddress.ForeColor = System.Drawing.SystemColors.MenuText;
            this.TxtAddress.Name = "TxtAddress";
            // 
            // TxtPhone
            // 
            resources.ApplyResources(this.TxtPhone, "TxtPhone");
            this.TxtPhone.BackColor = System.Drawing.SystemColors.Window;
            this.TxtPhone.ForeColor = System.Drawing.SystemColors.MenuText;
            this.TxtPhone.Name = "TxtPhone";
            this.TxtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPhone_KeyPress);
            // 
            // TxtFullName
            // 
            resources.ApplyResources(this.TxtFullName, "TxtFullName");
            this.TxtFullName.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFullName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.TxtFullName.Name = "TxtFullName";
            // 
            // PtbAvatar
            // 
            resources.ApplyResources(this.PtbAvatar, "PtbAvatar");
            this.PtbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PtbAvatar.Image = global::CoffeeManager.Properties.Resources.noneImage;
            this.PtbAvatar.Name = "PtbAvatar";
            this.PtbAvatar.TabStop = false;
            this.PtbAvatar.Click += new System.EventHandler(this.PtbAvatar_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAccept);
            this.panel1.Name = "panel1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ForeColor = System.Drawing.Color.Blue;
            this.btnCancel.Image = global::CoffeeManager.Properties.Resources.cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            resources.ApplyResources(this.btnAccept, "btnAccept");
            this.btnAccept.ForeColor = System.Drawing.Color.Blue;
            this.btnAccept.Image = global::CoffeeManager.Properties.Resources.accept;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FrmAddOrEditEmployees
            // 
            this.AcceptButton = this.btnAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GrbInfo);
            this.KeyPreview = true;
            this.Name = "FrmAddOrEditEmployees";
            this.Load += new System.EventHandler(this.FrmAddOrEditEmployees_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAddOrEditEmployees_KeyDown);
            this.GrbInfo.ResumeLayout(false);
            this.GrbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbAvatar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrbInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpDateWork;
        private System.Windows.Forms.TextBox TxtIdCard;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtPhone;
        private System.Windows.Forms.TextBox TxtFullName;
        private System.Windows.Forms.PictureBox PtbAvatar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox CkbStatus;
    }
}