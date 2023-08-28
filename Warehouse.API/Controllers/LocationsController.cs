
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Exceptions;
using Warehouse.Application.Models;
using Warehouse.Application.Services;

namespace Warehouse.API.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {

            _locationService = locationService;

        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetFreeLocations(DateTime filter)
        {
            var freeLocations = await _locationService.GetFreeLocations(filter);

            return Ok(freeLocations);
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetLocation(int id)
        {
            try
            {
                var location = await _locationService.GetLocation(id);

                return Ok(location);
            }
            catch (Exception ex) { return NotFound(ex.Message); }

        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, LocationForCreateUpdateDto location)
        {
            try
            {
                 await _locationService.PutLocation(id,location);


                return NoContent();
            }
            catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex){
                return NotFound(ex.Message);
            }

        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationDto>> PostLocation(LocationForCreateUpdateDto location)
        {
            var locationToStore =  await _locationService.PostLocation(location);

            return CreatedAtAction("GetLocation", new { id = locationToStore.Id }, locationToStore);
        }

        // DELETE: api/Locations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLocation(int id)
        //{
        //    if (_context.Locations == null)
        //    {
        //        return NotFound();
        //    }
        //    var location = await _context.Locations.FindAsync(id);
        //    if (location == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Locations.Remove(location);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


    }
}
