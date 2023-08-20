using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;
using Warehouse.API.Models;
using Warehouse.API.Services;

namespace Warehouse.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly CustomerRepository _customerRepository;

        private readonly IMapper _mapper;
        public CustomersController(IMapper mapper,CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;

        }

        [HttpGet("{customerId}/packages")]
        public async Task<ActionResult<IEnumerable<Package>>> GetCustomerPackages(int customerId)
        {
            
            if (!  _customerRepository.CustomerExists(customerId))
            {
                return NotFound();
            }
            var customerPackages = await _customerRepository
                .GetCustomerPackagesAsync(customerId);


            return Ok(_mapper.Map <IEnumerable<PackageForCustomerDto>> (customerPackages));
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = _customerRepository.GetCustomersAsync();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(await _customerRepository.GetCustomersAsync());
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<User>(customer));
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, UserDto customer)
        {
            if (!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }
            var customerToUpdate = await _customerRepository.GetCustomerAsync(id);
            customerToUpdate.Name =customer.Name;
           await _customerRepository.UpdateCustomerAsync(customerToUpdate);

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(UserDto customer)
        {

            var customerToStore = _mapper.Map<Customer>(customer); 
            await _customerRepository.AddCustomerAsync(customerToStore);
            //return  Ok(_mapper.Map<PackageDto>(packageToStore));
            return CreatedAtAction("GetCustomer", new { id = customerToStore.Id }
            , Ok(_mapper.Map<User>(customerToStore)));

        }

    

    }
}
