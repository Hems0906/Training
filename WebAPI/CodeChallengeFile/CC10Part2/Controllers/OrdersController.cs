using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10Part2.Models;

namespace CC10Part2.Controllers
{
    public class OrdersController : ApiController
    {

        private masterEntities db = new masterEntities();

        
        [HttpGet]
        [Route("api/orders/byemployee/{id}")]
        public IHttpActionResult GetOrdersByEmployee(int id)
        {
            var orders = db.Orders
                           .Where(o => o.EmployeeID == id)
                           .Select(o => new
                           {
                               o.OrderID,
                               o.OrderDate,
                               o.ShipName,
                               o.ShipCity
                           }).ToList();

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }
    }
}
