namespace Proxy
{
    partial class PopUp
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
            this.headersTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // headersTxt
            // 
            this.headersTxt.Location = new System.Drawing.Point(12, 12);
            this.headersTxt.Multiline = true;
            this.headersTxt.Name = "headersTxt";
            this.headersTxt.Size = new System.Drawing.Size(767, 538);
            this.headersTxt.TabIndex = 0;
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 562);
            this.Controls.Add(this.headersTxt);
            this.Name = "PopUp";
            this.Text = "Detailed Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox headersTxt;
    }
}