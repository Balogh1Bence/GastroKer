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
using System.IO;
using System.Drawing.Printing;
using System.Drawing;

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
        public void createTaxbill(string vevoNev, DataTable items)
        {
            List<int> arak = getPriceOfItems(vevoNev);
            string address = getAddress(vevoNev);

            string toScheme = "";
            toScheme += address;
            toScheme += '\n';
            int i = 0;
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            path += "\\Misc\\scheme.txt";
           

            toScheme += "Termék neve | Rendelt mennyiség | rendelés dátuma | tétel értéke";
            toScheme += '\n';
            while (i < items.Rows.Count - 1)
            {
                DataRow row = items.Rows[i];
                toScheme += row[0].ToString() + " | " + row[1].ToString() + " | " + row[2].ToString() + " | " + row[3].ToString() + " | " + arak[i] + " Forint";
                toScheme += '\n';
                toScheme += "____________________________________________________________________________________________";
                toScheme += '\n';
                i++;

            }
            System.IO.File.WriteAllText(path, toScheme);
           
           

        }
        public bool has550BoughtItems(string vevoNev)
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



            string query = "select vasmenny from vevok where vevok.felh="+vevoNev+"";
            int torzsMenny = 550;
            int jelenlegi = 0;
            MySqlCommand cm = new MySqlCommand(query, connect);
            MySqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                jelenlegi= Convert.ToInt32(dr["vasmenny"].ToString());
            }
            if (jelenlegi < torzsMenny)
            {
                return false;
            }
            else
                {



                connect.Close();
                return true;
            }
        }
        public void increaseVasMenny(string vevoNev)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(conG);
                connect.Open();
      
                string query = "UPDATE `vevok` SET `vasmenny`=vasmenny+ (select sum(rend.Tmenny) as osszeg from rend where rend.Vnev="+vevoNev+" ) WHERE vevok.felh="+vevoNev+" ";
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();



            }
            catch {return; }

        }

        public void reduceTermekek(string vevoNev)
        {
            /*try
            {*/
           
            MySqlConnection connect = new MySqlConnection(conG);
                connect.Open();
            
                string query = "";
                MySqlCommand cm = new MySqlCommand(query, connect);
        
                cm = new MySqlCommand(query, connect);
                vevoNev = '"' + vevoNev + '"';
            increaseVasMenny(vevoNev);
            query ="call szamla("+vevoNev+");";
                cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();
                query = "call mozgatas(" + vevoNev + ");";
            cm = new MySqlCommand(query, connect);
            cm.ExecuteNonQuery();


            query = "UPDATE `szamlatetel` SET nyomtatvae=1 WHERE szamlatetel.vevo="+vevoNev+"";
                cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();

                if (has550BoughtItems(vevoNev))
                {
                    MessageBox.Show("Test2");
                    query = "UPDATE `vevok` SET `torzs`=true WHERE felh=" + vevoNev + "";
                }
                MessageBox.Show("Test3");
                

            /*}
            catch(Exception e) { MessageBox.Show("hiba történt az adatok mozgatása közben: "+e.Message+""); return; }*/
           

        }
        internal string getAddress(string vevoNev)
        {
            string address = "";
            vevoNev = '"' + vevoNev + '"';
            MySqlConnection connect = new MySqlConnection(conG);
            connect.Open();
            string query= "SELECT  concat(irsz,' ', varos,' ', utca,' ', szam) as cim from helyek, vevok where vevok.azon=helyek.IntAzon and vevok.felh="+vevoNev+" limit 1";
            MySqlCommand cm = new MySqlCommand(query, connect);
            MySqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                address = dr["cim"].ToString();
            }
            return address;

        }

        internal List<int> getPriceOfItems(string vevoNev)
        {
            vevoNev = '"' + vevoNev + '"';
            List<int> arak= new List<int>();
            MySqlConnection connect = new MySqlConnection(conG);
            connect.Open();
            string query = "select Tar*Tmenny as ar from rend, termekek where rend.Tkod=termekek.Tkod and rend.Vnev="+vevoNev+" ";
           
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
            string query = "SELECT Tnev, Tmenny, Vnev, Vdate FROM rend, termekek where rend.Tkod=termekek.Tkod and  Vnev = " + vevo + " and Tmenny !=0 and nyomtatvae=0 order by Vdate desc";


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
