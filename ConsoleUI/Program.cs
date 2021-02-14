using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.Description + " Filtered by Brand 5 " + car.BrandId);
            //}
            //Console.WriteLine("Hello World!");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "      " + car.ModelYear + "           " + car.Price + "         " + car.Description);
            }
            Console.WriteLine("__________________________________________________");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("__________________________________________________");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("__________________________________________________");
            carManager.Add(new Car { CarId = 7, BrandId = 4, ColorId = 1, Price = 500, Description = "Tesla Model 3", ModelYear = 2015 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + "      " + car.ModelYear + "           " + car.Price + "         " + car.Description);
            }
        }
     
}
}
