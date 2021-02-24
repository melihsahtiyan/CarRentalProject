using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                Console.WriteLine("Car added to list...");
            }
            else
            {
                Console.WriteLine("The car that you entered is invalid. " +
                    "Car name must longer than 2 letter and daily price must be more than 0. Please try again...");
            }
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public Car GetCarsByBrandId(int brandId)
        {
            return _carDal.Get(p => p.BrandId == brandId);
        }

        public Car GetCarsByColorId(int colorId)
        {
            return _carDal.Get(p => p.ColorId == colorId);
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
