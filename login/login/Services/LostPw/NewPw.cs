using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Services.LostPw
{
    public partial class NewPw : Form
    {
        public NewPw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LostPwEmailSender lp = new LostPwEmailSender(placeHolderTextBox1.Text);                
            this.Close();
        }
    }
}
