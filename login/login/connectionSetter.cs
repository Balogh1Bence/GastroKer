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
        connectionManager cm;
        public connectionSetter()
        {
            InitializeComponent();
            cm = new connectionManager();
            placeHolderTextBox1.PlaceHolderText = "felhasználók adatbázis IP címe";
            placeHolderTextBox2.PlaceHolderText = "Raktár adatbázis IP címe";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm.connectServerF = placeHolderTextBox1.Text;
            cm.connectServerG = placeHolderTextBox2.Text;
            this.Close();
        }
    }
}
