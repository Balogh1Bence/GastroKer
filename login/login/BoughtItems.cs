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

namespace login
{
    public partial class BoughtItems : Form
    {
        string vevoNev;
        DBOperation db = new DBOperation();
        public BoughtItems(DataTable items, string _vevoNev)
        {
            vevoNev = _vevoNev;
            InitializeComponent();
            dataGridView1.DataSource = items;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = db.getPriceOfItems(vevoNev);
            string address = db.getAddress(vevoNev);
        }
    }
}
