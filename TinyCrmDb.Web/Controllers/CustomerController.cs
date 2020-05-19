using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TinyCrmDb.Core.Data;
using TinyCrmDb.Core.Services;
using TinyCrmDb.Core.Services.Interfaces;

namespace TinyCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private TinyCrmDbContext dbContext_;
        private ICustomerService customerService_;
        public CustomerController()
        {
            var dbContext = new TinyCrmDbContext();
            var customerService = new CustomerService(dbContext_);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]SearchCustomerOptions options)
        {
            var customerDelete = customerService_.SearchCustomers(options);
            if (customerDelete == null)
            {
                return BadRequest();
            }
            customerDelete.Where(c => c.CustomerId == options.CustomerId);
            return Json(customerDelete);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCustomerOptions options)
        {
            var customer = customerService_.CreateCustomer(options);
            if (customer == null)
            {
                return BadRequest();
            }
            return Json(customer);
        }

        [HttpPost]
        public IActionResult SearchCustomers([FromBody]SearchCustomerOptions options)
        {
            if (options == null)
            {
                return BadRequest();
            }

            var customerList = customerService_
                .SearchCustomers(options)
                .ToList();

            if (customerList == null)
            {
                return NotFound();
            }

            return Json(customerList);
        }

        [HttpPost]
        public IActionResult Index()
        {
            var customerList = customerService_
                .SearchCustomers(new SearchCustomerOptions())
                .ToList();

            return Json(customerList);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var customer = customerService_
                .SearchCustomers(
                    new SearchCustomerOptions() { 
                        CustomerId = id
                    }).SingleOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Json(customer);
        }
    }
}