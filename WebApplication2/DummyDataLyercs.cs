using Microsoft.AspNetCore.HttpLogging;
using WebApplication2.Models;

namespace Customerproject
{

    public class DummyDataLyercs
    {
        private static List<Customer> customers = new List<Customer>();

        public static List<Customer> Customers
        {
            get
            {
                if(customers.Count == 0)
                {
                    PopulateCustomer();
                }
                return customers;
            }

        }
        private static void PopulateCustomer()
        {
            var cst = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                Name="jack",
                Age= 22,
                PostCode= "W3 7LG",
                Height= 2.1
            };

            customers.Add(cst);

             cst = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                Name = "Mike",
                Age = 31,
                PostCode = "W3 7RQ",
                Height = 1.5
            };

            customers.Add(cst);
        }
    }
}
