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
            System.IO.File.WriteAllText(pathG, Gconnection);
            System.IO.File.WriteAllText(pathF, FConnection);
        }
        public string pathG
        {
            get=> Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Misc\\Gconn.txt";
        }
        public string pathF
        {
            get => Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Misc\\Fconn.txt";
        }
    
        public string readG()
        {
            /*string REGISTRY_KEY = @"HKEY_CURRENT_USER\MyApplication";
             string REGISTY_VALUE = keyValue;
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {

                return "SERVER =\"localhost\";"
                  + "DATABASE=\"gastro\";"
                  + "UID=\"root\";"
                  + "PASSWORD=\"\";"
                  + "PORT=\"3306\";";
                    }
            else*/
                return File.ReadAllText(pathG);
            
        }
        public string readF()
        {
            /*string REGISTRY_KEY = @"HKEY_CURRENT_USER\MyApplication";
            string REGISTY_VALUE = keyValue;
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {

                return "SERVER =\"localhost\";"
                  + "DATABASE=\"felh\";"
                  + "UID=\"root\";"
                  + "PASSWORD=\"\";"
                  + "PORT=\"3306\";";
            }
            else*/
                return File.ReadAllText(pathF);
        }
        public  string keyValue
        {
            get => "tizenegy";
        }
        
    }
}
