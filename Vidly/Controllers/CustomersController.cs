using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route("Customers/ListCustomers")]
        public ActionResult ListCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "John Smith"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mary Williams"

                }
            };

            if (customers.Count == 0)
            {
                return View();
            }
            else
            {
                var viewModel = new CustomerListViewModel
                {
                    Customers = customers
                };
                return View(viewModel);
            }
        }

        [Route("Customers/Details/{id:range(1,2)}")]
        public ActionResult ShowCustomer(int id)

        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "John Smith"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mary Williams"

                }
            };

            Customer matchingCustomer = customers[0];

            foreach (Customer cust in customers)
            {
                if (cust.Id == id)
                {
                    matchingCustomer = cust;
                }
            };

            var viewModel = new IndividualCustomerViewModel
            {
                Name = matchingCustomer.Name
            };

            return View(viewModel);
            
        }
    }
}