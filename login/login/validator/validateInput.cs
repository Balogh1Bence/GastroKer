using login.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.validator
{
    public static class validateInput
    {
        public static bool NotContainsNumber(this PlaceHolderTextBox st)
        {
            st.Text = st.Text.Trim();
            foreach (Char c in st.Text)
            {
                if (Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool onlyNumber(this PlaceHolderTextBox st)
        {
            st.Text = st.Text.Trim();
            int i = 0;
            while (i < st.Text.Length)
            {
                if (Char.IsLetter(st.Text[i]))
                {
                    return false;
                }
                i++;
            }
            return true;
        }
    }
}
