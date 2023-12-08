
namespace CoffeeManager
{
    partial class ProgressBarForm
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
            this.PrbWait = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // PrbWait
            // 
            this.PrbWait.Location = new System.Drawing.Point(61, 64);
            this.PrbWait.Name = "PrbWait";
            this.PrbWait.Size = new System.Drawing.Size(328, 23);
            this.PrbWait.TabIndex = 0;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 148);
            this.Controls.Add(this.PrbWait);
            this.Name = "ProgressBarForm";
            this.Text = "ProgressBarForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar PrbWait;
    }
}