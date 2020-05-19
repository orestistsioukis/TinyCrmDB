using System.Collections.Generic;

namespace TinyCrmDb.Core.Services.Interfaces
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }
        public List<string> ProductIds { get; set; }
        public string DeliveryAddress { get; set; }

        public CreateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
