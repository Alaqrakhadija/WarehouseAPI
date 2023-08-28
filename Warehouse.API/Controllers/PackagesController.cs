using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Models;
using Warehouse.Application.Services;
using Warehouse.Domain.Entities;

namespace Warehouse.API.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : ControllerBase
    {

        private readonly IPackageService _packageServices;


        public PackagesController(IPackageService packageServices)
        {
            _packageServices = packageServices;
        }

        // GET: api/packages/byState?filtter=outgoing
        // GET: api/packages/byState?filtter=cuurent
        [HttpGet("byState")]
        public async Task<ActionResult<IEnumerable<PackageDto>>>
            GetPackagesByFilter([FromQuery] string filter)
        {
            return Ok(await _packageServices.GetPackagesByFilter(filter));
        }
        // GET: api/packages/byDateRange?start= & end=
        [HttpGet("byDateRange")]
        public async Task<ActionResult<IEnumerable<PackageForGroupingDto>>>
            GetPackagesByPeriod([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return Ok(await _packageServices.GetPackagesByPeriod(start,end));
        }
        // GET: api/packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageForGroupingDto>>>
            GetPackagesGroupByCustomer()
        {

            return Ok(await _packageServices.GetPackagesGroupByCustomer());
        }

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddPackage(PackageForCreationDto package)
        {
            try {
                var packageToStore=await _packageServices.AddPackage(package);
                return CreatedAtAction("GetPackage", new { id = packageToStore.Id }
               , packageToStore);
            }
            catch {
            
            return NotFound($"there are no locations available.");
            
            }
           
        }

        // DELETE: api/packages
        [HttpDelete]
        public async Task<IActionResult> DeleteUnArrivedPackages()
        {
            await _packageServices.DeleteUnArrivedPackages();

            return NoContent();
        }


        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDto>> GetPackage(int id)
        {
            try
            {

                var package = await _packageServices.GetPackage(id);

                return Ok(package);
            }
            catch
            {

                return NotFound($"Package with ID {id} not found.");

            }

        }
        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, PackageForUpdateDto package)
        {
            try
            {
                await _packageServices.PutPackage(id, package);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"Package with ID {id} not found.");
            }

        }








    }
}
