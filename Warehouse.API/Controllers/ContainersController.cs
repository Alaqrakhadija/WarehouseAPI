
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Models;
using Warehouse.Application.Services;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IContainerService _containerService;

        public ContainersController(IContainerService containerService
          )
        {

            _containerService = containerService;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContainerDto>>> GetContainers()
        {

            return Ok(await _containerService.GetContainers());
        }

        // GET: api/Containers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContainerDto>> GetContainer(int id)
        {
            try
            {
                return Ok(await _containerService.GetContainer(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        // PUT: api/Containers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(int id, ContainerToCreateUpdateDto container)
        {
            try {
                await _containerService.PutContainer(id, container);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        // POST: api/Containers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContainerDto>> PostContainer(ContainerToCreateUpdateDto container)
        {

            var containerToAdd = await _containerService.PostContainer(container);

            return CreatedAtAction("GetContainer", new { id = containerToAdd.Id }, containerToAdd);
        }




    }
}
