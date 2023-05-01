using Customerproject;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        //public static List<Customer> customers= new List<Customer>();

        [HttpGet]
        public IActionResult Create(Customer customerDtls)
        {
            ViewData["Title"] = "Customer Details";
            return PartialView("_Create", customerDtls);
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            if(customer.CustomerId == Guid.Empty)
            {
                customer.CustomerId = Guid.NewGuid();
                DummyDataLyercs.Customers.Add(customer);
            }
            else
            {
                var existingCustomer = DummyDataLyercs.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                if(existingCustomer != null)
                {
                    existingCustomer.CustomerId = customer.CustomerId;
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Age = customer.Age;
                    existingCustomer.PostCode = customer.PostCode;
                    existingCustomer.Height = customer.Height;
                }
            }
            ViewData["Title"] = "Customer Details";
            return RedirectToAction("Index");
        }
        public IActionResult Index(MergeCustomer mergeCustomer)
        {

            foreach (var item in DummyDataLyercs.Customers) {
                mergeCustomer.ListCustomers.Add(new ListCustomers
                {
                    ListCustomerId = item.CustomerId,
                    ListName = item.Name,
                    ListAge = item.Age,
                    ListPostCode = item.PostCode,
                    ListHeight = item.Height,
                });
                    }
            ViewData["ListTitle"] = "Customers";
            return View("Index",mergeCustomer);
        }
        public IActionResult Edit(Guid Id)
        {
            ViewData["Title"] = "Customer Details";
            if (Id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            MergeCustomer merge = new MergeCustomer();
            var result = DummyDataLyercs.Customers.Where(x => x.CustomerId == Id).FirstOrDefault();
            if(result == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                merge.Customer = result;
            }
            return Index (merge);
        }
    }
}
