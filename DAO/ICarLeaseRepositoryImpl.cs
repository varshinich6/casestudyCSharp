using casestudy.Exceptions;
using casestudy.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace casestudy.DAO
{
    public class ICarLeaseRepositoryImpl : ICarLeaseRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        
        public ICarLeaseRepositoryImpl()
        {
            sqlConnection = new SqlConnection("Server=DESKTOP-BFMCOC6;DataBase=Car_Rental_System;Trusted_Connection=True");
            cmd = new SqlCommand();
        }

        
        
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public int AddCar(Car car)
        {
            cmd.CommandText = "INSERT INTO Vehicle (make, model, year, dailyRate, status, passengerCapacity, engineCapacity) VALUES (@make, @model, @year, @dailyRate, @status, @passengerCapacity, @engineCapacity)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@make", car.Make);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@year", car.Year);
            cmd.Parameters.AddWithValue("@dailyRate", car.DailyRate);
            cmd.Parameters.AddWithValue("@status", car.Status);
            cmd.Parameters.AddWithValue("@passengerCapacity", car.PassengerCapacity);
            cmd.Parameters.AddWithValue("@engineCapacity", car.EngineCapacity);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int createCarStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return createCarStatus;

        }

        public int RemoveCar(int carID)
        {
            int RemoveCarStatus = 0;
            
            cmd.CommandText = "DELETE FROM Vehicle WHERE vehicleID = @carId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@carId", carID);
            
            cmd.Connection = sqlConnection;
            try {
                sqlConnection.Open();
                RemoveCarStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                
            }

            return RemoveCarStatus;

        }


        public List<Car> ListAvailableCars()
        {
            Console.WriteLine("-------List of available Cars------");
            List<Car> cars = new List<Car>();
            cmd.CommandText = "SELECT * FROM Vehicle WHERE status='available'";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                {
                    Car car = new Car();
                    car.vehicleId = (int)reader["vehicleID"];
                    car.Make = (string)reader["make"];
                    car.Model = (string)reader["model"];
                    car.Year = (int)reader["year"];
                    
                    car.DailyRate = (decimal)reader["dailyRate"];
                    car.Status = (string)reader["status"];
                    car.PassengerCapacity = (int)reader["passengerCapacity"];
                    car.EngineCapacity = (int)reader["engineCapacity"];

                    cars.Add(car);
                }
            }
            sqlConnection.Close();
            return cars;
        }

        public List<Car> ListRentedCars()
        {
            Console.WriteLine("-------List of Rented Cars------");
            List<Car> Cars = new List<Car>();
            cmd.CommandText = "SELECT * FROM Vehicle WHERE status='notAvailable'";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                {
                    Car car = new Car();
                    car.vehicleId = (int)reader["vehicleID"];
                    car.Make = (string)reader["make"];
                    car.Model = (string)reader["model"];
                    car.Year = (int)reader["year"];

                    car.DailyRate = (decimal)reader["dailyRate"];
                    car.Status = (string)reader["status"];
                    car.PassengerCapacity = (int)reader["passengerCapacity"];
                    car.EngineCapacity = (int)reader["engineCapacity"];

                    Cars.Add(car);
                }
            }
            sqlConnection.Close();
            return Cars;

        }

        public Car FindCarById(int carID)
        {
            Car carNull = null;

            try
            {
                    cmd.CommandText = "SELECT * FROM Vehicle WHERE vehicleID=@carId";
                    cmd.Connection = sqlConnection;
                    cmd.Parameters.AddWithValue("@carId", carID);
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                        
                    if (reader.Read())
                    {
                            Car car = new Car();
                            car.vehicleId = (int)reader["vehicleID"];
                            car.Make = (string)reader["make"];
                            car.Model = (string)reader["model"];
                            car.Year = (int)reader["year"];
                            car.DailyRate = (decimal)reader["dailyRate"];
                            car.Status = (string)reader["status"];
                            car.PassengerCapacity = (int)reader["passengerCapacity"];
                            car.EngineCapacity = (int)reader["engineCapacity"];
                            return car;
                    }
                    else
                    {
                        throw new CarNotFoundException("failed to get Vehicle. Please enter valid Vehicle Id");
                    }
                        
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            
            }
            finally
            {
                sqlConnection.Close();
            }
            return carNull;
        }




        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int AddCustomer(Customer customer)
        {
            cmd.CommandText = "INSERT INTO Customer ( FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int createCustomerStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return createCustomerStatus;
        }

        public int RemoveCustomer(int customerID)
        {
            int RemoveCustomerIDStatus = 0;
           
            cmd.CommandText = "DELETE  FROM Customer WHERE customerID = @customerID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@customerID", customerID);

            cmd.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                RemoveCustomerIDStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

            }

            return RemoveCustomerIDStatus;
        }

        public List<Customer> ListCustomers()
        {
            Console.WriteLine("-------List of available customers------");
            List<Customer> customers = new List<Customer>();
            cmd.CommandText = "SELECT * FROM Customer";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.CustomerID = (int)reader["customerID"];
                customer.FirstName = (string)reader["firstName"];
                customer.LastName = (string)reader["lastName"];
                customer.Email = (string)reader["email"];
                customer.PhoneNumber = (string)reader["phoneNumber"];
                customers.Add(customer);
            }

            sqlConnection.Close();
            return customers;
        }

        public Customer FindCustomerById(int customerID)
        {
            Customer customerNull = null;

            {
                cmd.CommandText  = "SELECT * FROM Customer WHERE customerID = @customerID";
                cmd.Connection = sqlConnection;
                cmd.Parameters.AddWithValue("@customerID", customerID);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                {
                    try
                    {
                   
                            if (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerID = (int)reader["customerID"];
                                customer.FirstName = (string)reader["firstName"];
                                customer.LastName = (string)reader["lastName"];
                                customer.Email = (string)reader["email"];
                                customer.PhoneNumber = (string)reader["phoneNumber"];
                                sqlConnection.Close();
                                return customer;
                                
                            }
                        else
                        {
                            throw new CustomerNotFoundException("Please enter a valid customerId");

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            
            return customerNull;
        }


        /// //////////////////////////////////////////////////////////////////////////////


        public int CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate,  string type)
        {

            int createLeaseStatus = 0;
            try
            {
                if (FindCustomerById(customerID) != null)
                {
                    if (FindCarById(carID) != null)
                    {
                        cmd.CommandText = "INSERT INTO Lease( customerID, vehicleID, startDate, endDate, type) VALUES (@customerID, @carID, @startDate, @endDate, @type )";

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@customerID", customerID);
                        cmd.Parameters.AddWithValue("@carID", carID);
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@type", type);

                        cmd.Connection = sqlConnection;

                        sqlConnection.Open();
                        createLeaseStatus = cmd.ExecuteNonQuery();
                        return createLeaseStatus;

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid Car Id");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a valid Customer Id");
                }

            }catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            sqlConnection.Close();
            return createLeaseStatus;
            
        }

        public Lease ReturnCar(int leaseID)
        {
            Lease leaseNull = null;

            try
            {


                
                    cmd.CommandText = "SELECT * FROM Lease WHERE leaseID=@leaseID";
                    cmd.Parameters.Clear();
                    cmd.Connection = sqlConnection;
                    cmd.Parameters.AddWithValue("@leaseID", leaseID);
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                      
                    if (reader.Read())
                    {
                        Lease lease = new Lease();
                        lease.leaseID = (int)reader["leaseID"];
                        lease.vehicleId = (int)reader["vehicleID"];
                        lease.CustomerId = (int)reader["customerID"];
                        lease.StartDate = (DateTime)reader["startDate"];
                        lease.EndDate = (DateTime)reader["endDate"];
                        lease.type = (string)reader["type"];
                        return lease;
                    }
                    else
                    {
                        throw new LeaseNotFoundException("Lease not Found!!. Please Enter a valid Lease Id");
                    }
                        
                    
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while finding car: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();

            }
            return leaseNull;
        }

        public List<Lease> ListActiveLeases()
        {
            Console.WriteLine("-------List of Active Leases------");
            List<Lease> leases = new List<Lease>();
            cmd.CommandText = "SELECT * FROM Lease WHERE endDate >= GETDATE()";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                    Lease lease = new Lease();
                    lease.leaseID = (int)reader["leaseID"];
                    lease.vehicleId = (int)reader["vehicleID"];
                    lease.CustomerId = (int)reader["customerID"];
                    lease.StartDate = (DateTime)reader["startDate"];
                    lease.EndDate = (DateTime)reader["endDate"];
                    lease.type = (string)reader["type"];
                    leases.Add(lease);


                
            }
            sqlConnection.Close();
            return leases;

        }

        public List<Lease> ListLeaseHistory()
        {
            Console.WriteLine("-------List of Leases------");
            List<Lease> leases = new List<Lease>();
            cmd.CommandText = "SELECT * FROM Lease";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                Lease lease = new Lease();
                lease.leaseID = (int)reader["leaseID"];
                lease.vehicleId = (int)reader["vehicleID"];
                lease.CustomerId = (int)reader["customerID"];
                lease.StartDate = (DateTime)reader["startDate"];
                lease.EndDate = (DateTime)reader["endDate"];
                lease.type = (string)reader["type"];
                leases.Add(lease);



            }
            sqlConnection.Close();
            return leases;
        }

        
        public int RecordPayment(int leaseID, double amount)
        {
            
                
                    
                    cmd.CommandText = "INSERT INTO Payment (leaseID, amount, paymentDate) VALUES (@leaseID, @amount, @paymentDate)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@leaseID", leaseID);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@paymentDate", DateTime.Today);

                    try
                    {
                        
                        
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        int PaymentStatus = cmd.ExecuteNonQuery();
                        return PaymentStatus;
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                

                return 0;
            }

        }
    }

  

    


    


