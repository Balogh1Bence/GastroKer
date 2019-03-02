using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.models;
using login.Services.ConnectToMysqlDatabase;
using login.Services.DatabaseOperations;

namespace login.Reporitorys.Rakt
{
    class termekek
    {
        List<MdTermekek> ts;
        DataTable cDT;
        
        List<Regitermekek> tr;
        DBOperation d;
        public termekek()
        {
            tr = new List<Regitermekek>();
            d = new DBOperation();
            cDT = new DataTable();
            ts = new List<MdTermekek>();
            fillCustomersListFromDatabase();
        }

        public DataTable getTsDataTable()
        {
            int d = 0;
           
                
            

            if (cDT.Columns.Count > 0) {
                int i = 0;
                MessageBox.Show(cDT.Columns.Count+"");
                while (i < cDT.Columns.Count)
                    cDT.Columns.RemoveAt(i);
                MessageBox.Show(cDT.Columns.Count + "");
                i++;
                    }
           
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

            cDT = cDT.Rows
    .Cast<DataRow>()
    .Where(row => !row.ItemArray.All(field => field is DBNull ||string.IsNullOrWhiteSpace(field as string)))
    .CopyToDataTable();
            return cDT;
        }

        internal DataTable SzuresNevAlapjan(string text)
        {
            return d.SzuresNevAlapjan(text);
        }

        internal DataTable addNewItem(int id, MdTermekek t)
        {

            d.addNewItem(id, t);
            ts.Add(t);
            return getTsDataTable();
        }

        internal int getLastID()
        {
            return d.getLastID();
        }

        internal DataTable moveTo(MdTermekek termekek, int id)
        {
            d.MoveToOld(termekek, id);
            foreach (MdTermekek c in ts)
            {
                if(id==c.getTkod())
                {
                    var selected = ts[id];
                    
                    tr.Add(new Regitermekek(selected.getTkod(),selected.getTNev(), selected.getTar(), selected.getTkeszl(), selected.getMert(), selected.getTkatkod(), selected.getTvonkod(), selected.getSzavido(), selected.getTegalizalte()));
                    ts.RemoveAt(id);
                    
                    
                }
            }
           
            
            return getTsDataTable();
        }

        public DataTable editDataSrc( int id,MdTermekek termekek)
        {

            MessageBox.Show(termekek.getTNev());



            foreach (MdTermekek c in ts)
            {

                if (c.getTkod() == id)
                {
                   
                    c.setTkod(id);
                    c.setTnev(termekek.getTNev());

                    c.setTar(termekek.getTar());
                    c.setTkeszl(termekek.getTkeszl());
                    c.setTmert(termekek.getMert());
                    c.setTkatkod(termekek.getTkatkod());
                    c.setTvonkod(termekek.getTvonkod());
                    c.setTSzavido(termekek.getSzavido());
                    c.setTegaliz(termekek.getTegalizalte());

                    
                }
            }
            d.update(id, termekek);
    
            return getTsDataTable(); 
                     
                
               
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
