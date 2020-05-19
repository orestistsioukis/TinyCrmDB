using System.Linq;
using TinyCrmDb.Core.Model;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb.Core.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options);

        Customer CreateCustomer(
            CreateCustomerOptions options);

        Customer UpdateCustomer(
            UpdateCustomerOptions options);

        Customer GetCustomerById(int? id);
    }
}
