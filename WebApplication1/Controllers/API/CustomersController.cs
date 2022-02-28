using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTOS;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return db.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        // GET /api/customers/id
        public CustomerDTO GetCustomer(int id)
        {
            var CustomerInDb = db.Customers.SingleOrDefault(n => n.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer,CustomerDTO>(CustomerInDb);
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            db.Customers.Add(customer);
            db.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        //PUT /api/customers/id
        public void PutCustomer(int id,CustomerDTO customerDto)
        {
            var CustomerInDb = db.Customers.SingleOrDefault(n => n.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, CustomerInDb);
            db.SaveChanges();
        }

        //DELETE /api/customers/id
        public void DelteCustomer(int id)
        {
            var CustomerInDb = db.Customers.SingleOrDefault(n => n.Id == id);
            if (CustomerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Customers.Remove(CustomerInDb);
            db.SaveChanges();
        }
    }
}
