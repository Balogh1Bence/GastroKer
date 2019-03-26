﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gastro;
using login.Services.DatabaseOperations;
using login.Reporitorys.Rakt;
namespace login.Services
{
    class CustomerService
    {
        vevo v= new vevo();
        DBOperation db;
     
      

        internal int getLastId()
        {
            return v.getLastID();
        }

        internal void addNewCustomer(int id,MDVevok vevo)
        {
            
            v.addNewCustomer(id, vevo);

        }

        internal DataTable LoadCustomers()
        {
            return v.loadCustomers();
        }
        internal DataTable LoadOrders(string vevoNev)
        {
          

            return db.customSelector(vevoNev);
        }

        internal void printTax(string vevoNev, DataTable items)
        {
            v.printTax(vevoNev, items);
        }

        internal void reduceTermekek(string vevoNev)
        {
            v.reduceTermekek(vevoNev);
        }
    }
}
