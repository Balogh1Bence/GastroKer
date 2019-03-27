using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Misc
{
    public static class myDateTimeExtension
    {
        public static string toMysqlFormat(this DateTime dt)
        {
            string st = dt.ToShortDateString();
            
            st = st.Replace('.', '-');
            st = st.TrimEnd('-');



            string uj = "";
            int i = 0;
            while (i < st.Length)
            {
                if (st[i] != ' ')
                {
                    uj += st[i];
                }




                i++;
            }
            return uj;
        }
        
    }
}
