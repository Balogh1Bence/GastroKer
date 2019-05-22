using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Services
{
    /// <summary>
    /// Az osztályban először setelni kell a strinngeket, majd a write eljárást hazsnálva létre kell hozni a fájlt, amiből be lesznek olvasva a connectionstringek.
    /// Ez után a readG és a readF éri el őket.
    /// </summary>
    class connectionManager
    {
        public string FConnection;
        private string Gconnection;
        /// <summary>
        /// get = a teljes connection string
        /// set = a server értékét átállítja 
        /// </summary>     
        public void connectServerF(string Fserver , string Fdb ,string Fuid, string Fpw)
        {
            
            FConnection = "SERVER =\"" + Fserver+ "\";"
                + "DATABASE=\""+Fdb+"\";"
                + "UID=\""+Fuid+"\";"
                + "PASSWORD=\""+Fpw+"\";"
                + "PORT=\"3306\";";
        }
        public void connectServerG(string Gserver, string Gdb, string Guid, string Gpw)
        {

            Gconnection = "SERVER =\"" + Gserver + "\";"
                + "DATABASE=\"" + Gdb + "\";"
                + "UID=\"" + Guid + "\";"
                + "PASSWORD=\"" + Gpw + "\";"
                + "PORT=\"3306\";";
        }
        /// <summary>
        /// get = a teljes connection string
        /// set = a server értékét átállítja 
        /// </summary>
        public void write()
        {
           // System.Diagnostics.Process.Start("/Misc/Gconn.txt");
            System.IO.File.WriteAllText(pathG, Gconnection);
            System.IO.File.WriteAllText(pathF, FConnection);
           
        }
        public string pathG
        {
            set => pathG = value;   
            get=> "..\\..\\Misc\\Gconn.txt";
        }
        public string pathF
        {
            set => pathF = value;
            get => "..\\..\\Misc\\Fconn.txt";
        }
    
        public string readG()
        {
          
            try
            {
                return File.ReadAllText(pathG);
            }
            catch { return File.ReadAllText("Misc\\Gconn.txt"); }
   
         
            
        }
        public string readF()
        {
           
            try
            {
                return File.ReadAllText(pathF);
            }
            catch { return File.ReadAllText("Misc\\Fconn.txt"); }

        }
        public  string keyValue
        {
            get => "GK";
        }
        
    }
}
