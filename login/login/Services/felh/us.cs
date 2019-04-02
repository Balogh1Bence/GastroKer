using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace login.Services.fleh
{
    class us
    {
        public string emailOfUser(string username)
        {

            string name = username;
            string mail = "";

            string con = "SERVER=\"localhost\";"
                + "DATABASE=\"felh\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
            connectionManager cm = new connectionManager();
            con = cm.readF();
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


            string query = "SELECT email from deskusers where username like '" + name + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    mail = dr["email"].ToString();

                }




            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);


            }
            return mail;
        }
        public string getRights(string uname)
        {
            string con = "SERVER=\"localhost\";"
               + "DATABASE=\"felh\";"
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
            string priv = "";
            string query = "SELECT jog from deskusers where username='" + uname + "'";
            MySqlCommand cmd = new MySqlCommand(query, connect);
            MySqlDataReader dr = cmd.ExecuteReader();
            string remelemnemures = string.Empty;
            try
            {

                while (dr.Read())
                {

                    priv= dr["jog"].ToString();

                   
                }



            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);


            }
            return priv;

        }

        public int belep(string username, string password)
        {
            string uname = username;

            string pw = password;
            string RealPW = null;
            string con = "SERVER=\"localhost\";"
               + "DATABASE=\"felh\";"
               + "UID=\"root\";"
               + "PASSWORD=\"\";"
               + "PORT=\"3306\";";
            connectionManager cm = new connectionManager();
            con = cm.readF();
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
            string query = "SELECT password from deskusers where username='" + uname + "'";
            MySqlCommand cmd = new MySqlCommand(query, connect);
            MySqlDataReader dr = cmd.ExecuteReader();
            string remelemnemures = string.Empty;
            try
            {

                while (dr.Read())
                {

                    RealPW = dr["password"].ToString();

                    remelemnemures = RealPW;

                }



            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);


            }
            /*
           hibakódok:
           0: minden jó
           1: nem jó jelszó
           2: nincs ilyen felhasználónév
           3: üres jelszó mező
           4: üres felhasználónév
            */
            if (uname == null)
            {
                return 4;
            }
            if (RealPW != null)
            {
                if (RealPW == pw)
                {
                    return 0;
                }
            }
            if (string.IsNullOrEmpty(password))
            { return 3; }
            if (string.IsNullOrEmpty(remelemnemures))
            {
                return 2;
            }
            if (RealPW != pw)
            {
                return 1;
            }



            return 0;
        }
    }
}

