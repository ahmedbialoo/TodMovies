using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using TodMovies.DTOS;
using TodMovies.Models;

namespace TodMovies.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/customers

        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = db.Customers
                .Include(n => n.MemberShipType);
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(n => n.Name.Contains(query));

            var customerDTO = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customerDTO);
        }

        // GET /api/customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var CustomerInDb = db.Customers.SingleOrDefault(n => n.Id == id);
            if (CustomerInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(CustomerInDb));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/id
        public IHttpActionResult PutCustomer(int id, CustomerDTO customerDto)
        {
            var CustomerInDb = db.Customers.SingleOrDefault(n => n.Id == id);
            if (CustomerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, CustomerInDb);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NotFound);
        }

        //DELETE /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var CustomerInDb = db.Customers.SingleOrDefault(n => n.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(CustomerInDb);
            db.SaveChanges();
        }
    }
}
