﻿using login.models;
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
           
            st=st.Replace('.', '-');
            st=st.TrimEnd('-');
         

           
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
           

            string query = "UPDATE `termekek` SET `Tkod`="+t.getTkod()+",`Tnev`='"+t.getTNev()+"',`Tar`="+t.getTar()+",`Tkeszl`="+t.getTkeszl()+",`Tmert`='"+t.getMert()+"',`Tkatkod`="+t.getTkatkod()+",`Tvonkod`="+t.getTvonkod()+",`Tszavido`='"+uj+"',`Tegalizalte`="+t.getTegalizalte()+" WHERE Tkod="+id+"";
           //a lekérdezés jó. máshol van a hiba
            
            
           
            try
            {
                MySqlCommand cm = new MySqlCommand(query, connect);
                cm.ExecuteNonQuery();
                MessageBox.Show(connect.State + "");

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Test2");
                Debug.WriteLine(e.Message);


            }
        }
    }
}
