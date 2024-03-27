using casestudy.CarRentalApp;
using casestudy.DAO;
using casestudy.models;
using System.Reflection;

namespace casestudy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarRentalApplication repository = new CarRentalApplication();
            repository.MainMenu();


        }

    }
}




