using casestudy.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.Service
{
    internal interface ICarManagement
    {
        public void AddCar();
        public void RemoveCar();
        public List<Car> ListAvailableCars();
        public List<Car> ListRentedCars();
        
        public void FindCarById();
    }
}
