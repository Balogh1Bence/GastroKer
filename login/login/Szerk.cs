using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.models;
namespace login
{
    public partial class Szerk : Form
    {
        public MdTermekek termekek;
        public Szerk(MdTermekek termekek)
        {
            this.termekek = termekek;
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            //Tazon
            //Tnev
            textBox1.Text =termekek.getTar().ToString();
            textBox2.Text = termekek.getTkeszl().ToString();
            //Tmert
            //Tkatkod
            textBox3.Text = termekek.getTvonkod().ToString();
            dateTimePicker1.Value = termekek.getSzavido();
            bool eg = false;
            if (termekek.getTegalizalte() == true)
            {
                eg = true;
                checkBox1.CheckState=CheckState.Checked;

            }
           


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            termekek.setTar(Convert.ToInt32(textBox1.Text));
            termekek.setTkeszl(Convert.ToInt32(textBox2.Text));
            termekek.setTvonkod(Convert.ToInt32(textBox3.Text));
            if(checkBox1.Checked)
            {
                termekek.setTegaliz(true);
            }
            termekek.setTSzavido(dateTimePicker1.Value);
            termekek.setTegaliz(false);

        }
    }
}
