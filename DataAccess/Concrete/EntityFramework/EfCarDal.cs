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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDataBaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDataBaseContext context = new CarRentalDataBaseContext())
            {
                var result = from c in context.Cars
                             join clr in context.Colors on c.ColorId equals clr.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                Id = c.Id, ColorName=clr.ColorName, BrandName=b.BrandName, 
                                 Description=c.Description, ModelYear=c.ModelYear, DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
