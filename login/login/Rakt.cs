using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Reporitorys.Rakt;
using login.Services;
using login.models;

namespace login
{
    public partial class Rakt : Form
    {
        RktServ rs = new RktServ();

        public Rakt()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= rs.feltolt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                dataGridView1.ClearSelection();
                return;
            }
            bool teg = false;
            MessageBox.Show(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
            if (dataGridView1.SelectedRows[0].Cells[8].Value.ToString()=="True") { teg = true; }
            MdTermekek termekek = new MdTermekek(
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                ,dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                ,Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                ,dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                ,Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString())
                ,Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())
                ,teg);
            Szerk sz = new Szerk(termekek);
            sz.Show();
        }
    }
}
