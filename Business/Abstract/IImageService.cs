using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetImagesByCarId(int carId);
        IResult Add(IFormFile file, Image image);
        IResult Update(IFormFile file, Image image);
        IResult Delete(Image image);
    }
}
