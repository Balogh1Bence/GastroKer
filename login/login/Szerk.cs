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
            NameHolder.PlaceHolderText = "Termék neve";
            PriceHolder.PlaceHolderText = "Termék ára";
            textBox5.Visible = false;
            button1.DialogResult = DialogResult.OK;
            textBox4.Text = termekek.getTNev();
         
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
            
            id=termekek.getTkod();
            
            termekek.setTar(Convert.ToInt32(textBox1.Text));
            
            termekek.setTkeszl(Convert.ToInt32(textBox2.Text));
            
            termekek.setTvonkod(Convert.ToInt32(textBox3.Text));
            
            if (checkBox1.Checked)
            {
                termekek.setTegaliz(true);
            
            }
            else { termekek.setTegaliz(false); }
            termekek.setTSzavido(dateTimePicker1.Value);
            
           

           
            

            this.Close();
            

        }
        public DataTable raktnak()
        {
            return rs.modifyData(id, termekek);
        }
        public Szerk(int id)
        {
            InitializeComponent();
            textBox5.Visible = true;
           

        }

        internal void addNewItem()
        {
            MdTermekek t = new MdTermekek(id,, textBox1.Text, textBox2,textBox5.Text,);
            rs.addNewItem(id);


        }
    }
}
