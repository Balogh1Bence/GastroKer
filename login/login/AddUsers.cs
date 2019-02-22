using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gastro;
using login.Services;

namespace login
{
    public partial class AddUsers : Form
    {
        MDVevok vevo;
        CustomerService cs;
        int id;
        public AddUsers(int id)
        {
            this.id = id;
            cs = new CustomerService();
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            placeHolderTextBox1.PlaceHolderText = "felhasználónév";
            placeHolderTextBox2.PlaceHolderText = "jelszó";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vevo = new MDVevok(id, placeHolderTextBox1.Text, placeHolderTextBox2.Text);
        }
        public void addNewUser()
        {
            cs.addNewCustomer(id, vevo);

        }
    }
}
