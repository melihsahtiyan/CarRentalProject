using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;  
using Core.Utilities.Business;
using Core.Utilities.Helpers;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        //[ValidationAspect(typeof(ImageValidator))]
        public IResult Add(IFormFile file, Image image)
        {
            var result = BusinessRules.Run(CheckImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FormFileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(Image image)
        {


            FormFileHelper.Delete(image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.CarId == carId));
        }

        public IResult Update(IFormFile file, Image image)
        {
            var result = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../wwwroot")) +
                         _imageDal.Get(i => i.ImageId == image.ImageId).ImagePath;
            image.ImagePath = FormFileHelper.Update(file, result);
            image.Date=DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckImageLimit(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.ImageAdditionFailed);
            }
            return new SuccessResult();
        }
    }
}
