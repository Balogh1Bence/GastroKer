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
    public partial class BoughtItems : Form
    {
        public BoughtItems(DataTable items)
        {
            InitializeComponent();
            dataGridView1.DataSource = items;

        }
    }
}
