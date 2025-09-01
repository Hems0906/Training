using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeChallenge10.Models;

namespace CodeChallenge10.Controllers
{
    public class CountryController : ApiController
    {
      
         static List<Country> countryList = new List<Country>()
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington D.C." }
        };

        // GET api/country
        public List<Country> Get()
        {
            return countryList;
        }

        // GET api/country/1
        public Country Get(int id)
        {
            return countryList.FirstOrDefault(c => c.ID == id);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Country c)
        {
            if (c == null)
                return BadRequest("Invalid country data");

            if (c.ID == 0)
                c.ID = countryList.Max(x => x.ID) + 1;

            countryList.Add(c);
            return Ok(countryList);
        }


        // PUT api/country/2
        [HttpPut]
        public List<Country> Put(int id, [FromBody] Country c)
        {
            var existing = countryList.FirstOrDefault(x => x.ID == id);
            if (existing != null)
            {
                existing.CountryName = c.CountryName;
                existing.Capital = c.Capital;
            }
            return countryList;
        }

        // DELETE api/country/2
        [HttpDelete]
        public List<Country> Delete(int id)
        {
            var existing = countryList.FirstOrDefault(x => x.ID == id);
            if (existing != null)
            {
                countryList.Remove(existing);
            }
            return countryList;
        }
    }
}
