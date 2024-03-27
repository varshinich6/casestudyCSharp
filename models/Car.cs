using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.models
{
    public class Car
    {
        public int vehicleId { get; set; }
        public bool Rented { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; }
        public int PassengerCapacity { get; set; }
        public int EngineCapacity { get; set; }

        public Car() { }

        public Car(string make, string model, int year, decimal dailyRate, string status, int passengerCapacity, int engineCapacity)
        {

            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            Status = status;
            PassengerCapacity = passengerCapacity;
            EngineCapacity = engineCapacity;
        }

        public Car(int id, string make, string model, int year, decimal dailyRate, string status, int passengerCapacity, int engineCapacity)
        {
            vehicleId = id;
          
            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            Status = status;
            PassengerCapacity = passengerCapacity;
            EngineCapacity = engineCapacity;
        }

        

        public override string ToString()
        {
            return $"VehicleId: {vehicleId}\t Make: {Make}\t Model: {Model}\t Year: {Year}\t Daily Rate: {DailyRate}\t Status: {Status}\t Passenger Capacity: {PassengerCapacity}\t Engine Capacity: {EngineCapacity}";
        }
    }

}
    





