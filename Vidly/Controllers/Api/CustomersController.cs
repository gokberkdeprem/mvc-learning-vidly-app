using AutoMapper;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;
using System;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            //we use eager loading to show memberership type on Api
            return _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }

        //public IEnumerable<Customer> GetCustomers()
        //{
        //    return _context.Customers.ToList();
        //}


        //GET 



        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            
        }

        //public CustomerDto GetCustomer(int id)
        //{
        //    var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
        //    if (customer == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return Mapper.Map<Customer, CustomerDto>(customer);

        //}


        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            //Microsoft solution is remove HttpPost and write PostCustomer, it may cause problem

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            //Id created by db so we need to send to customer dto
            customerDto.ID = customer.ID;

            return Created(new Uri(Request.RequestUri + "/" + customer.ID),customerDto);
            //unified resource identifier
            // api/customer/10
        }
    
        //public CustomerDto CreateCustomer(CustomerDto customerDto)
        //{
        //    //Microsoft solution is remove HttpPost and write PostCustomer, it may cause problem

        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();

        //    //Id created by db so we need to send to customer dto
        //    customerDto.ID = customer.ID;

        //    return customerDto;

        //}





        //PUT /api/customer/1


        [HttpPut]
        public void UpdateCustomer(int id , CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //customer may send an invalid ID so we need to check it
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //We could use TryUpdateMethod() however it may cause security issues. Customer may change unwanted data
            //Then we could use automapper for more codeline Mapper.Map(customer,customer.InDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            Mapper.Map(customerDto,customerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();
        }
    }
}
