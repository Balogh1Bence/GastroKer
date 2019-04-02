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
using login.WebSite;

namespace login.Reporitorys.Rakt
{
    class termekek
    {
        MdTermekek mdt;
        List<MdTermekek> productsList;
        DataTable productsTable;
        oldProducts od;
        DataTable dtCustomer;
        DBOperation ops;
        public termekek()
        {
            od = new oldProducts();

            productsTable = new DataTable();
            productsList = new List<MdTermekek>();
            fillProductListFromDataTable();
        }

        public DataTable getToDataTable()
        {
            ops = new DBOperation();
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
            ops = new DBOperation();
            return ops.SzuresNevAlapjan(text);
        }

        internal DataTable addNewItem(int id, MdTermekek t)
        {
            ops = new DBOperation();

            ops.addNewItem(id, t);
            productsList.Add(t);
            return getToDataTable();
        }

        internal int getLastID()
        {
            ops = new DBOperation();
            return ops.getLastID();
        }

        internal DataTable moveTo(MdTermekek termekek, int id)
        {
            ops = new DBOperation();
            int i=0;
            while (i < productsList.Count)
            {
                if (termekek.getTkod() == productsList[i].getTkod())
                {
                    MessageBox.Show("Test");

                    var selected = termekek;

                    od.AddNew(new Regitermekek(selected.getTkod(), selected.getTNev(), selected.getTar(), selected.getTkeszl(), selected.getMert(), selected.getTkatkod(), selected.getTvonkod(), selected.getSzavido(), selected.getTegalizalte()));

                    ops.MoveToOld(termekek);
                    productsList.RemoveAt(id - 1);



                }
                i++;
            }

            return ops.getPrdcts(); 
        }

        public DataTable editDataSrc( int id,MdTermekek termekek)
        {

            ops = new DBOperation();



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
            ops = new DBOperation();
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
            ops = new DBOperation();
            productsList.Add(newCustomer);
        }

        private void fillProductListFromDataTable()
        {
            ops = new DBOperation();
            dtCustomer= ops.getAllProduct();
             
          
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
