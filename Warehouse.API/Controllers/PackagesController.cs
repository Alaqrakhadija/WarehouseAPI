using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Warehouse.API.DbContexts;
using Warehouse.API.Entities;
using Warehouse.API.Models;
using Warehouse.API.Services;

namespace Warehouse.API.Controllers
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : ControllerBase
    {

        private readonly PackageRepository _PackageRepository;
        private readonly ILogger<PackagesController> _logger;
        private readonly IMapper _mapper;
        public PackagesController( PackageRepository packageRepository,
            ILogger<PackagesController> logger, IMapper mapper)
        {
            _PackageRepository = packageRepository;
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageDto>>> 
            GetOutGoingOrCurrentPackages(string filter)
        {
            _logger.LogInformation("filter:" + filter);
            var Packages = await _PackageRepository.GetPackagesByFilterAsync(filter);
            return Ok(_mapper.Map <IEnumerable<PackageDto>> (Packages));
        }
       


        //// GET: api/Packages/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Package>> GetPackage(int id)
        //{
        //  if (_context.Packages == null)
        //  {
        //      return NotFound();
        //  }
        //    var package = await _context.Packages.FindAsync(id);

        //    if (package == null)
        //    {
        //        return NotFound();
        //    }

        //    return package;
        //}

        //// PUT: api/Packages/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPackage(int id, Package package)
        //{
        //    if (id != package.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(package).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PackageExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Packages
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Package>> PostPackage(Package package)
        //{
        //  if (_context.Packages == null)
        //  {
        //      return Problem("Entity set 'WarehouseContext.Packages'  is null.");
        //  }
        //    _context.Packages.Add(package);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        //}

        //// DELETE: api/Packages/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePackage(int id)
        //{
        //    if (_context.Packages == null)
        //    {
        //        return NotFound();
        //    }
        //    var package = await _context.Packages.FindAsync(id);
        //    if (package == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Packages.Remove(package);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PackageExists(int id)
        //{
        //    return (_context.Packages?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
