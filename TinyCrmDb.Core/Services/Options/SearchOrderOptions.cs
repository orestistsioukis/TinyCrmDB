namespace TinyCrmDb.Core.Services.Interfaces
{
    public class SearchOrderOptions
    {
        public int? OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}