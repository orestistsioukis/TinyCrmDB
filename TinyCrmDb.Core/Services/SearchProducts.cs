namespace TinyCrmDb.Core.Services
{
    public class SearchProducts
    {
        public int ProductId { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public string Categories { get; set; }
    }
}
