﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data
{
    public interface IProductRepository : IRepository<Product>
    {
        
    }
}
