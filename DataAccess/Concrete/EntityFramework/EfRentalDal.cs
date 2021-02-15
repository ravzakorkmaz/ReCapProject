using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental, CarsDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using(CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var result = from r in context.Rentals
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = r.CarId,
                                 CustomerId = cs.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                
                return result.ToList();
                                     
            }
        } 

    }
}
