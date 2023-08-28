using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Exceptions;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ILocationService> _logger;

        public LocationService(ILocationRepository locationRepository,IMapper mapper,ILogger<ILocationService> logger)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public Task DeleteLocation(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Location> GetFreeLocationForSpecificPeriod(DateTime start, DateTime end, int diminsion)
        {
            return await _locationRepository.GetFreeLocationForSpecificPeriodAsync(start, end, diminsion);
        }

        public async Task<IEnumerable<LocationDto>> GetFreeLocations(DateTime filter)
        {
            var freeLocations = await _locationRepository.GetFreeLocationsByDateAsync(filter);

            return _mapper.Map<IEnumerable<LocationDto>>(freeLocations);
        }

        public async Task<LocationDto> GetLocation(int id)
        {
            var location = await _locationRepository.GetLocationAsync(id);

            if (location == null)
            {
                throw new Exception($"Location with ID {id} not found.");
            }

            return _mapper.Map<LocationDto>(location);
        }

        public async Task<LocationDto> PostLocation(LocationForCreateUpdateDto location)
        {
            var locationToStore = _mapper.Map<Location>(location);

            await _locationRepository.AddLocationAsync(locationToStore);

            return _mapper.Map<LocationDto>(locationToStore);
        }

        public async Task PutLocation(int id, LocationForCreateUpdateDto location)
        {
            if (!_locationRepository.LocationExists(id))
            {
                throw new Exception($"Location with ID {id} not found.");
            }

            if (!_locationRepository.ValidDimension(id, location.Dimensions))
            {
                throw new BadRequestException("Dimension Not Suitable with current packages");
            }
            var locationToUpdate = await _locationRepository.GetLocationAsync(id);
            locationToUpdate.Dimensions = location.Dimensions;
            await _locationRepository.UpdateLocationAsync(locationToUpdate);
        }
    }
}
