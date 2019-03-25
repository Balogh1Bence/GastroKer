namespace login
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
            this.button1 = new System.Windows.Forms.Button();
            this.placeHolderTextBox1 = new login.Misc.PlaceHolderTextBox();
            this.placeHolderTextBox2 = new login.Misc.PlaceHolderTextBox();
            this.placeHolderTextBox3 = new login.Misc.PlaceHolderTextBox();
            this.placeHolderTextBox4 = new login.Misc.PlaceHolderTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Küldés";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.placeHolderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Location = new System.Drawing.Point(31, 22);
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = null;
            this.placeHolderTextBox1.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox1.TabIndex = 1;
            // 
            // placeHolderTextBox2
            // 
            this.placeHolderTextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.placeHolderTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox2.Location = new System.Drawing.Point(31, 100);
            this.placeHolderTextBox2.Name = "placeHolderTextBox2";
            this.placeHolderTextBox2.PlaceHolderText = null;
            this.placeHolderTextBox2.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox2.TabIndex = 2;
            // 
            // placeHolderTextBox3
            // 
            this.placeHolderTextBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.placeHolderTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox3.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox3.Location = new System.Drawing.Point(31, 48);
            this.placeHolderTextBox3.Name = "placeHolderTextBox3";
            this.placeHolderTextBox3.PlaceHolderText = null;
            this.placeHolderTextBox3.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox3.TabIndex = 3;
            // 
            // placeHolderTextBox4
            // 
            this.placeHolderTextBox4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.placeHolderTextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox4.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox4.Location = new System.Drawing.Point(31, 74);
            this.placeHolderTextBox4.Name = "placeHolderTextBox4";
            this.placeHolderTextBox4.PlaceHolderText = null;
            this.placeHolderTextBox4.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox4.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ugy",
            "vez",
            "admin",
            "rkt"});
            this.comboBox1.Location = new System.Drawing.Point(162, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // addRktUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 173);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.placeHolderTextBox4);
            this.Controls.Add(this.placeHolderTextBox3);
            this.Controls.Add(this.placeHolderTextBox2);
            this.Controls.Add(this.placeHolderTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "addRktUser";
            this.Text = "Felhasználó hozzáadása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Misc.PlaceHolderTextBox placeHolderTextBox1;
        private Misc.PlaceHolderTextBox placeHolderTextBox2;
        private Misc.PlaceHolderTextBox placeHolderTextBox3;
        private Misc.PlaceHolderTextBox placeHolderTextBox4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}