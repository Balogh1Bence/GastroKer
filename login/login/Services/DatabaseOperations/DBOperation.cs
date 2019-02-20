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

namespace login.Services.DatabaseOperations
{
    class DBOperation
    {

        public void update(int id, MdTermekek t)
        {
            string con = "SERVER=\"localhost\";"
                + "DATABASE=\"gastro\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
            MySqlConnection connect = new MySqlConnection(con);
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


            string st = dt.ToShortDateString();

            st = st.Replace('.', '-');
            st = st.TrimEnd('-');



            string uj = "";
            int i = 0;
            while (i < st.Length)
            {
                if (st[i] != ' ')
                {
                    uj += st[i];
                }



                i++;
            }


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
        }

        internal void MoveToOld(MdTermekek termekek, int id)
        {
            string con = "SERVER=\"localhost\";"
                 + "DATABASE=\"gastro\";"
                 + "UID=\"root\";"
                 + "PASSWORD=\"\";"
                 + "PORT=\"3306\";";
            MySqlConnection connect = new MySqlConnection(con);
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


            string st = dt.ToShortDateString();

            st = st.Replace('.', '-');
            st = st.TrimEnd('-');



            string uj = "";
            int i = 0;
            while (i < st.Length)
            {
                if (st[i] != ' ')
                {
                    uj += st[i];
                }



                i++;
            }


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

        }

        internal void addNewItem(int id, MdTermekek termekek)
        {
            string con = "SERVER=\"localhost\";"
                 + "DATABASE=\"gastro\";"
                 + "UID=\"root\";"
                 + "PASSWORD=\"\";"
                 + "PORT=\"3306\";";
            MySqlConnection connect = new MySqlConnection(con);
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


            string st = dt.ToShortDateString();

            st = st.Replace('.', '-');
            st = st.TrimEnd('-');



            string uj = "";
            int i = 0;
            while (i < st.Length)
            {
                if (st[i] != ' ')
                {
                    uj += st[i];
                }     



                i++;
            }


            string query = "INSERT INTO `termekek` (`Tkod`, `Tnev`, `Tar`, `Tkeszl`, `Tmert`, `Tkatkod`, `Tvonkod`, `Tszavido`, `Tegalizalte`) VALUES ('" + termekek.getTkod() + "', '" + termekek.getTNev() + "', '" + termekek.getTar() + "', '" + termekek.getTkeszl() + "', '" + termekek.getMert() + "', '" + termekek.getTkatkod() + "', '" + termekek.getTvonkod() + "', '" + termekek.getSzavido() + "', '" + termekek.getTegalizalte() + "')";

        }

        internal int getLastID()
        {

            string con = "SERVER=\"localhost\";"
                 + "DATABASE=\"gastro\";"
                 + "UID=\"root\";"
                 + "PASSWORD=\"\";"
                 + "PORT=\"3306\";";
            MySqlConnection connect = new MySqlConnection(con);
            try
            {
                connect.Open();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                throw new Exception("Sikertelen adatbázismegnyitás.");
            }

           


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
