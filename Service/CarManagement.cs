using casestudy.DAO;
using casestudy.Exceptions;
using casestudy.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.Service
{
    internal class CarManagement:ICarManagement

    {

        readonly ICarLeaseRepository _CarManagement;
        
        public CarManagement()
        {
            _CarManagement = new ICarLeaseRepositoryImpl();
        }


        public void AddCar()
        {
                    

            Console.WriteLine("Enter car details:");

            Console.Write("Make: ");
            string make = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Daily Rate: ");
            decimal dailyRate = decimal.Parse(Console.ReadLine());

            Console.Write("Status: ");
            string status = Console.ReadLine();

            Console.Write("Passenger Capacity: ");
            int passengerCapacity = int.Parse(Console.ReadLine());

            Console.Write("Engine Capacity: ");
            int engineCapacity = int.Parse(Console.ReadLine());

            Car car = new Car(make, model, year, dailyRate, status, passengerCapacity, engineCapacity);

            int AddCarStatus = _CarManagement.AddCar(car);
            if (AddCarStatus > 0)
            {
                Console.WriteLine("Car Added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to Add Car.");
            }
        }   


        public void RemoveCar()
        {
            Console.Write("enter the car id: ");
            int carID = int.Parse(Console.ReadLine());
            int RemoveCarStatus = _CarManagement.RemoveCar(carID);
            if (RemoveCarStatus > 0)
            {
                Console.WriteLine("Car removed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove Car.");
            }
        }



        public List<Car> ListAvailableCars()
        {
            
            List<Car> allVehicles = _CarManagement.ListAvailableCars();
            if(allVehicles.Count == 0)
            {
                Console.WriteLine("No cars available");
            }
            return allVehicles;
        }



        public List<Car> ListRentedCars()
        {
            List<Car> cars = _CarManagement.ListRentedCars();
            if(cars.Count == 0)
            {
                Console.WriteLine("No REnted Cars Available");
            }
            return cars;

        }



        public void FindCarById()
        {
           
            Console.Write("Enter the car id: ");
            int carID = int.Parse(Console.ReadLine());
            Car car = _CarManagement.FindCarById(carID);
            if (car != null)
            {
                Console.WriteLine("-------Car Details------");
                Console.WriteLine("Car Found successfully.");
                Console.WriteLine(car);
            }
        }
    }
}
