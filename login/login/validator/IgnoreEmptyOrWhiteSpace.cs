using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.validator
{
    class IgnoreEmptyOrWhiteSpace
    {
        public bool isNull(string text)
        {
           
            if (String.IsNullOrWhiteSpace(text))
            {

                return true;
                
            }
            else
            {
                return false;
            }
        }
        public bool AnySpace(string text)
        {
            int i = 0;
            while (i < text.Length - 1)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    return true;
                }
                i++;
            }
            return false;
        }

    }
}
