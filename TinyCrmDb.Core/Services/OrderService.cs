using Microsoft.EntityFrameworkCore;
using System.Linq;
using TinyCrmDb.Core.Data;
using TinyCrmDb.Core.Model;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb.Core.Services
{
    public class OrderService : IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService customerService;
        private IProductService productService;

        public OrderService(
            TinyCrmDbContext context, 
            ICustomerService custService,
            IProductService prodService)
        {
            context_ = context;
            customerService = custService;
            productService = prodService;
        }

        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }

            // search for existing Customer if not, no order can be made
            var customer = customerService.SearchCustomers(
                new SearchCustomerOptions()
            {
                    CustomerId = options.CustomerId
            }).SingleOrDefault();

            if (customer == null)
            {
                return null;
            }

            // if customer found making the order
            var order = new Order()
            {
                DeliveryAddress = options.DeliveryAddress,
            };

            foreach (var prod in options.ProductIds)
            {
                if (prod == null)
                {
                    continue;
                }

                var product = productService.SearchProduct(
                    new SearchProductOptions()
                    {
                        ProductId = prod
                    }).SingleOrDefault();

                if (product != null)
                {
                    var orderProd = new OrderProduct()
                    {
                        Product = product
                    };
                    order.OrderProducts.Add(orderProd);
                }
                else
                {
                    return null;
                }
            }

            if (order.OrderProducts.Count == 0)
            {
                return null;
            }

            customer.Orders.Add(order);
            context_.Update(customer);

            if (context_.SaveChanges() > 0)
            {
                return order;
            }
            return null;
        }
        public IQueryable<Order> SearchOrders(SearchOrderOptions options)
        {
            if (options == null )
            {
                return null;
            }

            var query = context_
                .Set<Order>()
                .AsQueryable();

            if (options.DeliveryAddress != null)
            {
                query = query.Where(o => o.DeliveryAddress == options.DeliveryAddress);
            }

            if (options.OrderId != null)
            {
                query = query.Where(o => o.OrderId == options.OrderId);
            }

            if (options.PriceFrom != null)
            {
                query = query.Where(o => o.TotalAmount >= options.PriceFrom);
            }

            if (options.PriceTo != null)
            {
                query = query.Where(o => o.TotalAmount <= options.PriceTo);
            }

            return query;
        }
        
        public Order UpdateOrder(UpdateOrderOptions options)
        {
            if (options == null || options.OrderId == null)
            {
                return null;
            }

            var order = context_
                .Set<Order>()
                .Where(o => o.OrderId == options.OrderId)
                .Include(o => o.OrderProducts)
                .SingleOrDefault();

            if (order == null)
            {
                return null;
            }

            if (order.DeliveryAddress != null)
            {
                order.DeliveryAddress = options.DeliveryAddress;
            }

            order.OrderProducts.Clear();
            order.TotalAmount = 0M;

            foreach (var prodid in options.ProductIds)
            {
                var product = productService.GetProductById(prodid);

                if (product == null)
                {
                    return null;
                }

                order.OrderProducts.Add(new OrderProduct()
                {
                    Product = product
                });

                order.TotalAmount += product.Price;
            }

            if (context_.SaveChanges() > 0)
            {
                return order;
            }
            return null;
        }
    }
}
