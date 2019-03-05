using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.models;
using login.Services.ConnectToMysqlDatabase;

namespace login.Reporitorys
{
    class besz
    {
       
        List<MDBesz> b;
        DataTable cDT;
        public besz()
        {
            cDT = new DataTable();
            b = new List<MDBesz>();
            fillCustomersListFromDatabase();
        }
        public DataTable getTsDataTable()
        {
            int d = 0;




            if (cDT.Columns.Count > 0)
            {
                int i = 0;
                MessageBox.Show(cDT.Columns.Count + "");
                while (i < cDT.Columns.Count)
                    cDT.Columns.RemoveAt(i);
                MessageBox.Show(cDT.Columns.Count + "");
                i++;
            }

         
            
            
            
            
            
            cDT.Columns.Add("azon", typeof(int));
            cDT.Columns.Add("nev", typeof(string));
            cDT.Columns.Add("tel", typeof(int));
            cDT.Columns.Add("email", typeof(string));
            cDT.Columns.Add("kapcsnev", typeof(string));
            












            foreach (MDBesz c in b)
            {

                cDT.Rows.Add(c.Azon, c.Nev, c.Tel, c.Email, c.Kapcsnev);
            }

            cDT = cDT.Rows
    .Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrWhiteSpace(field as string)))
    .CopyToDataTable();
            return cDT;
        }

        private void fillCustomersListFromDatabase()
        {
            Adatbazis a = new Adatbazis();
            MySQLDatabaseInterface mdi = a.kapcsolodas();
            mdi.open();
            string query = "SELECT * FROM besz ";
            DataTable dtCustomer = mdi.getToDataTable(query);
            mdi.close();

            foreach (DataRow row in dtCustomer.Rows)
            {

                MDBesz c = new MDBesz(Convert.ToInt32(row["azon"].ToString()),row["nev"].ToString(),Convert.ToInt32(row["tel"].ToString()),row["email"].ToString(), row["kapcsnev"].ToString());

                b.Add(c);
            }
        }
    }
}
