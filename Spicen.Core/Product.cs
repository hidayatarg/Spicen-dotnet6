﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Core
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        // one to one relationship => navigation property
        // 1 product => 1 category
        public Category Category { get; set; }

        public ProductFeature ProductFeature { get; set; }
    }
}
