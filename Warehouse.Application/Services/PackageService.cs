using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Application.Services
{
    public class PackageService:IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        private readonly ILogger<IPackageService> _logger;
        public PackageService(IPackageRepository packageRepository
            , ILocationService locationService, IMapper mapper,ILogger<IPackageService> logger)
        {
            _packageRepository = packageRepository;
            _locationService = locationService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PackageDto> AddPackage(PackageForCreationDto package)
        {
            var location = await _locationService
              .GetFreeLocationForSpecificPeriod(package.ExpectedInDate,
              package.ExpectedOutDate, package.Dimensions);
            if (location == null)
                throw new Exception();
            var packageToStore = createPackage(package, location.Id);
            await _packageRepository.AddPackageAsync(packageToStore);
            return _mapper.Map<PackageDto>(packageToStore);
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

        public async Task DeleteUnArrivedPackages()
        {
            await _packageRepository.DeletePackagesAsync();
        }

        public async Task<PackageDto> GetPackage(int id)
        {
            var package = await _packageRepository.GetPackageAsync(id);

            if (package == null)
            {
                throw new Exception();
            }

            return _mapper.Map<PackageDto>(package);
        }

        public async Task<IEnumerable<PackageDto>> GetPackagesByFilter(string filter)
        {
            var Packages = await _packageRepository.GetPackagesByFilterAsync(filter);
            return _mapper.Map<IEnumerable<PackageDto>>(Packages);
        }

        public async Task<IEnumerable<PackageForGroupingDto>> GetPackagesByPeriod(DateTime start, DateTime end)
        {
            var PackagesByCustomer = await _packageRepository.GetPackagesByPeriodAsync(start, end);
            return _mapper.Map<IEnumerable<PackageForGroupingDto>>(PackagesByCustomer);
        }

        public async Task<IEnumerable<PackageForGroupingDto>> GetPackagesGroupByCustomer()
        {
            var PackagesByCustomer = await _packageRepository.GetPackagesGroupByCustomerAsync();
 
            return _mapper.Map<IEnumerable<PackageForGroupingDto>>(PackagesByCustomer);
        }

        public async Task PutPackage(int id, PackageForUpdateDto package)
        {
            if (!_packageRepository.PackageExists(id))
            {
                throw new Exception();
            }

            var packageToUpadte = await _packageRepository.GetPackageAsync(id);
            packageToUpadte.Type = package.Type;
            packageToUpadte.SpecialInstructions = package.SpecialInstructions;

            await _packageRepository.UpdatePackageAsync(packageToUpadte);
        }
    }
}
