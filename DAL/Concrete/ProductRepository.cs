using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EFDbContext context) : base(context)
        {
        }

        public EFDbContext EfDbContext
        {
            get { return Context as EFDbContext; }
        }
    }
}
