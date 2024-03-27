using casestudy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.Service
{
    internal interface ICustomerManagement
    {
        void AddCustomer();
        void RemoveCustomer();
        public void ListCustomers();

        public void FindCustomerById();
    }
}
