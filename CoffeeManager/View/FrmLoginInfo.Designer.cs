
namespace CoffeeManager
{
    partial class FrmLoginInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginInfo));
            this.lblUserSel = new System.Windows.Forms.Label();
            this.chkUsing = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOk = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUserSel
            // 
            resources.ApplyResources(this.lblUserSel, "lblUserSel");
            this.lblUserSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserSel.ForeColor = System.Drawing.Color.Navy;
            this.lblUserSel.Name = "lblUserSel";
            this.lblUserSel.Click += new System.EventHandler(this.lblUserSel_Click);
            // 
            // chkUsing
            // 
            resources.ApplyResources(this.chkUsing, "chkUsing");
            this.chkUsing.Checked = true;
            this.chkUsing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUsing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkUsing.ForeColor = System.Drawing.Color.Maroon;
            this.chkUsing.Name = "chkUsing";
            this.chkUsing.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Name = "label3";
            // 
            // lblHeader
            // 
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeader.Name = "lblHeader";
            // 
            // TxtUserName
            // 
            resources.ApplyResources(this.TxtUserName, "TxtUserName");
            this.TxtUserName.BackColor = System.Drawing.Color.White;
            this.TxtUserName.Name = "TxtUserName";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // lblOk
            // 
            resources.ApplyResources(this.lblOk, "lblOk");
            this.lblOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOk.ForeColor = System.Drawing.Color.Navy;
            this.lblOk.Name = "lblOk";
            this.lblOk.Click += new System.EventHandler(this.lblOk_Click);
            // 
            // txtFullName
            // 
            resources.ApplyResources(this.txtFullName, "txtFullName");
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Name = "label4";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Name = "txtPassword";
            // 
            // FrmLoginInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUserSel);
            this.Controls.Add(this.chkUsing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOk);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Name = "FrmLoginInfo";
            this.Load += new System.EventHandler(this.FrmLoginInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserSel;
        private System.Windows.Forms.CheckBox chkUsing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOk;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
    }
}