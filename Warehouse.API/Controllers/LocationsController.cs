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
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly LocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LocationsController> _logger;
        public LocationsController( LocationRepository locationRepository, IMapper mapper, ILogger<LocationsController> logger)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
            _logger = logger;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetFreeLocations(DateTime filter)
        {
            var freeLocations = await _locationRepository.GetFreeLocationsByDateAsync(filter);

            return Ok(_mapper.Map<IEnumerable<LocationDto>>(freeLocations));
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {

            var location = await _locationRepository.GetLocationAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LocationDto>(location));
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, LocationForCreateUpdateDto location)
        {
            if (!_locationRepository.LocationExists(id))
            {
                return NotFound();
            }

            if (!_locationRepository.ValidDimension(id, location.Dimensions))
            {
                return BadRequest("Dimension Not Suitable with current packages");
            }
            var locationToUpdate = await _locationRepository.GetLocationAsync(id);
            locationToUpdate.Dimensions = location.Dimensions;
            await _locationRepository.UpdateLocationAsync(locationToUpdate);


            return NoContent();
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(LocationForCreateUpdateDto location)
        {
            var locationToStore = _mapper.Map<Location>(location);

            await _locationRepository.AddLocationAsync(locationToStore);

            return CreatedAtAction("GetLocation", new { id = locationToStore.Id }, _mapper.Map<LocationDto>(locationToStore));
        }

        //// DELETE: api/Locations/5
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
