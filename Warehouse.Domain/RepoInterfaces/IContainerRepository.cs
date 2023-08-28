using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.RepoInterfaces
{
    public interface IContainerRepository
    {
        public  Task<IEnumerable<Container>> GetContainersAsync();
        public  Task<Container> GetContainerAsync(int id);
        public  Task PutContainerAsync(Container container);
        public Task PostContainerAsync(Container container);
        public bool ContainerExists(int id);
    }
}
