

using System;
using System.Data.Entity;
using Domain.Entities;

namespace Data
{
    public class EFDbContext: DbContext
    {
        public EFDbContext():base("name=EFDbContext")
        {
            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(16, 2);
            
        }
    }
}
