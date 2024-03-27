using casestudy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.DAO
{
        public interface ICarLeaseRepository
        {
            int AddCar(Car car);
            int RemoveCar(int carID);
            List<Car> ListAvailableCars();
            List<Car> ListRentedCars();
            Car FindCarById(int carID);
        
        /// /////////////////////////////////////////////////
        
            int AddCustomer(Customer customer);
            int RemoveCustomer(int customerID);
            List <Customer> ListCustomers();
            Customer FindCustomerById(int customerID);




        /// /////////////////////////////////////////////////////////

            int CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate, string type);
            Lease ReturnCar(int leaseID);
            List<Lease> ListActiveLeases();
            List<Lease> ListLeaseHistory();

        int RecordPayment(int leaseID, double amount);
        }
}


