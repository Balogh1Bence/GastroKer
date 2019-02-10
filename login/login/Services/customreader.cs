using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace login.Services
{
    class customreader
    {
        string con = "server=127.0.0.1;uid=root;pwd=;database=test";
        MySqlConnection c = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand("select * from gastro");
        DataTable dt;
        public DataTable loader()
        {
            MySqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                string d1 = dr["Tszavido2"].ToString();
                string d2 = dr["Tszavido3"].ToString();
            }
            return dt;
        }


    }
}
