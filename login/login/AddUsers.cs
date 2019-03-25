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
        ErrorProvider Ru;
        ErrorProvider Rp;
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
            Ru = new ErrorProvider();
            Rp = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(placeHolderTextBox1.Text))
            {
                Ru.SetError(placeHolderTextBox1, "üres felhasználónév");

             
            }
            if (string.IsNullOrWhiteSpace(placeHolderTextBox2.Text))
            {
                Rp.SetError(placeHolderTextBox2, "üres jelszó");
                return;
            }
            vevo = new MDVevok(id, placeHolderTextBox1.Text, placeHolderTextBox2.Text);
        }
        public void addNewUser()
        {
            cs.addNewCustomer(id, vevo);

        }
    }
}
