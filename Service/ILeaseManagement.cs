using casestudy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.Service
{
    internal interface ILeaseManagement
    {
        public void CreateLease();
        public void ReturnCar();
        public List<Lease> ListActiveLeases();
        public List<Lease> ListLeaseHistory();
    }
}
