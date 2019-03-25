using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.models;
using login.Reporitorys.Rakt;

namespace login.Services
{
    class oldProductServ
    {
        oldProductRepo OPR = new oldProductRepo();
        internal DataTable addNewItem(Regitermekek regitermek)
        {
           
            return OPR.addNewItem(regitermek);
        }

        internal DataTable getAll()
        {
            return OPR.getToDataTable();
        }
    }
}
