using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using login.Services.DatabaseOperations;
using System.IO;
using login.Misc;
using login.Services;

namespace login
{
    public partial class BoughtItems : Form
    {
        DataTable items;
        CustomerService cs;
        string vevoNev;
 
        public BoughtItems(DataTable _items, string _vevoNev)
        {
            items = _items;
            vevoNev = _vevoNev;
            InitializeComponent();

            cs = new CustomerService();
            dataGridView1.DataSource = items;
            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cs.printTax(vevoNev, items);
            cs.reduceTermekek(vevoNev);

            
        }

        private void BoughtItems_Load(object sender, EventArgs e)
        {

        }
    }
}
