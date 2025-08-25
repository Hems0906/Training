using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeChallenge9.Models;

namespace CodeChallenge9.Controllers
{
    public class CodeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }
        masterEntities db = new masterEntities();
      

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers
                              .Where(c => c.Country == "Germany")
                              .ToList();
            return View(customers);
        }

        public ActionResult CustomerByOrder()
        {
            var customer = (from o in db.Orders
                            join c in db.Customers on o.CustomerID equals c.CustomerID
                            where o.OrderID == 10248
                            select c).FirstOrDefault();

            return View(customer);
        }
    }
}