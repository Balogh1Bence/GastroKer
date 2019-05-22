using login.Services;
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
    public partial class connectionSetter : Form
    {
        ErrorProvider error;
        connectionManager cm;
        public connectionSetter()
        {
            InitializeComponent();
            cm = new connectionManager();
            button1.DialogResult = DialogResult.OK;
            placeHolderTextBox1.PlaceHolderText = "felhasználók adatbázis IP címe";
            placeHolderTextBox2.PlaceHolderText = "Raktár adatbázis IP címe";
            placeHolderTextBox3.PlaceHolderText = "adatbázis név Felhasználók számára";
            placeHolderTextBox4.PlaceHolderText = "adatbázis név Raktár számára";
            placeHolderTextBox5.PlaceHolderText = "adatbázis felhasználónév felhasználók számára";
            placeHolderTextBox6.PlaceHolderText = "adatbázis felhasználónév Raktár számára";
            placeHolderTextBox7.PlaceHolderText = "adatbázis jelszó felhasználók számára";
            placeHolderTextBox8.PlaceHolderText = "adatbázis jelszó Raktár számára";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.IPAddress ipAddress = null;
            if (placeHolderTextBox1.Text != "localhost" || placeHolderTextBox2.Text != "localhost")
            {


                if (!System.Net.IPAddress.TryParse(placeHolderTextBox1.Text, out ipAddress))
                {
                    error = new ErrorProvider();
                    error.SetError(placeHolderTextBox1, "nem IP cím");
                    if (!System.Net.IPAddress.TryParse(placeHolderTextBox2.Text, out ipAddress))
                    {
                        error = new ErrorProvider();
                        error.SetError(placeHolderTextBox2, "nem IP cím");
                        return;

                    }
                    return;
                }
            }
        }
        public int setCons()
        {
            if (placeHolderTextBox8.Text == placeHolderTextBox8.PlaceHolderText)
            {
                placeHolderTextBox8.setText("");
            }
            if (placeHolderTextBox7.Text == placeHolderTextBox7.PlaceHolderText)
            {
                placeHolderTextBox7.setText("");
            }
            if (placeHolderTextBox5.Text == placeHolderTextBox5.PlaceHolderText)
            {
                placeHolderTextBox5.setText("root");
            }
            if (placeHolderTextBox6.Text == placeHolderTextBox6.PlaceHolderText)
            {
                placeHolderTextBox6.setText("root");
            }
            cm.connectServerF (placeHolderTextBox1.Text,placeHolderTextBox3.Text,placeHolderTextBox5.Text, placeHolderTextBox7.Text);
            cm.connectServerG (placeHolderTextBox2.Text,placeHolderTextBox4.Text,placeHolderTextBox6.Text,placeHolderTextBox8.Text);
            cm.write();
            MySqlConnection cnG = new MySqlConnection(cm.readG());
            MySqlConnection cnF = new MySqlConnection(cm.readF());
            try
            {
          
                cnG.Open();
      
            }
            catch(Exception e) {
    

                return 0;
            }

            try
            {

                cnF.Open();
             
            }
            catch(Exception e) {

                return 0;
            }
            return 1;
        }

        private void placeHolderTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
