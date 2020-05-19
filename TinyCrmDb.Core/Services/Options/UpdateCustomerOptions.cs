namespace TinyCrmDb.Core.Services.Interfaces
{
    public class UpdateCustomerOptions
    {
        public int? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? IsActive { get; set; }

        //public List<string> OrderIds { get; set; }
        //public UpdateCustomerOptions()
        //{
        //    OrderIds = new List<string>();
        //}
    }
}