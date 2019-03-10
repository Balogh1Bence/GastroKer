using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using login.models;
using login.Services.DatabaseOperations;
using login.Services.ConnectToMysqlDatabase;
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
          
            cDT.Columns.Add("nev", typeof(string));
            cDT.Columns.Add("ado azon", typeof(int));
            cDT.Columns.Add("banksz", typeof(long));
            cDT.Columns.Add("tel", typeof(long));
            cDT.Columns.Add("felh", typeof(string));
            

            
            foreach (MDVevok vevo in vevok)
            {

                cDT.Rows.Add(vevo.Nev, vevo.Adoazon, vevo.Banksz, vevo.Tel, vevo.Felh);
            }
            return cDT;
        }

        internal void reduceTermekek(string vevoNev)
        {
            d.reduceTermekek(vevoNev);
        }

        internal void printTax(string vevoNev, DataTable items)
        {

            d.createTaxbill(vevoNev, items);
        }

        private void fillCustomersListFromDatabase()
        {    
            Adatbazis a = new Adatbazis();
            MySQLDatabaseInterface mdi = a.kapcsolodas();
            mdi.open();
            string query = "SELECT * FROM vevok ";
            DataTable dtCustomer = mdi.getToDataTable(query);
            mdi.close();

            foreach (DataRow row in dtCustomer.Rows)
            {

                int azon = Convert.ToInt32(row["azon"].ToString());
                string nev = row["nev"].ToString();
                int adoazon = Convert.ToInt32(row["adoazon"].ToString());
                long banksz = Convert.ToInt64(row["banksz"].ToString());
                long tel = Convert.ToInt64(row["tel"].ToString());
                bool dolg = Convert.ToBoolean(row["dolg"].ToString());
                bool torzs = Convert.ToBoolean(row["torzs"].ToString());
                int vasmenny = Convert.ToInt32(row["vasmenny"].ToString());
                string felh = row["felh"].ToString();
                string jelsz = row["jelsz"].ToString();
                string email = row["email"].ToString();


              
                MDVevok v = new MDVevok(azon, nev, adoazon,banksz,tel, dolg, torzs, vasmenny, felh, jelsz, email);
                vevok.Add(v);
            }

        }
    }

  
}