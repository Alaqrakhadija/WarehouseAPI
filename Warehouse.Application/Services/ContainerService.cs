using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Application.Services
{
    public class ContainerService : IContainerService
    {
        private readonly IContainerRepository _containerRepository;
        private readonly IMapper _mapper;

        public ContainerService(IContainerRepository containerRepository,IMapper mapper)
        {
            _containerRepository = containerRepository;
            _mapper = mapper;
        }
        public async Task<ContainerDto> GetContainer(int id)
        {
            var container = await _containerRepository.GetContainerAsync(id);

            if (container == null)
            {
                throw new Exception($"Container with ID {id} not found.");
            }

            return _mapper.Map<ContainerDto>(container);
        }

        public async Task<IEnumerable<ContainerDto>> GetContainers()
        {
            return _mapper.Map<IEnumerable<ContainerDto>>(await _containerRepository.GetContainersAsync());
        }

        public async Task<ContainerDto> PostContainer(ContainerToCreateUpdateDto container)
        {

            var containerToAdd = _mapper.Map<Container>(container);

            await _containerRepository.PostContainerAsync(containerToAdd);
            return _mapper.Map<ContainerDto>(containerToAdd);
        }

        public async Task PutContainer(int id,ContainerToCreateUpdateDto container)
        {
            if (!_containerRepository.ContainerExists(id))
            {
                throw new Exception($"Container with ID {id} not found.");
            }
            var containerToUpdate = await _containerRepository.GetContainerAsync(id);
            containerToUpdate.Type = container.Type;
            await _containerRepository.PutContainerAsync(containerToUpdate);

        }
    }
}
