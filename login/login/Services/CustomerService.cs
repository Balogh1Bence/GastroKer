using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gastro;
using login.Reporitorys.Rakt;
namespace login.Services
{
    class CustomerService
    {
        vevo v= new vevo();

     
      

        internal int getLastId()
        {
            return v.getLastID();
        }

        internal void addNewCustomer(int id,MDVevok vevo)
        {
            
            v.addNewCustomer(id, vevo);

        }
    }
}
