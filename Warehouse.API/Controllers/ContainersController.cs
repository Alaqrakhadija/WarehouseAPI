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
using Warehouse.API.Services;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly WarehouseContext _context;

        private readonly ILogger<ContainersController> _logger;
        private readonly IMapper _mapper;
        public ContainersController(WarehouseContext context
            , ILogger<ContainersController> logger,IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContainerDto>>> GetContainers()
        {
            if (_context.Containers == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ContainerDto>>(await _context.Containers.ToListAsync()));
        }

        // GET: api/Containers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContainerDto>> GetContainer(int id)
        {
            if (_context.Containers == null)
            {
                return NotFound();
            }
            var container = await _context.Containers.FindAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ContainerDto>(container));
        }

        // PUT: api/Containers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(int id, ContainerToCreateUpdateDto container)
        {
            if (!ContainerExists(id))
            {
                return NotFound();
            }
            var containerToUpdate = await _context.Containers.FindAsync(id);
            containerToUpdate.Type=container.Type;
            _context.Entry(containerToUpdate).State = EntityState.Modified;


            return NoContent();
        }

        // POST: api/Containers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Container>> PostContainer(ContainerToCreateUpdateDto container)
        {
            if (_context.Containers == null)
            {
                return Problem("Entity set 'WarehouseContext.Containers'  is null.");
            }
            var containerToAdd = _mapper.Map<Container>(container);
            _context.Containers.Add(containerToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = containerToAdd.Id }, _mapper.Map<ContainerDto>(containerToAdd));
        }



        private bool ContainerExists(int id)
        {
            return (_context.Containers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
