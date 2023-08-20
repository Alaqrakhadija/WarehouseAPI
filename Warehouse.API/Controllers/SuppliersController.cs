using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;
using Warehouse.API.Models;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly WarehouseContext _context;
        private readonly IMapper _mapper;

        public SuppliersController(WarehouseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetSuppliers()
        {
          if (_context.Suppliers == null)
          {
              return NotFound();
          }
            return  Ok(_mapper.Map<IEnumerable<User>>(await _context.Suppliers.ToListAsync()));
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
          if (_context.Suppliers == null)
          {
              return NotFound();
          }
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<User>(supplier));
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, User supplier)
        {
            if (!SupplierExists(id))
            {
                return NotFound();
            }
            var supplierToUpdate = await _context.Suppliers.FindAsync(id);
            supplierToUpdate.Name = supplier.Name;
            _context.Entry(supplierToUpdate).State = EntityState.Modified;

      

            return NoContent();
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(UserDto supplier)
        {
          if (_context.Suppliers == null)
          {
              return Problem("Entity set 'WarehouseContext.Suppliers'  is null.");
          }
          var supplierToAdd = _mapper.Map<Supplier>(supplier);
            _context.Suppliers.Add(supplierToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = supplierToAdd.Id }, _mapper.Map<User>(supplierToAdd));
        }


        private bool SupplierExists(int id)
        {
            return (_context.Suppliers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
