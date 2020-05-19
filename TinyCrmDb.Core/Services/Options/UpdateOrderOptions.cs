using System.Collections.Generic;

namespace TinyCrmDb.Core.Services.Interfaces
{
    public class UpdateOrderOptions
    {
        public int? OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public List<string> ProductIds { get; set; }

        public UpdateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
