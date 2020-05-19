using TinyCrmDb.Core.Data;
using TinyCrmDb.Core.Services;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb
{
    class Program
    {
        private static ICustomerService custService;
        private static IProductService prodService;

        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext())
            {
                ICustomerService customerService = new CustomerService(
                    context);
                IProductService productService = new ProductService(
                    context);
                IOrderService orderService = new OrderService(
                    context, custService, prodService);

                var customer = customerService.CreateCustomer(
                    new CreateCustomerOptions()
                    {
                        FirstName = "Dimitris",
                        LastName = "Pnevmatikos",
                        VatNumber = "123456789"
                    });
            }
        }
    }
}
