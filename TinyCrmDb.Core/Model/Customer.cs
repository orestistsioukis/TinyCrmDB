using System;
using System.Collections.Generic;

namespace TinyCrmDb.Core.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VatNumber { get; set; }
        public decimal TotalGross { get; set; }
        public bool IsActive { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        public bool IsValidVatNumber(string vatNumber)
        {
            return
                !string.IsNullOrWhiteSpace(vatNumber) &&
                vatNumber.Length == 9;
        }
    }
}
