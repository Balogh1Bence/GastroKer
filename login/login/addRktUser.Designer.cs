﻿namespace login
{
    partial class addRktUser
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.placeHolderTextBox1 = new login.Misc.PlaceHolderTextBox();
            this.placeHolderTextBox2 = new login.Misc.PlaceHolderTextBox();
            this.placeHolderTextBox3 = new login.Misc.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "vez",
            "rak",
            "admin"});
            this.comboBox1.Location = new System.Drawing.Point(290, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.Location = new System.Drawing.Point(147, 88);
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = null;
            this.placeHolderTextBox1.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox1.TabIndex = 2;
            // 
            // placeHolderTextBox2
            // 
            this.placeHolderTextBox2.Location = new System.Drawing.Point(147, 114);
            this.placeHolderTextBox2.Name = "placeHolderTextBox2";
            this.placeHolderTextBox2.PlaceHolderText = null;
            this.placeHolderTextBox2.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox2.TabIndex = 3;
            // 
            // placeHolderTextBox3
            // 
            this.placeHolderTextBox3.Location = new System.Drawing.Point(147, 140);
            this.placeHolderTextBox3.Name = "placeHolderTextBox3";
            this.placeHolderTextBox3.PlaceHolderText = null;
            this.placeHolderTextBox3.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox3.TabIndex = 4;
            // 
            // addRktUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.placeHolderTextBox3);
            this.Controls.Add(this.placeHolderTextBox2);
            this.Controls.Add(this.placeHolderTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "addRktUser";
            this.Text = "addRktUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.Button button1;
        private Misc.PlaceHolderTextBox placeHolderTextBox1;
        private Misc.PlaceHolderTextBox placeHolderTextBox2;
        private Misc.PlaceHolderTextBox placeHolderTextBox3;
    }
}