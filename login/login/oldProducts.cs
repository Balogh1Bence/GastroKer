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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        internal void AddNew(Regitermekek regitermek)
        {
            dataGridView1.DataSource= OPS.addNewItem(regitermek);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 1)
            {
                dataGridView1.ClearSelection();
                return;
            }
            bool teg = false;

            if (dataGridView1.SelectedRows[0].Cells[8].Value.ToString() == "True") { teg = true; }
            Regitermekek oldOne = new Regitermekek(
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                , dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                , dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString())
                , Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())
                , teg);
            dataGridView1.DataSource= OPS.restore(oldOne);
        }
    }
}
