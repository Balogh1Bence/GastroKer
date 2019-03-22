using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Services
{
    /// <summary>
    /// pls ne geteld egyiket se setelés előtt. minden set csak a connectionstringnek a server értékét állítja át.
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

        
    }
}
