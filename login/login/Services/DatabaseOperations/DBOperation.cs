using Gastro;
using login.models;
using login.Services.ConnectToMysqlDatabase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Misc;
namespace login.Services.DatabaseOperations
{
    class DBOperation
    {
        string conG;
        string conF;
       

        public DBOperation()
        {
         
            this.conG = "SERVER =\"localhost\";"
                 + "DATABASE=\"gastro\";"
                 + "UID=\"root\";"
                 + "PASSWORD=\"\";"
                 + "PORT=\"3306\";"; 
            this.conF = "SERVER=\"localhost\";"
                + "DATABASE=\"gastro\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
        }

        internal string getAddress(string vevoNev)
        {
            throw new NotImplementedException();
        }

        internal List<int> getPriceOfItems(string vevoNev)
        {
            vevoNev = '"' + vevoNev + '"';
            List<int> arak= new List<int>();
            MySqlConnection connect = new MySqlConnection(conG);
            connect.Open();
            string query = "select Tar*Tmenny as ar from rend, termekek where rend.Tkod=termekek.Tkod and rend.Vnev="+vevoNev+" ";
            MessageBox.Show(query);
            MySqlCommand cm = new MySqlCommand(query, connect);
        
            MySqlDataReader dr = cm.ExecuteReader();


            int i = 0;
            while (dr.Read())
            {

                arak.Add(Convert.ToInt32(dr["ar"].ToString()));
                i++;


            }
            connect.Close();
            return arak;
        }

        public DataTable customSelector(string vevo)
        {
            DataTable dt = new DataTable();

            MySqlConnection connect = new MySqlConnection(conG);
            vevo = '"' + vevo + '"';
            connect.Open();
            string query = "SELECT Tnev, Tmenny, Vnev, Vdate FROM rend, termekek where rend.Tkod=termekek.Tkod and  Vnev = " + vevo + " and Tmenny !=0 order by Vdate desc";


            MySqlCommand cm = new MySqlCommand(query, connect);



            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dt);
            connect.Close();

            return dt;
        }
        public void update(int id, MdTermekek t)
        {
            
            MySqlConnection connect = new MySqlConnection(conG);
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw new Exception("Sikertelen adatbázismegnyitás.");
            }

            DateTime dt = t.getSzavido();

            string uj=dt.toMysqlFormat();
            


            string query = "UPDATE `termekek` SET `Tkod`=" + t.getTkod() + ",`Tnev`='" + t.getTNev() + "',`Tar`=" + t.getTar() + ",`Tkeszl`=" + t.getTkeszl() + ",`Tmert`='" + t.getMert() + "',`Tkatkod`=" + t.getTkatkod() + ",`Tvonkod`=" + t.getTvonkod() + ",`Tszavido`='" + uj + "',`Tegalizalte`=" + t.getTegalizalte() + " WHERE Tkod=" + id + "";
            //a lekérdezés jó. máshol van a hiba



            try
            {
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();


            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);


            }
            connect.Close();
        }

        internal DataTable SzuresNevAlapjan(string text)
        {
            text += "%";
            text = '"' + text + '"';
            
            
            MySqlConnection connect = new MySqlConnection(conG);
            DataTable dt = new DataTable();
            connect.Open();
            string query = "SELECT * FROM termekek where Tnev like "+text+"";
           

            MySqlCommand cm = new MySqlCommand(query, connect);
         
            
            
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dt);
            connect.Close();
            
            return dt;
        }

        internal void addNewCustomer(int id, MDVevok ujvevo)
        {
            
            
            MySqlConnection connect = new MySqlConnection(conG);
            connect.Open();
            string query= "INSERT INTO `vevok` (`azon`, `nev`, `adoazon`, `banksz`, `tel`, `dolg`, `torzs`, `vasmenny`, `felh`, `jelsz`, `email`) VALUES ('"+id+"', '', '', '', '', '', '', '', '"+ujvevo.Felh+"', '"+ujvevo.Jelsz+"', '')";
            MySqlCommand cm = new MySqlCommand(query, connect);
            cm.ExecuteNonQuery();
            connect.Close();
        }

        internal void MoveToOld(MdTermekek termekek, int id)
        {
            MySqlConnection connect = new MySqlConnection(conG);
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw new Exception("Sikertelen adatbázismegnyitás.");
            }

            DateTime dt = termekek.getSzavido();


            string uj = dt.toMysqlFormat();

           


            string query = "INSERT INTO `regitermekek` (`Tkod`, `Tnev`, `Tar`, `Tkeszl`, `Tmert`, `Tkatkod`, `Tvonkod`, `Tszavido`, `Tegalizalte`) VALUES ('" + termekek.getTkod() + "', '" + termekek.getTNev() + "', '" + termekek.getTar() + "', '" + termekek.getTkeszl() + "', '" + termekek.getMert() + "', '" + termekek.getTkatkod() + "', '" + termekek.getTvonkod() + "', '" + termekek.getSzavido() + "', '" + termekek.getTegalizalte() + "')";




            try
            {
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();


            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);


            }
            string dquery = "DELETE FROM `termekek` WHERE id=" + termekek.getTkod() + "";
            MySqlCommand cmd = new MySqlCommand(dquery, connect);
            cmd.ExecuteNonQuery();
            connect.Close();

        }

        internal void addNewItem(int id, MdTermekek termekek)
        {
            MySqlConnection connect = new MySqlConnection(conG);
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw new Exception("Sikertelen adatbázismegnyitás.");
            }

            DateTime dt = termekek.getSzavido();


            string uj = dt.toMysqlFormat();

         


            string query = "INSERT INTO `termekek` (`Tkod`, `Tnev`, `Tar`, `Tkeszl`, `Tmert`, `Tkatkod`, `Tvonkod`, `Tszavido`, `Tegalizalte`) VALUES ('" + termekek.getTkod() + "', '" + termekek.getTNev() + "', '" + termekek.getTar() + "', '" + termekek.getTkeszl() + "', '" + termekek.getMert() + "', '" + termekek.getTkatkod() + "', '" + termekek.getTvonkod() + "', '" + termekek.getSzavido() + "', '" + termekek.getTegalizalte() + "')";
            MySqlCommand cmd = new MySqlCommand(query,connect);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        public int getLastCustomerID()
        {
            MySqlConnection connect = new MySqlConnection(conG);
            MessageBox.Show(connect.ConnectionString);
            connect.Open();
            
           
                
               
            
            string query = "select azon from vevok order by azon desc limit 1";



            int id = 0;
            try
            {
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();
                MySqlDataReader dr = cm.ExecuteReader();
                string remelemnemures = string.Empty;


                while (dr.Read())
                {

                    id = Convert.ToInt32(dr["azon"]);



                }






            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);


            }
            connect.Close();
            return id + 1;
            
        }
        public int getLastUserID()
        {
            MySqlConnection connect = new MySqlConnection(conF);
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {

                throw new Exception("Sikertelen adatbázismegnyitás.");
            }
            string query = "select azon from deskusers order by azon desc limit 1";



            int id = 0;
            try
            {
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();
                MySqlDataReader dr = cm.ExecuteReader();
                string remelemnemures = string.Empty;


                while (dr.Read())
                {

                    id = Convert.ToInt32(dr["azon"]);



                }






            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);


            }

            connect.Close();
            return id+1;
        }
        internal int getLastID()
        {
            
            MySqlConnection connect = new MySqlConnection(conG);
             connect.Open();
            
            
            
           

           


            string query = "select Tkod from termekek order by tkod desc limit 1";



            int id = 0;
            try
            {
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();
                MySqlDataReader dr = cm.ExecuteReader();
                string remelemnemures = string.Empty;
              

                    while (dr.Read())
                    {

                         id= Convert.ToInt32(dr["Tkod"]);
                    


                    }



                


            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);


            }
            return id+1;
        }
    }
}
