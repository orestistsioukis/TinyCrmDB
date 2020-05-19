using System.Linq;
using TinyCrmDb.Core.Data;
using TinyCrmDb.Core.Model;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrmDb.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;

        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = new Customer()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                Phone = options.Phone
            };

            context_.Add(customer);
            if (context_.SaveChanges() > 0)
            {
                return customer;
            }
            return null;
        }


        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                query = query.Where(c => c.FirstName == options.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId == options.CustomerId); // value cause is nullable
            }

            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            query = query.Take(500);

            return query;
        }

        public Customer UpdateCustomer(UpdateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var updateCostumer = context_
                .Set<Customer>()
                .Where(c => c.CustomerId == options.CustomerId)
                .SingleOrDefault();
            if (updateCostumer == null)
            {
                return null;
            }

            if (options.Email != null)
            {
                updateCostumer.Email = options.Email;
            }

            if (options.FirstName != null)
            {
                updateCostumer.FirstName = options.FirstName;
            }

            if (options.LastName != null)
            {
                updateCostumer.LastName = options.LastName;
            }

            if (options.Phone != null)
            {
                updateCostumer.Phone = options.Phone;
            }

            if (options.IsActive != null)
            {
                updateCostumer.IsActive = (bool)options.IsActive;
            }

            if (context_.SaveChanges() > 0)
            {
                return updateCostumer;
            }

            return null;
        }

        public Customer GetCustomerById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            return query
                .Where(c => c.CustomerId == id)
                .SingleOrDefault();
        }
    }
}
