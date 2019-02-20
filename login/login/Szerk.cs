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
using login.Misc;

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
           
            
           
            backGroundBox1.setImg("hegyek.JPG");

            foreach (PlaceHolderTextBox p in Controls)
            {
                p.styleSetter();
            }

            button1.DialogResult = DialogResult.OK;
            NameHolder.Text = termekek.getTNev();
         
            PriceHolder.Text =termekek.getTar().ToString();
            AmmountHolder.Text = termekek.getTkeszl().ToString();
            //Tmert
            //Tkatkod
            VonCodeHolder.Text = termekek.getTvonkod().ToString();
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
            if (id != null)
            {
                addNewItem();
                MessageBox.Show("TestSzerk0");
                return;
            }
            id=termekek.getTkod();
            
            termekek.setTar(Convert.ToInt32(PriceHolder.Text));
            
            termekek.setTkeszl(Convert.ToInt32(AmmountHolder.Text));
            
            termekek.setTvonkod(Convert.ToInt32(VonCodeHolder.Text));
            
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

            foreach (PlaceHolderTextBox p in Controls)
            {
                p.styleSetter();
            }
            rs = new RktServ();
            NameHolder.PlaceHolderText = "Termék neve";
            PriceHolder.PlaceHolderText = "Termék ára";
            AmmountHolder.PlaceHolderText = "Termék mennyisége";
            UnitHolder.PlaceHolderText = "Termék mértékegysége";
            CodeHolder.PlaceHolderText = "Termék kategória kódja";
            VonCodeHolder.PlaceHolderText = "Termék vonalkódja";

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        internal void addNewItem()
        {
            bool eg = false;
            if (checkBox1.Checked)
            {
                eg= true;

            }
            else { eg = false; }

            MessageBox.Show("TestSzerk1");
            MdTermekek t = new MdTermekek(id,NameHolder.Text,Convert.ToInt32(PriceHolder.Text), Convert.ToInt32(AmmountHolder.Text), UnitHolder.Text,Convert.ToInt32(CodeHolder.Text),Convert.ToInt32(VonCodeHolder.Text), dateTimePicker1.Value,eg);
            MessageBox.Show("TestSzerk2");
            rs.addNewItem(id, t);


        }

        private void backGroundBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
