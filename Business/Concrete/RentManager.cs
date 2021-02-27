﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRentService
    {
        IRentDal _rentDal;
        public RentManager(IRentDal rentDal)
        {
            _rentDal = rentDal;
        }

        public IResult Add(Rent rent)
        {
            _rentDal.Add(rent);
            return new SuccessResult(Messages.GiveMeRent);
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
