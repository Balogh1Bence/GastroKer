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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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

                    //jó, de mibe töltsem bele?
                    bi=new BoughtItems(
                    cs.LoadOrders(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()));
                    bi.Show();
                }
                else return;
            }
            catch
            { return; }

        }
    }
}
