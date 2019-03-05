using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using login.models;
using login.Services.DatabaseOperations;
namespace Gastro
{
    
    public class vevo
    {
        List<MDVevok> vevok;
        DBOperation d;
      
        public vevo()
        {
            d = new DBOperation();
            vevok = new List<MDVevok>();
            fillCustomersListFromDatabase();

        }
        public void addNewCustomer(int id, MDVevok vevo)
        {
            d.addNewCustomer(id, vevo);
        }
        public int getLastID()
        {
            return d.getLastCustomerID();
        }

        internal DataTable loadCustomers()
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
                MDVevok v = new MDVevok(Tkod, Tnev, Tar, Tkeszl, Tmert, Tkatkod, Tvonkod, Tszavido, Tegalizalte);
                ts.Add(c);
            }

        }
    }

  
}