using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.Reporitorys.Rakt;
namespace login.Services
{
    class RktServ
    {
        termekek t = new termekek();

        public DataTable feltolt()
        {
            return t.getTsDataTable();
        }
    }
}
