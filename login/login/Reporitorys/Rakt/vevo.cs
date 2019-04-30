using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using login.models;
using login.Services.DatabaseOperations;
using login.Services.ConnectToMysqlDatabase;
using login.Services;
using MySql.Data.MySqlClient;

namespace Gastro
{
    
    public class vevo
    {
        List<MDVevok> customers;
        DBOperation d;
      
        public vevo()
        {

            customers = new List<MDVevok>();
            fillCustomersListFromDatabase();

        }
        public void addNewCustomer(int id, MDVevok vevo)
        {
            d = new DBOperation();
            d.addNewCustomer(id, vevo);
        }
        public int getLastID()
        {
            d = new DBOperation();
            return d.getLastCustomerID();
        }

        internal DataTable loadCustomers()
        {
            DataTable customersDataTable = new DataTable();
          
            customersDataTable.Columns.Add("nev", typeof(string));
            customersDataTable.Columns.Add("ado azon", typeof(int));
            customersDataTable.Columns.Add("banksz", typeof(long));
            customersDataTable.Columns.Add("tel", typeof(long));
            customersDataTable.Columns.Add("felh", typeof(string));
            

            
            foreach (MDVevok vevo in customers)
            {

                customersDataTable.Rows.Add(vevo.Nev, vevo.Adoazon, vevo.Banksz, vevo.Tel, vevo.Felh);
            }
            return customersDataTable;
        }

        internal void reduceTermekek(string vevoNev)
        {
            d = new DBOperation();
            d.reduceTermekek(vevoNev);
        }

        internal void printTax(string vevoNev, DataTable items)
        {
            d = new DBOperation();
            d.createTaxbill(vevoNev, items);
        }

        private void fillCustomersListFromDatabase()
        {
            connectionManager cm = new connectionManager();
            /*d = new DBOperation();
            Adatbazis a = new Adatbazis();
            MySQLDatabaseInterface mdi = a.kapcsolodas();
            mdi.open();
            string query = "SELECT * FROM vevok ";
             = mdi.getToDataTable(query);
            mdi.close();*/
            string query = "select * from vevok";
            MySqlConnection con = new MySqlConnection(cm.readG());
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            DataTable dtCustomer = new DataTable();
            dp.Fill(dtCustomer);
           
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
                customers.Add(v);
            }

        }
    }

  
}