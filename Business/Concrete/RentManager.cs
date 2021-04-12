using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;
        private ICarDal _carDal;
        public RentManager(IRentDal rentDal, ICarDal carDal)
        {
            _rentDal = rentDal;
            _carDal = carDal;
        }

        public IResult Add(Rent rent)
        {
            _rentDal.Add(rent);
            return new SuccessResult(Messages.GiveMeRent);
        }

        public IDataResult<List<RentDetailDto>> GetAllRentDetails()
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetails(),Messages.RentDetailsListed);
        }

        public IDataResult<List<Rent>> GetAllRents()
        {
            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll());
        }

        public IDataResult<Rent> GetRentsByCustomerId(int customerId)
        {
            return new SuccessDataResult<Rent>(_rentDal.Get(r => r.CustomerId == customerId));
        }

        public IResult Update(Rent rent)
        {
            _rentDal.Update(rent);
            return new SuccessResult(Messages.FixThisDoor);
        }
    }
}
