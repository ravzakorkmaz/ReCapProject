using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0) {
                _carDal.Add(car);
                Console.WriteLine($"{car.Description} eklendi.");
            }
            else if (car.Description.Length < 2)
            {
                Console.WriteLine("Hata. Araba ismi minimum 2 karakter olmalidir. ");
            } else if (car.DailyPrice == 0)
            {
                Console.WriteLine("Hata. Araba günlük fiyati 0'dan büyük olmalidir.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine($"{car.Description} silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine($"{car.Description} güncellendi.");
        }
    }
}
