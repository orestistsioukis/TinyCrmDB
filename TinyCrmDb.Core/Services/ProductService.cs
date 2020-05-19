using System;
using System.Linq;
using TinyCrmDb.Core.Data;
using TinyCrmDb.Core.Model;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb.Core.Services
{
    public class ProductService : IProductService
    {
        private TinyCrmDbContext context_;

        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }



        public Product CreateProduct(CreateProductOptions options)
        {
            if (options == null || options.ProductId == null) // can't accept product with no Id 
            {
                return null;
            }
            // checking if product exists in the DB
            var checkprod = context_
                .Set<Product>()
                .Where(p => p.ProductId == options.ProductId)
                .SingleOrDefault();
            if (checkprod != null)
            {
                throw new Exception("The product already exists!");
            }

            // product create
            var product = new Product()
            {
                ProductId = options.ProductId,
                Name = options.Name,
                Description = options.Description
            };

            if (options.Category != null)
            {
                product.ProductCategory = (ProductCategory)options.Category;
            }
            if (options.Price != null)
            {
                product.Price = (decimal)options.Price;
            }

            context_.Add(product);
            if (context_.SaveChanges() > 0 )
            {
                return product;
            }

            return null;
        }

        public IQueryable<Product> SearchProduct(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Product>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                query = query.Where(p => p.Name == options.Name);
            }

            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                query = query.Where(p => p.Description == options.Description);
            }

            if (options.ProductId != null)
            {
                query = query.Where(p => p.ProductId == options.ProductId);
            }

            if (options.PriceTo != null)
            {
                query = query.Where(p => p.Price <= options.PriceTo);
            }

            if (options.PriceFrom != null)
            {
                query = query.Where(p => p.Price >= options.PriceFrom);
            }

            return query;
        }
        public Product UpdateProduct(UpdateProductOptions options)
        {
            if (options == null || options.ProductId == null)  
            {
                return null;
            }
            
            var checkprod = context_
                .Set<Product>()
                .Where(p => p.ProductId == options.ProductId)
                .SingleOrDefault();
            if (checkprod == null) // not exists
            {
                return null;
            }

            if (options.Name != null)
            {
                checkprod.Name = options.Name;
            }

            if (options.Description != null)
            {
                checkprod.Description = options.Description;
            }

            if (options.ProductId != null)
            {
                checkprod.ProductId = options.ProductId;
            }

            if (options.Price != null)
            {
                checkprod.Price = (decimal)options.Price;
            }

            if (options.Category != null)
            {
                checkprod.ProductCategory = (ProductCategory)options.Category;
            }

            if (context_.SaveChanges() > 0)
            {
                return checkprod;
            }

            return null;
        }

        public Product GetProductById(string id)
        {
            if (id == null)
            {
                return null;
            }

            return context_
                .Set<Product>()
                .Where(p => p.ProductId == id)
                .SingleOrDefault();
        }
    }
}
