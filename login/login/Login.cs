using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Misc;
using login.Services.fleh;
using login.Services.LostPw;
namespace login
{
    public partial class Login : Form
    {
        ErrorProvider uname = new ErrorProvider();
        ErrorProvider pw = new ErrorProvider();
        public Login()
        {
            InitializeComponent();
            SetProperties sp = new SetProperties();
            sp.Copy();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            us u = new us();
            Rakt rakt = new Rakt();
            MessageBox.Show(textBox1.Text);
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                uname.SetError(textBox1, "üres felhasználónév mező");
            }
            else
            {
                if (u.belep(textBox1.Text, textBox2.Text) == 0)
                {
                    rakt.Show();

                }

                if (u.belep(textBox1.Text, textBox2.Text) == 1)
                {
                    pw.SetError(textBox2, "helytelen jelszó");

                }
                else
                {
                    pw.Clear();

                    pw.SetError(textBox2, "");
                }
                if (u.belep(textBox1.Text, textBox2.Text) == 2)
                {
                    uname.SetError(textBox1, "nincs ilyen felhasználónév");


                }
                else
                {
                    uname.Clear();
                    uname.SetError(textBox1, "");
                }
                if (u.belep(textBox1.Text, textBox2.Text) == 3)
                {
                    pw.SetError(textBox2, "üres jeszó mező");


                }
                else
                {

                    pw.Clear();
                    pw.SetError(textBox2, "");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewPw np = new NewPw();
            np.ShowDialog();
            
        }

       
           
        
    }
}
