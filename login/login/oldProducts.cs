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

namespace login.WebSite
{
    public partial class oldProducts : Form
    {
        oldProductServ OPS;
        public oldProducts()
        {
            InitializeComponent();
           OPS =  new oldProductServ();
            dataGridView1.DataSource = OPS.getAll();
            
        }

        internal void AddNew(Regitermekek regitermek)
        {
            dataGridView1.DataSource= OPS.addNewItem(regitermek);
        }
    }
}
