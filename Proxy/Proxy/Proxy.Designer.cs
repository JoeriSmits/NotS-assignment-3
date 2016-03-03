using System;

namespace Proxy
{
    partial class Proxy
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
            this.logTxt = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logTxt
            // 
            this.logTxt.Enabled = false;
            this.logTxt.Location = new System.Drawing.Point(12, 12);
            this.logTxt.Multiline = true;
            this.logTxt.Name = "logTxt";
            this.logTxt.Size = new System.Drawing.Size(705, 606);
            this.logTxt.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(723, 16);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(295, 109);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "button1";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this._BtnStart_Click);
            // 
            // Proxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 630);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.logTxt);
            this.Name = "Proxy";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTxt;
        private System.Windows.Forms.Button startBtn;
    }
}

