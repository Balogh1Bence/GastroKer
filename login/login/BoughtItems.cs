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
using System.IO;
using login.Misc;
namespace login
{
    public partial class BoughtItems : Form
    {
        DataTable items;
        string vevoNev;
        DBOperation db = new DBOperation();
        public BoughtItems(DataTable _items, string _vevoNev)
        {
            items = _items;
            vevoNev = _vevoNev;
            InitializeComponent();
           
            dataGridView1.DataSource = items;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> arak = db.getPriceOfItems(vevoNev);
            /*string address = db.getAddress(vevoNev);*/
            string toScheme = "";
            int i = 0;
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "\\Misc\\scheme.txt";
            MessageBox.Show(path);

            toScheme += "Termék neve | Rendelt mennyiség | rendelés dátuma | tétel értéke";
            while (i < dataGridView1.Rows.Count-1)
            {
                DataRow row = items.Rows[i];
                toScheme += row[0].ToString() + " | " + row[1].ToString() + " | " + row[2].ToString() + " | " + row[3].ToString()+" | "+arak[i]+" Forint";
                toScheme += '\n';
                toScheme += "____________________________________________________________________________________________";
                toScheme += '\n';
                i++;
            }
            System.IO.File.WriteAllText(path, toScheme);

            
        }

    }
}
