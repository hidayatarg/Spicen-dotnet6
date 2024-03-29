﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spicen.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Repository.Configurations
{
    public class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        //public void Configure(EntityTypeBuilder<ProductFeature> builder)
        //{
        //    builder.HasKey(x => x.Id);
        //    builder.Property(x => x.Id).UseIdentityColumn();


        //    // corresponding database table
        //    builder.ToTable("ProductFeatures");

        //    // relationship
        //    builder.HasOne(x => x.Product)
        //        .WithOne(x => x.ProductFeature)
        //        .HasForeignKey<ProductFeature>(x => x.ProductId);
        //}



        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);
        }
    }
}
