using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.models
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public int LeaseID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }

        public Payment(int paymentID, int leaseID, DateTime paymentDate, double amount)
        {
            PaymentID = paymentID;
            LeaseID = leaseID;
            PaymentDate = paymentDate;
            Amount = amount;
        }

        public Payment()
        {
        }

        public void RecordPayment(Lease lease, double amount)
        {
                
            Console.WriteLine($"Recording payment of {amount} for lease {lease.leaseID}");
        }

        //public override string ToString()
        //{
        //    return $"PaymentID::{PaymentID}\t LeaseID::{LeaseID}\t  PaymentDate::{PaymentDate}\t Amount::{Amount}";
        //}
    }

}


