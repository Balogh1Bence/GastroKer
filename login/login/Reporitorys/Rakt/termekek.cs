using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.models;
using login.Services.ConnectToMysqlDatabase;
namespace login.Reporitorys.Rakt
{
    class termekek
    {
        List<MdTermekek> ts;

        public termekek()
        {
            ts = new List<MdTermekek>();
            fillCustomersListFromDatabase();
        }

        public DataTable getTsDataTable()
        {
            
            DataTable cDT = new DataTable();
            cDT.Columns.Add("Tkod", typeof(int));
            cDT.Columns.Add("Tnev", typeof(string));
            cDT.Columns.Add("Tar", typeof(int));
            cDT.Columns.Add("Tkeszl", typeof(int));
            cDT.Columns.Add("Tmert", typeof(string));
            cDT.Columns.Add("Tkatkod", typeof(int));
            cDT.Columns.Add("Tvonkod", typeof(int));
            cDT.Columns.Add("Tszavido", typeof(DateTime));
            cDT.Columns.Add("Tegalizalte", typeof(bool));










            

            foreach (MdTermekek c in ts)
            {

                cDT.Rows.Add(c.getTkod(), c.getTNev(), c.getTar(), c.getTkeszl(), c.getMert(), c.getTkatkod(), c.getTvonkod(), c.getSzavido(), c.getTegalizalte());
            }
            return cDT;
        }

        public bool checkExist(MdTermekek newT)
        {
            foreach (MdTermekek c in ts)
            {
                if (c.getTkod() == newT.getTkod())
                {
                    return true;
                }
            }

            return false;

        }

        internal void addCustomer(MdTermekek newCustomer)
        {
            ts.Add(newCustomer);
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
                int customerID = Convert.ToInt32(row["vazon"].ToString());
                string customerName = row["vnev"].ToString();
                string customerAddress = row["vcim"].ToString();
                int Tkod;
                string Tnev;
                int Tar;
                int Tkeszl;
                string Tmert;
                int Tkatkod;
                int Tvonkod;
                DateTime Tszavido;
                bool Tegalizalte;
                MdTermekek c = new MdTermekek();
                ts.Add(c);
            }
        }
    }
}
