namespace Spicen.Core
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        // one to many relationship => navigation property
        // 1 category many products
        public ICollection<Product> Products { get; set; }
    }
}
