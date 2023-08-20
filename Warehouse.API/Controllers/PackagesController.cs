using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;
using Warehouse.API.Models;
using Warehouse.API.Services;
using Microsoft.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace Warehouse.API.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : ControllerBase
    {

        private readonly PackageRepository _packageRepository;
        private readonly LocationRepository _locationRepository;
        private readonly ILogger<PackagesController> _logger;
        private readonly IMapper _mapper;
        public PackagesController( PackageRepository packageRepository,
            ILogger<PackagesController> logger, IMapper mapper, LocationRepository locationRepository)
        {
            _packageRepository = packageRepository;
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _locationRepository = locationRepository;
        }

        // GET: api/packages/byState?filtter=outgoing
        // GET: api/packages/byState?filtter=cuurent
        [HttpGet("byState")]
        public async Task<ActionResult<IEnumerable<PackageDto>>> 
            GetPackagesByFilter([FromQuery] string filter)
        {

            var Packages = await _packageRepository.GetPackagesByFilterAsync(filter);
            return Ok(_mapper.Map <IEnumerable<PackageDto>> (Packages));
        }
        // GET: api/packages/byDateRange?start= & end=
        [HttpGet("byDateRange")]
        public async Task<ActionResult<IEnumerable<PackageForGroupingDto>>>
            GetPackagesByPeriod([FromQuery]DateTime start , [FromQuery] DateTime end)
        {

            var PackagesByCustomer = await _packageRepository.GetPackagesByPeriodAsync(start,end);
            return Ok(_mapper.Map<IEnumerable<PackageForGroupingDto>>(PackagesByCustomer));
        }
        // GET: api/packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageForGroupingDto>>>
            GetPackagesGroupByCustomer()
        {

            var PackagesByCustomer = await _packageRepository.GetPackagesGroupByCustomerAsync();
            return Ok(_mapper.Map<IEnumerable<PackageForGroupingDto>>(PackagesByCustomer));
        }

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddPackage(PackageForCreationDto package)
        {
            var location = await _locationRepository
                          .GetFreeLocationForSpecificPeriodAsync(package.ExpectedInDate,
                          package.ExpectedOutDate, package.Dimensions);
            if(location==null)
             return NotFound("there are no locations available"); 
            var packageToStore = createPackage(package,location.Id);
 await _packageRepository.AddPackageAsync(packageToStore);
            //return  Ok(_mapper.Map<PackageDto>(packageToStore));
            return CreatedAtAction("GetPackage", new { id = packageToStore.Id }
            , Ok(_mapper.Map<PackageDto>(packageToStore)));
        }

        // DELETE: api/packages
        [HttpDelete]
        public async Task<IActionResult> DeleteUnArrivedPackages()
        {
 await _packageRepository.DeletePackagesAsync();

            return NoContent();
        }


        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDto>> GetPackage(int id)
        {

            var package = await _packageRepository.GetPackageAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map< PackageDto >( package));
        }
        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, PackageForUpdateDto package)
        {
            if (!_packageRepository.PackageExists(id))
            {
                return NotFound();
            }

            var packageToUpadte = await _packageRepository.GetPackageAsync(id);
            packageToUpadte.Type = package.Type;
            packageToUpadte.SpecialInstructions = package.SpecialInstructions;

            await _packageRepository.UpdatePackageAsync(packageToUpadte);

            return NoContent();
        }
        public Package createPackage(PackageForCreationDto package, int locationId)
        {
            return new Package
            {
                CustomerId = package.CustomerId,
                ContainerId = package.ContainerId,
                Dimensions = package.Dimensions,
                SpecialInstructions = package.SpecialInstructions,
                Type = package.Type,
                SchedulingProcess = new SchedulingProcess
                {
                    ExpectedInDate = package.ExpectedInDate,
                    ExpectedOutDate = package.ExpectedOutDate,
                    LocationId = locationId,
                }
            };
        }







    }
}
