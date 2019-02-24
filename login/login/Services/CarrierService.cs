using login.Reporitorys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Services
{
    class CarrierService
    {
        besz b;
        internal DataTable Load()
        {
            b = new besz();
            return b.getTsDataTable();
        }
    }
}
