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
        public void setCons()
        {
            cm.connectServerF = placeHolderTextBox1.Text;
            cm.connectServerG = placeHolderTextBox2.Text;
            cm.write();
            
        }
    }
}
