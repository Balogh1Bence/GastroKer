namespace login
{
    partial class Szerk
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NameHolder = new login.Misc.PlaceHolderTextBox();
            this.PriceHolder = new login.Misc.PlaceHolderTextBox();
            this.AmmountHolder = new login.Misc.PlaceHolderTextBox();
            this.UnitHolder = new login.Misc.PlaceHolderTextBox();
            this.CodeHolder = new login.Misc.PlaceHolderTextBox();
            this.VonCodeHolder = new login.Misc.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(219, 292);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(242, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "egalizált-e";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Termek nev";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "mert";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "vonkod";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "ar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "keszl";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "katkod";
            // 
            // NameHolder
            // 
            this.NameHolder.Location = new System.Drawing.Point(219, 12);
            this.NameHolder.Name = "NameHolder";
            this.NameHolder.PlaceHolderText = null;
            this.NameHolder.Size = new System.Drawing.Size(100, 20);
            this.NameHolder.TabIndex = 17;
            // 
            // PriceHolder
            // 
            this.PriceHolder.Location = new System.Drawing.Point(219, 60);
            this.PriceHolder.Name = "PriceHolder";
            this.PriceHolder.PlaceHolderText = null;
            this.PriceHolder.Size = new System.Drawing.Size(100, 20);
            this.PriceHolder.TabIndex = 18;
            // 
            // AmmountHolder
            // 
            this.AmmountHolder.Location = new System.Drawing.Point(219, 111);
            this.AmmountHolder.Name = "AmmountHolder";
            this.AmmountHolder.PlaceHolderText = null;
            this.AmmountHolder.Size = new System.Drawing.Size(100, 20);
            this.AmmountHolder.TabIndex = 19;
            // 
            // UnitHolder
            // 
            this.UnitHolder.Location = new System.Drawing.Point(219, 159);
            this.UnitHolder.Name = "UnitHolder";
            this.UnitHolder.PlaceHolderText = null;
            this.UnitHolder.Size = new System.Drawing.Size(100, 20);
            this.UnitHolder.TabIndex = 20;
            // 
            // CodeHolder
            // 
            this.CodeHolder.Location = new System.Drawing.Point(219, 206);
            this.CodeHolder.Name = "CodeHolder";
            this.CodeHolder.PlaceHolderText = null;
            this.CodeHolder.Size = new System.Drawing.Size(100, 20);
            this.CodeHolder.TabIndex = 21;
            // 
            // VonCodeHolder
            // 
            this.VonCodeHolder.Location = new System.Drawing.Point(219, 252);
            this.VonCodeHolder.Name = "VonCodeHolder";
            this.VonCodeHolder.PlaceHolderText = null;
            this.VonCodeHolder.Size = new System.Drawing.Size(100, 20);
            this.VonCodeHolder.TabIndex = 22;
            // 
            // Szerk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VonCodeHolder);
            this.Controls.Add(this.CodeHolder);
            this.Controls.Add(this.UnitHolder);
            this.Controls.Add(this.AmmountHolder);
            this.Controls.Add(this.PriceHolder);
            this.Controls.Add(this.NameHolder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Name = "Szerk";
            this.Text = "Szerk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private Misc.PlaceHolderTextBox NameHolder;
        private Misc.PlaceHolderTextBox PriceHolder;
        private Misc.PlaceHolderTextBox AmmountHolder;
        private Misc.PlaceHolderTextBox UnitHolder;
        private Misc.PlaceHolderTextBox CodeHolder;
        private Misc.PlaceHolderTextBox VonCodeHolder;
    }
}