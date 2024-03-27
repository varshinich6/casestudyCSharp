using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.models
{
    public class Lease
    {
        public int leaseID { get; set; }
        public int CustomerId { get; set; }
        public int vehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string type { get; set; }

        

        public Lease() { }

        public Lease(int leaseid, int customerId, int carId, DateTime startDate, DateTime endDate, string Type)
        {
            leaseID = leaseid;
            CustomerId = customerId;
            vehicleId = carId;
            StartDate = startDate;
            EndDate = endDate;
            type = Type;
        }
        public override string ToString()
        {
            return $"leaseID::{leaseID}\t CustomerId::{CustomerId}\t vehicleId::{vehicleId}\t StartDate::{StartDate}\t EndDate::{EndDate}\t type::{type}\t ";
        }

    }
}
