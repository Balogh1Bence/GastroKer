using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.models;

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
            string query = "SELECT * FROM termekek ";
            DataTable dtCustomer = mdi.getToDataTable(query);
            mdi.close();

            foreach (DataRow row in dtCustomer.Rows)
            {

                int Tkod = Convert.ToInt32(row["Tkod"].ToString());
                string Tnev = row["Tnev"].ToString();
                int Tar = Convert.ToInt32(row["Tar"].ToString());
                int Tkeszl = Convert.ToInt32(row["Tkeszl"].ToString());
                string Tmert = row["Tmert"].ToString();
                int Tkatkod = Convert.ToInt32(row["Tkatkod"].ToString());
                int Tvonkod = Convert.ToInt32(row["Tvonkod"].ToString());

                DateTime Tszavido = Convert.ToDateTime(row["Tszavido"].ToString());


                bool Tegalizalte = Convert.ToBoolean(row["Tegalizalte"].ToString());
                MdTermekek c = new MdTermekek(Tkod, Tnev, Tar, Tkeszl, Tmert, Tkatkod, Tvonkod, Tszavido, Tegalizalte);
                ts.Add(c);
            }
        }
    }
}
