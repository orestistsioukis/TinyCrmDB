using TinyCrmDb.Core.Model;

namespace TinyCrmDb.Core.Services.Interfaces
{
    public class SearchProductOptions
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public ProductCategory? Category { get; set; } 
    }
}
