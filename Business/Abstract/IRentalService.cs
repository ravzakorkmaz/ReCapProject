using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetAllRentalByCarId(int carId);
        IDataResult<List<Rental>> GetAllRentalByCustomerId(int customerId);
        IDataResult<List<Rental>> GetAllByRentDate(DateTime rentDate); //?

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
