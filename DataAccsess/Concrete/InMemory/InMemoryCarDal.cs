﻿using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{ CarId=1,  BrandId=1, ColorId=1, ModelYear=1997, Description="Sorunsuz"},
                new Car{ CarId=1,  BrandId=1, ColorId=2, ModelYear=2010, Description="Kaplama"},
                new Car{ CarId=1,  BrandId=1, ColorId=2, ModelYear=1999, Description="Koltuk Derileri Değişmeli"},
                new Car{ CarId=1,  BrandId=2, ColorId=3, ModelYear=2001, Description="Ön Kapı Arızalı"},
                new Car{ CarId=1,  BrandId=2, ColorId=3, ModelYear=2020, Description="Hasar Kaydı Yok"},

            };
        }
        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.CarId == carId).ToList();
        }
        public List<Car> GetAll()
        {
            return _car;
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == c.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
                
        }
        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c=>c.CarId==c.CarId);
            _car.Remove(carToDelete);

        }
    }
}