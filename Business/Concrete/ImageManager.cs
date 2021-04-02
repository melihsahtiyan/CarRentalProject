using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        ICarDal _carDal;
        public ImageManager(IImageDal imageDal, ICarDal carDal)
        {
            _imageDal = imageDal;
            _carDal = carDal;
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(IFormFile file, Image image)
        {
            var check = BusinessRules.Run(CheckImageLimit(image.CarId),CheckTheCarExists(image.CarId));
            if (check != null)
            {
                return check;
            }

            image.ImagePath = FormFileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(Image image)
        {
            var check = BusinessRules.Run(CheckTheCarExists(image.CarId));
            if (check != null)
            {
                return check;
            }

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
            var check = BusinessRules.Run(CheckTheCarExists(carId));
            if (check != null)
            {
                return new ErrorDataResult<List<Image>>(Messages.CarDoesntExists);
            }
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.CarId == carId));
        }

        public IResult Update(IFormFile file, Image image)
        {
            var check = BusinessRules.Run(CheckTheCarExists(image.CarId));
            if (check != null)
            {
                return check;
            }

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

        private IResult CheckTheCarExists(int carId)
        {
            var check = _carDal.GetAll(c => c.Id == carId);
            if (check.Count == 0)
            {
                return new ErrorResult(Messages.CarDoesntExists);
            }
            return new SuccessResult();
        }
    }
}
