using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Services;
using login.Services.ConnectToMysqlDatabase;

namespace login
{
    public partial class Carriers : Form
    {
        CarrierService cs;
        public Carriers()
        {
            cs = new CarrierService();
            InitializeComponent();
            dataGridView1.DataSource = cs.Load();
        }
    }
}
