using Microsoft.EntityFrameworkCore;
using Spicen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Repository
{
    public class AppDbContext: DbContext
    {
        // give connection string from startup
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // dbsets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        // productfeature is added to product so we can hide this field too.
        // var p = new Product { ProductFeature = new ProductFeature { // add here }}
        public DbSet<ProductFeature> ProductFeatures { get; set; }


    }
}
