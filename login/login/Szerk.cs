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
        int _Sid;
        public Szerk(MdTermekek termekek)
        {
            
            rs = new RktServ();
            this.termekek = termekek;
            InitializeComponent();



            //backGroundBox1.setImg("hegyek.JPG");
            /*foreach (Control c in this.Controls)

            {

                if (c.GetType().ToString() == "System.Windows.Form.PlaceHolderTextBox")

                {

                    

                }

            }*///it wont work.....
            



            button1.DialogResult = DialogResult.OK;
            
            NameHolder.Text = termekek.getTNev();
        
            PriceHolder.Text =termekek.getTar().ToString();
           
            AmmountHolder.Text = termekek.getTkeszl().ToString();
            
            UnitHolder.Text = termekek.getMert();
            
            CodeHolder.Text = termekek.getTkatkod().ToString();

           
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
            MessageBox.Show(_Sid+"");
            MessageBox.Show(rs.getLastId()+"");
            if (_Sid == rs.getLastId())
            {
                MessageBox.Show("WOLOLOOOOOOOOOOO");
                return;
                
            }
            MessageBox.Show("Test WOLOLOOO");
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
        public Szerk(int Sid)
        {
            rs = new RktServ();
            _Sid = Sid;
            InitializeComponent();
            /*
            foreach (PlaceHolderTextBox p in Controls)
            {
                p.styleSetter();
            }*/
            MessageBox.Show("TestRktConst");
            button1.DialogResult = DialogResult.OK;
            NameHolder.PlaceHolderText = "Termék neve";
            PriceHolder.PlaceHolderText = "Termék ára";
            AmmountHolder.PlaceHolderText = "Termék mennyisége";
            UnitHolder.PlaceHolderText = "Termék mértékegysége";
            CodeHolder.PlaceHolderText = "Termék kategória kódja";
            VonCodeHolder.PlaceHolderText = "Termék vonalkódja";
            MessageBox.Show("TestRktConst2");

        }

       
        public DataTable addNewItem()
        {
            bool eg = false;
            if (checkBox1.Checked)
            {
                eg = true;

            }
            else { eg = false; }


            MdTermekek t = new MdTermekek(_Sid, NameHolder.Text, Convert.ToInt32(PriceHolder.Text), Convert.ToInt32(AmmountHolder.Text), UnitHolder.Text, Convert.ToInt32(CodeHolder.Text), Convert.ToInt32(VonCodeHolder.Text), dateTimePicker1.Value, eg);
            return rs.addNewItem(id,t);
        }

        private void backGroundBox1_Click(object sender, EventArgs e)
        {

        }

        private void Szerk_Load(object sender, EventArgs e)
        {

        }
    }
}
