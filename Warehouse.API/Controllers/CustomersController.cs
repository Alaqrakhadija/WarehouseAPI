
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Models;
using Warehouse.Application.Services;
using Warehouse.Domain.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;
        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _customerService = customerService;
            _mapper = mapper;

        }

        [HttpGet("{customerId}/packages")]
        public async Task<ActionResult<IEnumerable<PackageForCustomerDto>>> GetCustomerPackages(int customerId)
        {
            try
            {

                return Ok(await _customerService.GetCustomerPackagesAsync(customerId));
            }
            catch (Exception ex)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }
            
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetCustomers()
        {
            try {
                return Ok(await _customerService.GetCustomersAsync());

            }
            catch (Exception ex) {
                return NotFound();
            }
       
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetCustomer(int id)
        {
            try
            {
                return await _customerService.GetCustomerAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, UserDto customer)
        {
            try
            {
                await _customerService.PutCustomerAsync(id,  customer);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostCustomer(UserDto customer)
        {

            var customerToStore = await _customerService.AddCustomerAsync(customer);
            //return  Ok(_mapper.Map<PackageDto>(packageToStore));
            return CreatedAtAction("GetCustomer", new { id = customerToStore.Id }
            , Ok(customerToStore));

        }

    

    }
}
