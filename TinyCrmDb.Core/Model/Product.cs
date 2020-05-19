using System;
using System.Collections.Generic;
using System.Text;
using TinyCrmDb;

namespace TinyCrmDb.Core.Model
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
