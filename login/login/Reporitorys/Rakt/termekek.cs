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
        MdTermekek mdt;
        List<MdTermekek> productsList;
        DataTable productsTable;
        
        List<Regitermekek> oldProductsList;
        DBOperation ops;
        public termekek()
        {
            oldProductsList = new List<Regitermekek>();
            ops = new DBOperation();
            productsTable = new DataTable();
            productsList = new List<MdTermekek>();
            fillProductListFromDataTable();
        }

        public DataTable getToDataTable()
        {
            productsList.Clear();
            fillProductListFromDataTable();

            if (productsTable.Columns.Count > 0) {
                int i = 0;
    
                while (i < productsTable.Columns.Count)
                    productsTable.Columns.RemoveAt(i);
        
                i++;
                    }
           
            productsTable.Columns.Add("Tkod", typeof(int));
            productsTable.Columns.Add("Tnev", typeof(string));
            productsTable.Columns.Add("Tar", typeof(int));
            productsTable.Columns.Add("Tkeszl", typeof(int));
            productsTable.Columns.Add("Tmert", typeof(string));
            productsTable.Columns.Add("Tkatkod", typeof(int));
            productsTable.Columns.Add("Tvonkod", typeof(int));
            productsTable.Columns.Add("Tszavido", typeof(DateTime));
            
            productsTable.Columns.Add("Tegalizalte", typeof(bool));
            foreach (MdTermekek c in productsList)
            {

                productsTable.Rows.Add(c.getTkod(), c.getTNev(), c.getTar(), c.getTkeszl(), c.getMert(), c.getTkatkod(), c.getTvonkod(), c.getSzavido(),  c.getTegalizalte());
            }
            //ezt egyáltalán nem értem, de pont azt csinálja, ami nekem kellett.
            productsTable = productsTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull ||string.IsNullOrWhiteSpace(field as string))).CopyToDataTable();
            return productsTable;
        }

        internal DataTable SzuresNevAlapjan(string text)
        {
         
            return ops.SzuresNevAlapjan(text);
        }

        internal DataTable addNewItem(int id, MdTermekek t)
        {

            ops.addNewItem(id, t);
            productsList.Add(t);
            return getToDataTable();
        }

        internal int getLastID()
        {
            return ops.getLastID();
        }

        internal DataTable moveTo(MdTermekek termekek, int id)
        {
            ops.MoveToOld(termekek, id);
            foreach (MdTermekek c in productsList)
            {
                if(id==c.getTkod())
                {
                    
                    var selected = productsList[id-1];
       
                    oldProductsList.Add(new Regitermekek(selected.getTkod(),selected.getTNev(), selected.getTar(), selected.getTkeszl(), selected.getMert(), selected.getTkatkod(), selected.getTvonkod(), selected.getSzavido(), selected.getTegalizalte()));
                    productsList.RemoveAt(id-1);
                    
                    
                }
            }
           
            
            return getToDataTable();
        }

        public DataTable editDataSrc( int id,MdTermekek termekek)
        {





            foreach (MdTermekek product in productsList)
            {
                

                if (product.getTkod() == id)
                {

                    MessageBox.Show("Test");

                    product.setTkod(id);
                    product.setTnev(termekek.getTNev());

                    product.setTar(termekek.getTar());
                    product.setTkeszl(termekek.getTkeszl());
                    product.setTmert(termekek.getMert());
         
                    product.setTkatkod(termekek.getTkatkod());
                    product.setTvonkod(termekek.getTvonkod());
                    product.setTSzavido(termekek.getSzavido());
                    product.setTegaliz(termekek.getTegalizalte());

                    
                }
            }
            ops.update(id, termekek);
    
            return getToDataTable();                                                
        }

        public bool checkExist(MdTermekek newT)
        {
            foreach (MdTermekek c in productsList)
            {
                if (c.getTkod() == newT.getTkod())
                {
                    return true;
                }
            }

            return false;

        }

        internal void addProduct(MdTermekek newCustomer)
        {
            productsList.Add(newCustomer);
        }

        private void fillProductListFromDataTable()
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
                productsList.Add(c);
            }

        }
    }
}
