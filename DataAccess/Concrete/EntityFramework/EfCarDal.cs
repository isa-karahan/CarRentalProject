﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 ColorName = color.Name,
                                 CarName = car.Description,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice
                             };

                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return GetAll(c=> c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return GetAll(c => c.ColorId == id);
        }

    }
}
