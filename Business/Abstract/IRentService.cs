using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService
    {
        IDataResult<List<Rent>> GetAllRents();
        IDataResult<Rent> GetRentsByCustomerId(int customerId);
        IResult Add(Rent rent);
        IResult Update(Rent rent);
    }
}
