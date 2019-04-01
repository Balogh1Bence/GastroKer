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
using login.Services;
namespace login
{
    public partial class bejelentkezés : Form
    {
        SetProperties sp;
        ErrorProvider uname = new ErrorProvider();
        ErrorProvider pw = new ErrorProvider();
        Rakt rakt;
        us u;
variableChecker uc;
        public bejelentkezés()
        {
            InitializeComponent();
            button3.Hide();
            sp = new SetProperties();
        
            uc = new variableChecker();
          


              
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            u = new us(); ;

            connectionManager cnt = new connectionManager();
          string REGISTRY_KEY = @"HKEY_CURRENT_USER\GastroKer";
            string REGISTRY_VALUE = cnt.keyValue;
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTRY_VALUE, 0)) == 0)
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    Rakt rkt = new Rakt("admin");
                    return;
                }
            }

                if (textBox1.Text == "" || textBox1.Text == null)
            {
                uname.SetError(textBox1, "üres felhasználónév mező");
            }
            else
            {
                if (u.belep(textBox1.Text, textBox2.Text) == 0)
                {
                    rakt = new Rakt(textBox1.Text);
                    try
                    {
                        rakt.Show();
                    }
                    catch { return; }

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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sp.Copy();
           /* MessageBox.Show( uc.getOne("int")+"");
            MessageBox.Show(uc.getOne("long") + "");
            MessageBox.Show(uc.getOne("string") + "");
            MessageBox.Show(uc.getOne("var") + "");*/

            
        }
    }
}
