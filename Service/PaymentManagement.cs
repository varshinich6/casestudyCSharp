using casestudy.DAO;
using casestudy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.Service
{

    
    internal class PaymentManagement : IPaymentManagement
    {
        readonly ICarLeaseRepository _PaymentManagement;
   
        public PaymentManagement ()
        {
            _PaymentManagement = new ICarLeaseRepositoryImpl();
        }


        public void recordPayment()
        {
            Console.WriteLine("Enter payment details:");
            Console.Write("Lease ID: ");
            int leaseID = int.Parse(Console.ReadLine());
            

            Console.Write("Payment Amount: ");
            double amount = double.Parse(Console.ReadLine());
            //Lease lease = _PaymentManagement.ReturnCar(leaseID);
            if(_PaymentManagement.ReturnCar(leaseID) != null )
            {
                int PaymentStatus = _PaymentManagement.RecordPayment(leaseID, amount);
                Console.WriteLine("Payment Recorded Successfully");

            }
            else
            {
                Console.WriteLine("Record Payment Failed , Please Enter A Valid leaseID");
            }
        }
    }
}
