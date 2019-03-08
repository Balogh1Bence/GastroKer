using login.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.validator
{
    public static class NoNumber
    {
        public static bool ContainsNumber(this PlaceHolderTextBox st)
        {
            foreach (Char c in st.Text)
            {
                if (Char.IsNumber(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
