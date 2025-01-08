using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIassessment.Models;

namespace APIassessment.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "USA", Capital = "Washington D.C." },
            new Country { ID = 3, CountryName = "Japan", Capital = "Tokyo" }
        };

        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> GetAllCountries()
        {
            return countries;
        }

        // GET: api/Country/1
        [HttpGet]
        public IHttpActionResult GetCountryById(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        // POST: api/Country
        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            countries.Add(country);
            return Ok(country);
        }

        // PUT: api/Country/1
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return Ok(country);
        }

        // DELETE: api/Country/1
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok("Country deleted successfully.");
        }

    }
}
