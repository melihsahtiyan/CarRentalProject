using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rent>> GetAllRents();
        IDataResult<List<RentDetailDto>> GetAllRentDetails();
        IDataResult<Rent> GetRentsByCustomerId(int customerId);
        IResult Add(Rent rent);
        IResult Update(Rent rent);
    }
}
