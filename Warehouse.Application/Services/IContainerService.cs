using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Models;

namespace Warehouse.Application.Services
{
    public interface IContainerService
    {
        public Task<IEnumerable<ContainerDto>> GetContainers();
        public Task<ContainerDto> GetContainer(int id);
        public Task PutContainer(int id,ContainerToCreateUpdateDto container);
        public Task<ContainerDto> PostContainer(ContainerToCreateUpdateDto container);
    }
}
