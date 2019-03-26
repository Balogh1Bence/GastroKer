using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.models;
using login.Services.ConnectToMysqlDatabase;
using login.Services.DatabaseOperations;

namespace login.Reporitorys.Rakt
{
    class oldProductRepo
    {
        List<Regitermekek> oldProductsList;
        DataTable oldproductsTable;
        DBOperation ops;
        public oldProductRepo()
        {
            oldproductsTable = new DataTable();
            oldProductsList = new List<Regitermekek>();
           
            fillProductListFromDataTable();
 
        }

        internal DataTable restore(Regitermekek oldOne)
        {
            ops = new DBOperation();
            int i = 0;
            while (i < oldProductsList.Count)
            {
                if (oldProductsList[i].Tkod==oldOne.Tkod)
                {
                    oldProductsList.RemoveAt(i);
                }
                i++;
            }
            ops.moveFromOld(oldOne);
            return getToDataTable();

        }

        public DataTable getToDataTable()
        {
            ops = new DBOperation();

            oldProductsList.Clear();
            fillProductListFromDataTable();
            if (oldProductsList.Count == 0)
            { return null; }
            if (oldproductsTable.Columns.Count > 0)
            {
                int i = 0;

                while (i < oldproductsTable.Columns.Count)
                    oldproductsTable.Columns.RemoveAt(i);

                i++;
            }

            oldproductsTable.Columns.Add("Tkod", typeof(int));
            oldproductsTable.Columns.Add("Tnev", typeof(string));
            oldproductsTable.Columns.Add("Tar", typeof(int));
            oldproductsTable.Columns.Add("Tkeszl", typeof(int));
            oldproductsTable.Columns.Add("Tmert", typeof(string));
            oldproductsTable.Columns.Add("Tkatkod", typeof(int));
            oldproductsTable.Columns.Add("Tvonkod", typeof(int));
            oldproductsTable.Columns.Add("Tszavido", typeof(DateTime));
            
            oldproductsTable.Columns.Add("Tegalizalte", typeof(bool));
         
            foreach (Regitermekek c in oldProductsList)
            {

                oldproductsTable.Rows.Add(c.Tkod, c.Tnev, c.Tar, c.Tkeszl, c.Tmert, c.Tkatkod, c.Tvonkod, c.Tszavido, c.Tegalizalte);
            }
            //ezt egyáltalán nem értem, de pont azt csinálja, ami nekem kellett.
            oldproductsTable = oldproductsTable.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrWhiteSpace(field as string))).CopyToDataTable();
            return oldproductsTable;
        }

        internal DataTable addNewItem(Regitermekek regitermek)
        {
            ops = new DBOperation();
            ops.addNewOldItem(regitermek);
            oldProductsList.Add(regitermek);
            return getToDataTable();
        }
        private void fillProductListFromDataTable()
        {
            ops = new DBOperation();
            Adatbazis a = new Adatbazis();
            MySQLDatabaseInterface mdi = a.kapcsolodas();
            mdi.open();
            string query = "SELECT * FROM regitermekek ";
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
                Regitermekek c = new Regitermekek(Tkod, Tnev, Tar, Tkeszl, Tmert, Tkatkod, Tvonkod, Tszavido, Tegalizalte);
                oldProductsList.Add(c);
            }

        }
    }
}
