using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC10Part2.Models;

namespace CC10Part2.Controllers
{
    public class CustomersController : ApiController
    {
        private masterEntities db = new masterEntities();

        
        [HttpGet]
        [Route("api/customers/bycountry/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers =(country).ToList();

            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }
    }
}
