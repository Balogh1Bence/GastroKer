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
        CustomerService cs = new CustomerService();

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
            sz.ShowDialog();
            if (sz.DialogResult == DialogResult.OK)
            {
                try
                {
                   
                    dataGridView1.DataSource = null;
                   
                    dataGridView1.DataSource = sz.raktnak();
                }
                catch(Exception d) { MessageBox.Show(d.Message); }
                /*rs.modifyData(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), termekek);*/
            }
        }

        private void Rakt_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                dataGridView1.ClearSelection();
                return;
            }
            bool teg = false;
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (dataGridView1.SelectedRows[0].Cells[8].Value.ToString() == "True") { teg = true; }
            MdTermekek termekek = new MdTermekek(
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                , dataGridView1.SelectedRows[0].Cells[1].Value.ToString()
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())
                , dataGridView1.SelectedRows[0].Cells[4].Value.ToString()
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())
                , Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value.ToString())
                , Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[7].Value.ToString())
                , teg);
            rs.moveToNotImportant(termekek, id);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
            int id=rs.getLastId();
            MessageBox.Show(id+"");
            MessageBox.Show("TestRkt");

            Szerk sz = new Szerk(id);
           
            sz.ShowDialog();
            MessageBox.Show("TestRkt");


        }

        private void newPartnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = cs.getLastId();
            AddUsers au = new AddUsers(id);
            au.ShowDialog();
            if (au.DialogResult == DialogResult.OK)
            {
                au.addNewUser();
                

               

               
                
                
                
            }

        }

        private void partnersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Carriers c = new Carriers();
            c.ShowDialog();
        }
    }
}
