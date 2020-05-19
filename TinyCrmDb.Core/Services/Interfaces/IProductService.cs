using System.Linq;
using TinyCrmDb.Core.Model;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb.Core.Services
{
    public interface IProductService
    {
        IQueryable<Product> SearchProduct(
            SearchProductOptions options);

        Product CreateProduct(
            CreateProductOptions options);

        Product UpdateProduct(
            UpdateProductOptions options);

        Product GetProductById(string id);
    }
}
