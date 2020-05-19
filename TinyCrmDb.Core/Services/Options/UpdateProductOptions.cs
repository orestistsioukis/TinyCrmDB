using TinyCrmDb.Core.Model;

namespace TinyCrmDb.Core.Services.Interfaces
{
    public class UpdateProductOptions
    {
        public string ProductId { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public decimal? Price { get; set; }
        public ProductCategory? Category { get; set; }
    }
}