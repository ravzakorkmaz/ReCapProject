using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto { CarId = c.CarId, BrandId = c.BrandId, ColorId = c.ColorId, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear};
                
                return result.ToList();
            }
        }

    }
}
