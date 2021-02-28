using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
               CheckImageLimit(carImage.CarId)
               );
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.ImagesDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                FileHelper.DeleteAsync(_carImageDal.Get(c=>c.ImagesId == carImage.ImagesId).ImagePath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImagesId== id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(c=>c.ImagesId == carImage.CarId).ImagePath, file);
            carImage.ImagesDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimit(int carId)
        {
            var carImagecount = _carImageDal.GetAll(c=>c.CarId ==carId ).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                //string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
                string path = @"\Images\carImages\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, ImagesDate = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id).ToList());
        }

    }
}
