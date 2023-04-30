using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PostCode { get; set; }
        public Double Height { get; set; }
    }

    public class ListCustomers
    {
        public Guid ListCustomerId { get; set; }
        public string ListName { get; set; }
        public int ListAge { get; set; }
        public string ListPostCode { get; set; }
        public Double ListHeight { get; set; }
    }
    public class MergeCustomer
    {
        public Customer Customer { get; set; } = new Customer();
        public List<ListCustomers> ListCustomers { get; set; } = new List<ListCustomers>();
    }
}