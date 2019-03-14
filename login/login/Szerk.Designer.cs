namespace login
{
    partial class Szerk
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Misc.PlaceHolderTextBox NameHolder;
        private Misc.PlaceHolderTextBox PriceHolder;
        private Misc.PlaceHolderTextBox AmmountHolder;
        private Misc.PlaceHolderTextBox UnitHolder;
        private Misc.PlaceHolderTextBox CodeHolder;
        private Misc.PlaceHolderTextBox VonCodeHolder;
        private Misc.BackGroundBox backGroundBox1;
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.NameHolder = new login.Misc.PlaceHolderTextBox();
            this.PriceHolder = new login.Misc.PlaceHolderTextBox();
            this.AmmountHolder = new login.Misc.PlaceHolderTextBox();
            this.UnitHolder = new login.Misc.PlaceHolderTextBox();
            this.CodeHolder = new login.Misc.PlaceHolderTextBox();
            this.VonCodeHolder = new login.Misc.PlaceHolderTextBox();
            this.backGroundBox1 = new login.Misc.BackGroundBox();
            ((System.ComponentModel.ISupportInitialize)(this.backGroundBox1)).BeginInit();
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
            // NameHolder
            // 
            this.NameHolder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NameHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.NameHolder.ForeColor = System.Drawing.Color.Gray;
            this.NameHolder.Location = new System.Drawing.Point(219, 12);
            this.NameHolder.Name = "NameHolder";
            this.NameHolder.PlaceHolderText = null;
            this.NameHolder.Size = new System.Drawing.Size(100, 20);
            this.NameHolder.TabIndex = 17;
            // 
            // PriceHolder
            // 
            this.PriceHolder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PriceHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.PriceHolder.ForeColor = System.Drawing.Color.Gray;
            this.PriceHolder.Location = new System.Drawing.Point(219, 60);
            this.PriceHolder.Name = "PriceHolder";
            this.PriceHolder.PlaceHolderText = null;
            this.PriceHolder.Size = new System.Drawing.Size(100, 20);
            this.PriceHolder.TabIndex = 18;
            // 
            // AmmountHolder
            // 
            this.AmmountHolder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.AmmountHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.AmmountHolder.ForeColor = System.Drawing.Color.Gray;
            this.AmmountHolder.Location = new System.Drawing.Point(219, 111);
            this.AmmountHolder.Name = "AmmountHolder";
            this.AmmountHolder.PlaceHolderText = null;
            this.AmmountHolder.Size = new System.Drawing.Size(100, 20);
            this.AmmountHolder.TabIndex = 19;
            // 
            // UnitHolder
            // 
            this.UnitHolder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.UnitHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.UnitHolder.ForeColor = System.Drawing.Color.Gray;
            this.UnitHolder.Location = new System.Drawing.Point(219, 159);
            this.UnitHolder.Name = "UnitHolder";
            this.UnitHolder.PlaceHolderText = null;
            this.UnitHolder.Size = new System.Drawing.Size(100, 20);
            this.UnitHolder.TabIndex = 20;
            // 
            // CodeHolder
            // 
            this.CodeHolder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CodeHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.CodeHolder.ForeColor = System.Drawing.Color.Gray;
            this.CodeHolder.Location = new System.Drawing.Point(219, 206);
            this.CodeHolder.Name = "CodeHolder";
            this.CodeHolder.PlaceHolderText = null;
            this.CodeHolder.Size = new System.Drawing.Size(100, 20);
            this.CodeHolder.TabIndex = 21;
          
            // 
            // backGroundBox1
            // 
            this.backGroundBox1.ImgName = null;
            this.backGroundBox1.Location = new System.Drawing.Point(0, 0);
            this.backGroundBox1.Name = "backGroundBox1";
            this.backGroundBox1.Size = new System.Drawing.Size(99, 64);
            this.backGroundBox1.TabIndex = 23;
            this.backGroundBox1.TabStop = false;
            this.backGroundBox1.Click += new System.EventHandler(this.backGroundBox1_Click);
            // 
            // Szerk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backGroundBox1);
            this.Controls.Add(this.VonCodeHolder);
            this.Controls.Add(this.CodeHolder);
            this.Controls.Add(this.UnitHolder);
            this.Controls.Add(this.AmmountHolder);
            this.Controls.Add(this.PriceHolder);
            this.Controls.Add(this.NameHolder);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Name = "Szerk";
            this.Text = "Szerk";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.Load += new System.EventHandler(this.Szerk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backGroundBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public void initializeCustomComponents()
        {
            // 
            // VonCodeHolder
            // 
            this.VonCodeHolder.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.VonCodeHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.VonCodeHolder.ForeColor = System.Drawing.Color.Gray;
            this.VonCodeHolder.Location = new System.Drawing.Point(219, 252);
            this.VonCodeHolder.Name = "VonCodeHolder";
            this.VonCodeHolder.PlaceHolderText = null;
            this.VonCodeHolder.Size = new System.Drawing.Size(100, 20);
            this.VonCodeHolder.TabIndex = 22;
        }
       
    }
}