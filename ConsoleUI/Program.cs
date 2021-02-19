using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        private static void GetAll()
        {
            //GetAllTest();
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + "/" + car.Price);

            }
            Console.WriteLine("Hello World!");
        }

        private static void GetColorsByColorId(int id)
        {
            //GetColosByColorIdTest();
        }

        private static void GetColosByColorIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetColorsByColorId(1))
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);

            }
            Console.WriteLine("Hello World!");
        }
        private static void GetBrandsByBrandId()
        {
            //GetBrandsByBrandIdTest();
        }

        private static void GetBrandsByBrandIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetBrandsByBrandId(1))
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);

            }
            Console.WriteLine("Hello World!");
        }
        private static void Add()
        {
            //AddTest();
        }

        private static void AddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car()
            {
                CarId = 7,
                BrandId = 3,
                ColorId = 4,
                Price = 300000,
                Description = "Volkswagen Araba",
                ModelYear = 2018
            };
            Console.WriteLine(car1.Description);
        }
        private static void Update(CarManager carManager)
        {
            //UpdateTest(carManager);
        }

        private static void UpdateTest(CarManager carManager)
        {
            carManager.Update(new Car() { CarId = 2, BrandId = 2, ColorId = 2, Price = 350000, Description = "Volkswagen Araba(modifiye)", ModelYear = 2018 });

            var c = carManager.GetAll();
            foreach (var car in c)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void DeleteTest(CarManager carManager, Car car1)
        {
            //DeleteTest(carManager, car1);
        }

        private static void Delete(CarManager carManager, Car car1)
        {
            carManager.Delete(car1);
            List<Car> c = carManager.GetAll();
            foreach (var car in c)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
    }


  

 




