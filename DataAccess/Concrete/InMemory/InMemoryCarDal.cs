﻿using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : IEntityRepository<Car>
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>(){};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

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
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            if(carToUpdate != null)
            {
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ModelYear = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
            }
        }
    }
}
