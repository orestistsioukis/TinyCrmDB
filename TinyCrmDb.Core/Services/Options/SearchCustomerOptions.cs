using System;

namespace TinyCrmDb.Core.Services.Interfaces
{
    public class SearchCustomerOptions
    {
        public int? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset? CreateFrom { get; set; }
        public DateTimeOffset? CreateTo { get; set; }
        public bool? IsActive { get; set; }
    }
}
