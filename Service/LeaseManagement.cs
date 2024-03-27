using casestudy.DAO;
using casestudy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.Service
{
    
    internal class LeaseManagement : ILeaseManagement
    {
        readonly ICarLeaseRepository _LeaseManagement;
        
        public LeaseManagement()
        {
            _LeaseManagement = new ICarLeaseRepositoryImpl();
        }


        


        public void  CreateLease()
        {
            Console.WriteLine("Enter lease details:");

            Console.Write("Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Car ID: ");
            int carId = int.Parse(Console.ReadLine());

            Console.Write("Start Date (YYYY-MM-DD): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("End Date (YYYY-MM-DD): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.Write("type : ");
            string type = Console.ReadLine();


            int CreateLeaseStatus = _LeaseManagement.CreateLease(customerId, carId, startDate, endDate, type);
            if( CreateLeaseStatus == 1 ) {
                Console.WriteLine("Lease created Successfully");
            }
            else
            {
                Console.WriteLine("Lease not created");
            }

        }


        public void ReturnCar()
        {

            Console.Write("enter the lease id: ");
            int leaseID = int.Parse(Console.ReadLine());
            Lease lease = _LeaseManagement.ReturnCar(leaseID);
            if (lease != null)
            {
                Lease result = new Lease();
                Console.WriteLine("-------Car Details------");
                Console.WriteLine("Car Found successfully.");
                result.leaseID = lease.leaseID;
                result.vehicleId = lease.vehicleId;
                result.CustomerId=lease.CustomerId;
                result.StartDate=lease.StartDate;
                result.EndDate=lease.EndDate;
                result.type= lease.type;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("faild to get Car.");
            }

        }



        public List<Lease> ListActiveLeases()
        {
            List<Lease> allActiveLeases = _LeaseManagement.ListActiveLeases();
            if (allActiveLeases.Count == 0)
            {
                Console.WriteLine("No Active leases available");
            }
            return allActiveLeases;

        }



        public List<Lease> ListLeaseHistory()
        {
            List<Lease> allLease = _LeaseManagement.ListLeaseHistory();
            if (allLease.Count == 0)
            {
                Console.WriteLine("No Active leases available");
            }
            return allLease;
        }
    }
}
