using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCars();
            //Console.WriteLine("-------------------------------");
            //ColorTest();
            //Console.WriteLine("-------------------------------");
            //TestBrands();
            //TestRentAdd();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAllColors();
            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            
        }

        private static void TestCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "\t" + car.ColorName + "\t" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void TestBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAllBrands();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }

            }
        }

        private static void TestRentAdd()
        {
            Rent rent = new Rent() {CarId=4,CustomerId=1,RentDate=DateTime.Now};
            RentManager rentManager = new RentManager(new EfRentDal());
            var result = rentManager.Add(rent);
            Console.WriteLine(result.Message);
        }
    }
}
