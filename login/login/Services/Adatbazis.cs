using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace login.Services.ConnectToMysqlDatabase
{
    class Adatbazis
    {
        public MySQLDatabaseInterface kapcsolodas()
        {
            MySQLDatabaseInterface mdi = new MySQLDatabaseInterface();
            mdi.setErrorToUserInterface(true);
            mdi.setErrorToGraphicalUserInterface(false);
            mdi.setConnectionServerData("127.0.0.1", "gastro","3306");
            mdi.setConnectionUserData("root", "");
            mdi.makeConnectionToDatabase();        

            return mdi;
        }
    }
}
