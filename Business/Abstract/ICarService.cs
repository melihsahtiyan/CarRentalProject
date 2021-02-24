using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int id);
        Car GetCarsByColorId(int colorId);
        Car GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetCarDetails();
    }
}
