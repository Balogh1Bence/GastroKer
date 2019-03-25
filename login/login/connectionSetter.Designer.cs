namespace login
{
    partial class connectionSetter
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
            this.placeHolderTextBox1 = new login.Misc.PlaceHolderTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.placeHolderTextBox2 = new login.Misc.PlaceHolderTextBox();
            this.SuspendLayout();
            // 
            // placeHolderTextBox1
            // 
            this.placeHolderTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.placeHolderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox1.Location = new System.Drawing.Point(49, 37);
            this.placeHolderTextBox1.Name = "placeHolderTextBox1";
            this.placeHolderTextBox1.PlaceHolderText = null;
            this.placeHolderTextBox1.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kapcsolatok beállítása";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // placeHolderTextBox2
            // 
            this.placeHolderTextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.placeHolderTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeHolderTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.placeHolderTextBox2.Location = new System.Drawing.Point(49, 63);
            this.placeHolderTextBox2.Name = "placeHolderTextBox2";
            this.placeHolderTextBox2.PlaceHolderText = null;
            this.placeHolderTextBox2.Size = new System.Drawing.Size(100, 20);
            this.placeHolderTextBox2.TabIndex = 2;
            // 
            // connectionSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 143);
            this.Controls.Add(this.placeHolderTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.placeHolderTextBox1);
            this.Name = "connectionSetter";
            this.Text = "connectionSetter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Misc.PlaceHolderTextBox placeHolderTextBox1;
        private System.Windows.Forms.Button button1;
        private Misc.PlaceHolderTextBox placeHolderTextBox2;
    }
}