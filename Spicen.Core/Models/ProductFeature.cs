using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Core
{
    public class ProductFeature
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public int Height { get; set; }
        
        public int Width { get; set; }

        public int ProductId { get; set; }

        // navigation properties
        // go to product back and forth
        public Product Product { get; set; }
    }
}
