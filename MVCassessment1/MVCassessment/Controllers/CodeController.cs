using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using MVCassessment.Models;  
using System.Data.Entity;
   

namespace MVCassessment.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();  

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                .Where(c => c.Country == "Germany")
                .ToList();
            return View(customers);
        }

        public ActionResult CustomerDetailsByOrderId()
        {
            var customerDetails = db.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o.Customer)
                .FirstOrDefault();

            return View(customerDetails);
        }
    }
}
