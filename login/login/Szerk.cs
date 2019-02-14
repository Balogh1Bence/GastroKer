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
using login.Services;

namespace login
{
    public partial class Szerk : Form
    {
        public MdTermekek termekek;
        RktServ rs;
        int id;
        public Szerk(MdTermekek termekek)
        {
            rs = new RktServ();
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
            MessageBox.Show("Test1");
            id=termekek.getTkod();
            MessageBox.Show("Test2");
            termekek.setTar(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Test3");
            termekek.setTkeszl(Convert.ToInt32(textBox2.Text));
            MessageBox.Show("Test4");
            termekek.setTvonkod(Convert.ToInt32(textBox3.Text));
            MessageBox.Show("Test5");
            if (checkBox1.Checked)
            {
                termekek.setTegaliz(true);
                MessageBox.Show("Test6");
            }
            else { termekek.setTegaliz(false); }
            termekek.setTSzavido(dateTimePicker1.Value);
            MessageBox.Show("Test7");
           

           
            

            this.Close();
            

        }
        public DataTable raktnak()
        {
            return rs.modifyData(id, termekek);
        }
    }
}
