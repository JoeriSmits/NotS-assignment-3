using System;
using System.Windows.Forms;

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
            this.startBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clrBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.authChecked = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.logTxt = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(723, 12);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(566, 109);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start proxy";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this._BtnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1113, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 31);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "9000";
            this.textBox1.LostFocus += new System.EventHandler(this.textBox1_Blur);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Poxy port";
            // 
            // clrBtn
            // 
            this.clrBtn.Location = new System.Drawing.Point(12, 625);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.Size = new System.Drawing.Size(705, 47);
            this.clrBtn.TabIndex = 4;
            this.clrBtn.Text = "Clear Log";
            this.clrBtn.UseVisualStyleBackColor = true;
            this.clrBtn.Click += new System.EventHandler(this.clrBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1113, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 31);
            this.textBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(727, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "P1. a) Cache time out in seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(727, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "P2. Zet content filter aan/uit";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1261, 223);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(28, 27);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(727, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(449, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "P4. b) Zet basic access authentication aan/uit";
            // 
            // authChecked
            // 
            this.authChecked.AutoSize = true;
            this.authChecked.Location = new System.Drawing.Point(1260, 258);
            this.authChecked.Name = "authChecked";
            this.authChecked.Size = new System.Drawing.Size(28, 27);
            this.authChecked.TabIndex = 14;
            this.authChecked.UseVisualStyleBackColor = true;
            this.authChecked.CheckedChanged += new System.EventHandler(this.authChecked_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1113, 291);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 31);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "1024";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(727, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "T4, T8) Buffersize";
            // 
            // logTxt
            // 
            this.logTxt.FormattingEnabled = true;
            this.logTxt.ItemHeight = 25;
            this.logTxt.Location = new System.Drawing.Point(12, 12);
            this.logTxt.Name = "logTxt";
            this.logTxt.Size = new System.Drawing.Size(705, 604);
            this.logTxt.TabIndex = 27;
            this.logTxt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.logTxt_DoubleClick);
            // 
            // Proxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 682);
            this.Controls.Add(this.logTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.authChecked);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.clrBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.startBtn);
            this.Name = "Proxy";
            this.Text = "Proxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clrBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox authChecked;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox logTxt;
    }
}

