﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Delete(Car car)
        {
            try { 
                _carDal.Delete(car); 
            }
            catch { 
                return new ErrorResult(Messages.MaintenanceTime); 
            }

            return new SuccessResult(Messages.CarDeleted); 
        }

        public IDataResult<List<Car>> Get(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Insert(Car car)
        {
            if (car.Description.Length < 2)
                return new ErrorResult(Messages.InvalidDescription);
            if (car.DailyPrice <= 0)
                return new ErrorResult(Messages.InvalidDailyPrice);

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            try { 
                _carDal.Update(car); 
            }
            catch { 
                return new ErrorResult(Messages.MaintenanceTime); 
            }
            
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
