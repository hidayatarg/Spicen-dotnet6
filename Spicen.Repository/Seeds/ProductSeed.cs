using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spicen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        // Category Ids Comes as Parameters
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
               new Product { Id = 1, Name = "Pilot Pen", Price = 12.50m, Stock = 100, CreatedDate = DateTime.Now, CategoryId = _ids[0] },
               new Product { Id = 2, Name = "Pencil Pen", Price = 40.50m, Stock = 200, CreatedDate = DateTime.Now, CategoryId = _ids[0] },
               new Product { Id = 3, Name = "Fountain Pen", Price = 500m, Stock = 300, CreatedDate = DateTime.Now, CategoryId = _ids[1] },
               new Product { Id = 4, Name = "Small Notebook", Price = 500m, Stock = 300, CreatedDate = DateTime.Now, CategoryId = _ids[1] },
               new Product { Id = 5, Name = "Medium Notebook", Price = 500m, Stock = 300, CreatedDate = DateTime.Now, CategoryId = _ids[1] },
               new Product { Id = 6, Name = "Big Notebook", Price = 500m, Stock = 300, CreatedDate = DateTime.Now, CategoryId = _ids[2] }
           );
        }
    }
}
