using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Models;
using Warehouse.Application.Services;
using Warehouse.Domain.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;


        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;

        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetSuppliers()
        {
          
                return Ok(await _supplierService.GetSuppliers());
           
      

        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSupplier(int id)
        {
            try
            {
                return Ok(await _supplierService.GetSupplier(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, UserDto supplier)
        {
            try
            {
                await _supplierService.PutSupplier(id, supplier);
                return NoContent();
            }
            catch (Exception ex){

                return NotFound(ex.Message);
            }

   
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostSupplier(UserDto supplier)
        {
            var supplierToAdd = await _supplierService.PostSupplier(supplier);

            return CreatedAtAction("GetSupplier", new { id = supplierToAdd.Id }, supplierToAdd);
        }



    }
}
