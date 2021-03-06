using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=2,DailyPrice=750,ModelYear="2017",Description="Audi A4 dizel otomatik 'Siyah'"},
            new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=600,ModelYear="2019",Description="Ford Mondeo 'Siyah'"},
            new Car{Id=3,BrandId=3,ColorId=3,DailyPrice=700,ModelYear="2018",Description="BMW 318i otomatik 'Mavi'"},
            new Car{Id=4,BrandId=4,ColorId=4,DailyPrice=350,ModelYear="2014",Description="Renault Megane manuel 'Gri'"},
            new Car{Id=5,BrandId=5,ColorId=1,DailyPrice=800,ModelYear="2016",Description="Mercedes c200d dizel otomatik 'Beyaz'"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;            
        }
    }
}
