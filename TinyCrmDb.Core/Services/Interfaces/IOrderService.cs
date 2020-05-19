using System.Linq;
using TinyCrmDb.Core.Model;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb.Core.Services
{
    public interface IOrderService
    {
        IQueryable<Order> SearchOrders(
            SearchOrderOptions options);
        Order CreateOrder(
            CreateOrderOptions options);
        Order UpdateOrder(
            UpdateOrderOptions options);
    }
}
