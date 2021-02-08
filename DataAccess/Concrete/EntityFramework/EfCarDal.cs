using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var addedCar = context.Entry(entity);
                if (entity.Description.Length >= 2 && entity.DailyPrice > 0)
                {
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Hata. Lütfen araba isminin 2 karakterli olduguna ve günlük fiyatin 0'dan büyük olduguna emin olunuz.");
                }
            }
            
        }

        public void Delete(Car entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
