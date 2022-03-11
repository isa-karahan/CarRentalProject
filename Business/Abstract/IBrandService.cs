﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        List<Brand> Get(int id);
        void Insert(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}