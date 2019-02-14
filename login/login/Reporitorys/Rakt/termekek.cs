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
        DataTable cDT;
        public termekek()
        {
            ts = new List<MdTermekek>();
            fillCustomersListFromDatabase();
        }

        public DataTable getTsDataTable()
        {
            
            cDT = new DataTable();
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

                cDT.Rows.Add(c.getTkod(), c.getTNev(), c.getTar(), c.getTkeszl(), c.getMert(), c.getTkatkod(), c.getTvonkod(), c.getSzavido(),  c.getTegalizalte());
            }
            return cDT;
        }

        public void editDataSrc(int id, MdTermekek termekek)
        {
           
                
                 ts.removeAt(id); 
                 ts.Insert(id, termekek);
            foreach (MdTermekek c in ts)
            {

                cDT.Rows.Add(c.getTkod(), c.getTNev(), c.getTar(), c.getTkeszl(), c.getMert(), c.getTkatkod(), c.getTvonkod(), c.getSzavido(),  c.getTegalizalte());
            }
                   
                       
                     
                
               
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
                
                int Tkod=Convert.ToInt32(row["Tkod"].ToString());
                string Tnev=row["Tnev"].ToString();
                int Tar= Convert.ToInt32(row["Tar"].ToString());
                int Tkeszl= Convert.ToInt32(row["Tkeszl"].ToString());
                string Tmert = row["Tmert"].ToString();
                int Tkatkod= Convert.ToInt32(row["Tkatkod"].ToString());
                int Tvonkod=Convert.ToInt32(row["Tvonkod"].ToString());
               
                DateTime Tszavido= Convert.ToDateTime(row["Tszavido"].ToString());
                
                
                bool Tegalizalte=Convert.ToBoolean(row["Tegalizalte"].ToString());
                MdTermekek c = new MdTermekek(Tkod, Tnev, Tar, Tkeszl, Tmert, Tkatkod, Tvonkod, Tszavido, Tegalizalte);
                ts.Add(c);
            }
        }
    }
}
