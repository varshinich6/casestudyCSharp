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
    internal class CustomerManagement : ICustomerManagement
    {
        readonly ICarLeaseRepository _CustomerManagement;
        public CustomerManagement()
        {
            _CustomerManagement = new ICarLeaseRepositoryImpl();
        }


        public void AddCustomer()
        {
            Console.WriteLine("Enter customer details:");


            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Customer customer = new Customer(firstName, lastName, email, phoneNumber);

            int AddCustomerStatus = _CustomerManagement.AddCustomer(customer);
            if (AddCustomerStatus > 0)
            {
                Console.WriteLine("Customer Added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to Add Customer.");
            }
        }



        public void RemoveCustomer()
        {
            Console.Write("enter the car id: ");
            int customerID = int.Parse(Console.ReadLine());
            int RemoveCustomerStatus = _CustomerManagement.RemoveCustomer(customerID);
            if (RemoveCustomerStatus > 0)
            {
                Console.WriteLine("Customer removed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove Customer.");
            }
        }



        public void ListCustomers()
        {

                List<Customer> allCustomers = _CustomerManagement.ListCustomers();
            foreach (Customer item in allCustomers)
            {
                Console.WriteLine(item);

            }

        }



        public void FindCustomerById()
        {
            Console.Write("enter the customerID id: ");
            int customerID = int.Parse(Console.ReadLine());
            Customer customer = _CustomerManagement.FindCustomerById(customerID);
            if (customer != null)
            {
                Console.WriteLine(customer);
            }
            

        }
    }
}
