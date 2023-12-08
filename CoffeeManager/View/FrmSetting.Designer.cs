
namespace CoffeeManager
{
    partial class FrmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.TxtHeight = new System.Windows.Forms.TextBox();
            this.TxtWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblAccept = new System.Windows.Forms.Label();
            this.LblCancel = new System.Windows.Forms.Label();
            this.LblReductionHeight = new System.Windows.Forms.Label();
            this.LblIncreaseHeight = new System.Windows.Forms.Label();
            this.LblIncreaseWidth = new System.Windows.Forms.Label();
            this.LblReductionWidth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFontSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtHeight
            // 
            resources.ApplyResources(this.TxtHeight, "TxtHeight");
            this.TxtHeight.Name = "TxtHeight";
            this.TxtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHeight_KeyPress);
            // 
            // TxtWidth
            // 
            resources.ApplyResources(this.TxtWidth, "TxtWidth");
            this.TxtWidth.Name = "TxtWidth";
            this.TxtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtWidth_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // LblAccept
            // 
            resources.ApplyResources(this.LblAccept, "LblAccept");
            this.LblAccept.ForeColor = System.Drawing.Color.Blue;
            this.LblAccept.Name = "LblAccept";
            this.LblAccept.Click += new System.EventHandler(this.LblAccept_Click);
            // 
            // LblCancel
            // 
            resources.ApplyResources(this.LblCancel, "LblCancel");
            this.LblCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblCancel.Name = "LblCancel";
            this.LblCancel.Click += new System.EventHandler(this.LblCancel_Click);
            // 
            // LblReductionHeight
            // 
            resources.ApplyResources(this.LblReductionHeight, "LblReductionHeight");
            this.LblReductionHeight.Name = "LblReductionHeight";
            this.LblReductionHeight.Click += new System.EventHandler(this.LblReductionHeight_Click);
            // 
            // LblIncreaseHeight
            // 
            resources.ApplyResources(this.LblIncreaseHeight, "LblIncreaseHeight");
            this.LblIncreaseHeight.Name = "LblIncreaseHeight";
            this.LblIncreaseHeight.Click += new System.EventHandler(this.LblIncreaseHeight_Click);
            // 
            // LblIncreaseWidth
            // 
            resources.ApplyResources(this.LblIncreaseWidth, "LblIncreaseWidth");
            this.LblIncreaseWidth.Name = "LblIncreaseWidth";
            this.LblIncreaseWidth.Click += new System.EventHandler(this.LblIncreaseWidth_Click);
            // 
            // LblReductionWidth
            // 
            resources.ApplyResources(this.LblReductionWidth, "LblReductionWidth");
            this.LblReductionWidth.Name = "LblReductionWidth";
            this.LblReductionWidth.Click += new System.EventHandler(this.LblReductionWidth_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TxtFontSize
            // 
            resources.ApplyResources(this.TxtFontSize, "TxtFontSize");
            this.TxtFontSize.Name = "TxtFontSize";
            this.TxtFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFontSize_KeyPress);
            // 
            // FrmSetting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFontSize);
            this.Controls.Add(this.LblIncreaseWidth);
            this.Controls.Add(this.LblIncreaseHeight);
            this.Controls.Add(this.LblReductionWidth);
            this.Controls.Add(this.LblReductionHeight);
            this.Controls.Add(this.LblAccept);
            this.Controls.Add(this.LblCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtWidth);
            this.Controls.Add(this.TxtHeight);
            this.MaximizeBox = false;
            this.Name = "FrmSetting";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtHeight;
        private System.Windows.Forms.TextBox TxtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblAccept;
        private System.Windows.Forms.Label LblCancel;
        private System.Windows.Forms.Label LblReductionHeight;
        private System.Windows.Forms.Label LblIncreaseHeight;
        private System.Windows.Forms.Label LblIncreaseWidth;
        private System.Windows.Forms.Label LblReductionWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFontSize;
    }
}