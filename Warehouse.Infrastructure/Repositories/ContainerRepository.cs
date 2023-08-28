using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;
using Warehouse.Infrastructure.DbContexts;

namespace Warehouse.Infrastructure.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly WarehouseContext _context;
        private readonly ILogger<ContainerRepository> _logger;

        public ContainerRepository(WarehouseContext context, ILogger<ContainerRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        public async Task<Container> GetContainerAsync(int id)
        {
            return  await _context.Containers.FindAsync(id); 
        }

        public async Task<IEnumerable<Container>> GetContainersAsync()
        {
            return await _context.Containers.ToListAsync();
        }

        public async Task PostContainerAsync(Container container)
        {
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();
        }

        public async Task PutContainerAsync(Container container)
        {
            _context.Entry(container).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public bool ContainerExists(int id)
        {
            return (_context.Containers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
