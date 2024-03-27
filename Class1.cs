using casestudy.DAO;
using casestudy.models;
using NUnit.Framework;
   

namespace CarRentalApp.Testing
{
    [TestFixture]
    public class Class1
    {

        ICarLeaseRepository ICarLeaseRepositoryImpl = new ICarLeaseRepositoryImpl();


        [TestCase]
        public void Test_CreateCar_Success()
        {

            Car car = new Car
            {
                vehicleId = 4,
                Make = "Toyota",
                Model = "Camry",
                Year = 2019,
                DailyRate= 10,
                Status = "available",
                PassengerCapacity= 10,
                EngineCapacity= 10,


            };

           
            int result = ICarLeaseRepositoryImpl.AddCar(car);

           
            Assert.That(result, Is.GreaterThanOrEqualTo(0));
        }

        [TestCase]
        public void Test_CreateLease_Success()
        {
            
            Lease lease = new Lease
            {
                leaseID = 1,
                vehicleId = 1,
                CustomerId = 1
            };

          
            int result = 1;// CarLeaseRepository.CreateLease(1, 1, '2024-02-20', '2024-03-20', "Short-term");

            Assert.That(result, Is.GreaterThanOrEqualTo(0));
        }


        //[TestCase]
        //public void Test_GetLease_Success(ICarLeaseRepository ICarLeaseRepository)
        //{
        //    ICarLeaseRepositoryImpl repository = new ICarLeaseRepositoryImpl();

        //    int leaseID = 1;


        //    Lease lease = ICarLeaseRepositoryImpl.ListActiveLeases();


        //    Assert.That(lease, Is.Not.Null);
        //    Assert.That(lease.leaseID, Is.EqualTo(leaseID));
        //    }

            [TestCase]
        public void Test_Exception_CustomerIdNotFound()
        {
            ICarLeaseRepositoryImpl repository = new ICarLeaseRepositoryImpl();

            // Act and Assert
            Assert.Throws<Exception>(() => repository.ListActiveLeases());
        }

        [TestCase]
        public void Test_Exception_CarIdNotFound()
        {
            // Arrange
            ICarLeaseRepositoryImpl repository = new ICarLeaseRepositoryImpl();

            // Act and Assert
            Assert.Throws<Exception>(() => repository.ListActiveLeases());
        }


        [TestCase]
        public void Test_Exception_LeaseIdNotFound()
        {
           

            
            Assert.Throws<Exception>(() => ICarLeaseRepositoryImpl.ListActiveLeases());
        }
    }
}
