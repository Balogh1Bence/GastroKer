using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.Reporitorys.Rakt;
using login.models;
namespace login.Services
{
    class RktServ
    {
        termekek t = new termekek();

        public DataTable feltolt()
        {
            return t.getTsDataTable();
        }
        public void modifyData(int id, MdTermekek termekek)
        {
            t.editDataSrc(id, termekek);
        }
    }
}
