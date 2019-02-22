using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using login.models;
using login.Services.DatabaseOperations;
namespace Gastro
{
    
    public class vevo
    {
        List<MDVevok> vevok;
        DBOperation d;
      
        public vevo()
        {
            d = new DBOperation();
            vevok = new List<MDVevok>();

        }
        public void addNewCustomer(int id, MDVevok vevo)
        {
            d.addNewCustomer(id, vevo);
        }
        public int getLastID()
        {
            return d.getLastCustomerID();
        }

      
    }

  
}