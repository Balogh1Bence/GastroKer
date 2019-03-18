using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Services.ConnectToMysqlDatabase;
using login.Services;
using login.Misc;
namespace login
{
    public partial class Customers : Form
    {
        CustomerService cs = new CustomerService();
        BoughtItems bi;
        public Customers()
        {
            
            InitializeComponent();
            
           
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = cs.LoadCustomers();
           
           
          
            
            
        }
 


        private void changer(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1 != null)
                {
                    if (dataGridView1.SelectedRows.Count > 1)
                    {
                        dataGridView1.ClearSelection();
                        return;
                    }
                    if (dataGridView1.SelectedRows.Count == -1)
                    {
                        dataGridView1.ClearSelection();
                        return;
                    }

                    

                    bi = new BoughtItems(
                    cs.LoadOrders(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()), dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                    bi.Show();
                }
                else return;
            }
            catch
            { return; }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
           
            dataGridView1.ClearSelection();
          
            dataGridView1.SelectionChanged += changer;
           
        }
    }
}
