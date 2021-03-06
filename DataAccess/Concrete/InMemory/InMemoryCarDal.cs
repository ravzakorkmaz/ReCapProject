﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
            new Car { CarId = 1, BrandId = 1, ColorId = 111, ModelYear = 2020, DailyPrice = 300, Description = "Dacia Duster" },
            new Car { CarId = 2, BrandId = 1, ColorId = 112, ModelYear = 2019, DailyPrice = 280, Description = "Opel Corsa" },
            new Car { CarId = 3, BrandId = 2, ColorId = 113, ModelYear = 2019, DailyPrice = 270, Description = "Renault Megane" },
            new Car { CarId = 4, BrandId = 3, ColorId = 114, ModelYear = 2016, DailyPrice = 240, Description = "Fiat Linea" },
            new Car { CarId = 5, BrandId = 3, ColorId = 115, ModelYear = 2015, DailyPrice = 210, Description = "Renault Symbol" }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
