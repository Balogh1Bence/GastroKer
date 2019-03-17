using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace login
{
    public partial class addRktUser : Form
    {
        public addRktUser()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            placeHolderTextBox1.PlaceHolderText = "felhasználónév";
            placeHolderTextBox2.PlaceHolderText = "jelszó";
            placeHolderTextBox3.PlaceHolderText = "email cím";
            
        }

        internal void addNewUser()
        {
            MySqlConnection con = new MySqlConnection("svr='localhost';db='felh';uid='root';pwd='';");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `deskusers`(`username`, `password`, `email`, `utols`, `jog`) VALUES ("+placeHolderTextBox1.Text+","+placeHolderTextBox2.Text+","+placeHolderTextBox3.Text+","+"2019-01-01"+", "+comboBox1.SelectedText+")", con);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
