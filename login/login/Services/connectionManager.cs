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




        private string Gserver;
        private string Fserver;

        public connectionManager()
        {

        }

        /// <summary>
        /// get = a teljes connection string
        /// set = a server értékét átállítja 
        /// </summary>
        public string connectServerG
        {
            get => Gserver;
            set => Gserver = "SERVER =\"" + value + "\";"
                + "DATABASE=\"gastro\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";
        }

        /// <summary>
        /// get = a teljes connection string
        /// set = a server értékét átállítja 
        /// </summary>
        public string connectServerF
        {
            get => Fserver;
            set => Fserver = "SERVER =\"" + value + "\";"
                + "DATABASE=\"felh\";"
                + "UID=\"root\";"
                + "PASSWORD=\"\";"
                + "PORT=\"3306\";";

        }
        public void write()
        {
            

            System.IO.File.WriteAllText(pathG, Gserver);
            System.IO.File.WriteAllText(pathF, Fserver);

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
            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\MyApplication";
            const string REGISTY_VALUE = "x";
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {

                return "SERVER =\"localhost\";"
                  + "DATABASE=\"gastro\";"
                  + "UID=\"root\";"
                  + "PASSWORD=\"\";"
                  + "PORT=\"3306\";";
                    }
            else
                return File.ReadAllText(pathG);
            
        }
        public string readF()
        {
            const string REGISTRY_KEY = @"HKEY_CURRENT_USER\MyApplication";
            const string REGISTY_VALUE = "xx";
            if (Convert.ToInt32(Microsoft.Win32.Registry.GetValue(REGISTRY_KEY, REGISTY_VALUE, 0)) == 0)
            {

                return "SERVER =\"localhost\";"
                  + "DATABASE=\"felh\";"
                  + "UID=\"root\";"
                  + "PASSWORD=\"\";"
                  + "PORT=\"3306\";";
            }
            else
                return File.ReadAllText(pathF);
        }

        
    }
}
