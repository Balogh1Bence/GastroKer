﻿using System;
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
    class RktServ
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
    }
}
