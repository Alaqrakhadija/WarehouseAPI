//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Warehouse.API.DbContexts;
//using Warehouse.API.Entities;
//using Warehouse.API.Services;

//namespace Warehouse.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ContainersController : ControllerBase
//    {
//        private readonly WarehouseContext _context;
//        //private readonly ContainerRepository _locationRepository;
//        private readonly ILogger<ContainersController> _logger;
//        public ContainersController(WarehouseContext context
//            , ILogger<ContainersController> logger)
//        {
//            _logger = logger;
//            _context = context;
//        }


//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
//        {
//          if (_context.Containers == null)
//          {
//              return NotFound();
//          }
//            return await _context.Containers.ToListAsync();
//        }

//        // GET: api/Containers/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Container>> GetContainer(int id)
//        {
//          if (_context.Containers == null)
//          {
//              return NotFound();
//          }
//            var container = await _context.Containers.FindAsync(id);

//            if (container == null)
//            {
//                return NotFound();
//            }

//            return container;
//        }

//        // PUT: api/Containers/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutContainer(int id, Container container)
//        {
//            if (id != container.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(container).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ContainerExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Containers
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Container>> PostContainer(Container container)
//        {
//          if (_context.Containers == null)
//          {
//              return Problem("Entity set 'WarehouseContext.Containers'  is null.");
//          }
//            _context.Containers.Add(container);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetContainer", new { id = container.Id }, container);
//        }

//        // DELETE: api/Containers/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteContainer(int id)
//        {
//            if (_context.Containers == null)
//            {
//                return NotFound();
//            }
//            var container = await _context.Containers.FindAsync(id);
//            if (container == null)
//            {
//                return NotFound();
//            }

//            _context.Containers.Remove(container);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ContainerExists(int id)
//        {
//            return (_context.Containers?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
