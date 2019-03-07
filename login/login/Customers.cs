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
        bool elso;
        public Customers()
        {
            elso = true;
            InitializeComponent();
            dataGridView1.NoSelectedRow();
           
            dataGridView1.ReadOnly = true;
           
            dataGridView1.DataSource = cs.LoadCustomers();

           
          
            
            
        }
      

        private void dgse(object sender, EventArgs e)
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
                    bi = new BoughtItems(
                    cs.LoadOrders(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()), dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                    bi.Show();
                }
                else return;
            }
            catch
            { return; }

        }
    }
}
