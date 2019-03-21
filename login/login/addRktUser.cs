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
        bool elsoe;

        public addRktUser()
        {
            elsoe = false;
            placeHolderTextBox4.Hide();
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            placeHolderTextBox1.PlaceHolderText = "felhasználónév";
            placeHolderTextBox2.PlaceHolderText = "jelszó";
            placeHolderTextBox3.PlaceHolderText = "email cím";

        }

        public addRktUser(bool v)
        {
            InitializeComponent();
            elsoe = v;
            if (v == true)
                placeHolderTextBox4.PlaceHolderText = "Admin jelszava";
            button1.DialogResult = DialogResult.OK;
            placeHolderTextBox1.PlaceHolderText = "felhasználónév";
            placeHolderTextBox2.PlaceHolderText = "jelszó";
            placeHolderTextBox3.PlaceHolderText = "email cím";
            
        }

        internal void addNewUser()
        {
            if (elsoe == true)
            {
                if (placeHolderTextBox4.Text != "")
                {
                    MySqlConnection con = new MySqlConnection("server='localhost';database='felh';uid='root';pwd='';");
                    con.Open();
                    string query = "UPDATE `deskusers` SET `password`=" + placeHolderTextBox4.Text + " WHERE username='admin'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                else return;
            }
            MySqlConnection con = new MySqlConnection("server='localhost';database='felh';uid='root';pwd='';");
            con.Open();
            string query = "INSERT INTO `deskusers`(`username`, `password`, `email`, `utols`, `jog`) VALUES ('" + placeHolderTextBox1.Text + "','" + placeHolderTextBox2.Text + "','" + placeHolderTextBox3.Text + "','" + "2019-01-01" + "', '" + comboBox1.SelectedItem + "')";
            MySqlCommand cmd = new MySqlCommand(query, con);
         
            cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
