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


            string query = "UPDATE `termekek` SET `Tkod`="+t.getTkod()+",`Tnev`="+t.getTNev()+",`Tar`="+t.getTar()+",`Tkeszl`="+t.getTkeszl()+",`Tmert`="+t.getMert()+",`Tkatkod`="+t.getTkatkod()+",`Tvonkod`="+t.getTvonkod()+",`Tszavido`="+t.getSzavido()+",`Tegalizalte`="+t.getTegalizalte()+" WHERE id="+id+"";
            try
            {
                MySqlCommand cm = new MySqlCommand(query);
                cm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);


            }
        }
    }
}
