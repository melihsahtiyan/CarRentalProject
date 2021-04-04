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
    public class EfRentDal : EfEntityRepositoryBase<Rent, CarRentalDataBaseContext>, IRentDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (CarRentalDataBaseContext context = new CarRentalDataBaseContext())
            {
                
                var result = from r in context.Rents
                             join c in context.Cars on r.CarId equals c.Id
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join u in context.Users on cus.UserId equals u.Id
                             select new RentDetailDto
                             {
                                 RentId = r.Id,
                                 BrandName = b.BrandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
