using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.Reporitorys.Rakt;
using login.models;
using System.Windows.Forms;

namespace login.Services
{
    public class RktServ
    {
        termekek t = new termekek();

        public DataTable feltolt()
        {
            return t.getTsDataTable();
        }
        public DataTable modifyData( int id,MdTermekek termekek)
        {
            
            DataTable dt = new DataTable();
            dt=t.editDataSrc(id, termekek);
            return dt;

        }
        public DataTable moveToNotImportant(MdTermekek termekek, int id)
        {
            return t.moveTo(termekek, id);
        }

        internal int getLastId()
        {
            return t.getLastID();
        }

        internal void addNewItem(int id, MdTermekek h)
        {
            MessageBox.Show("TestRKTServ0");
            t.addNewItem(id, h);
            MessageBox.Show("TestRktService1");
        }

       
    }
}
