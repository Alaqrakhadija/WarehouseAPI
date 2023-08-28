
using AutoMapper;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepository supplierRepository,IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<User> GetSupplier(int id)
        {
            var supplier = await _supplierRepository.GetSupplierAsync(id);
            if(supplier == null)
            {
                throw new Exception($"Supplier with ID {id} not found.");
            }
            return _mapper.Map<User>( supplier);
        }

        public async Task<IEnumerable<User>> GetSuppliers()
        {
            return _mapper.Map<IEnumerable<User>>(await _supplierRepository.GetSuppliersAsync());
        }

        public async Task<User> PostSupplier(UserDto supplier)
        {
     
            var supplierToAdd = _mapper.Map<Supplier>(supplier);

         await _supplierRepository.PostSupplierAsync(supplierToAdd);
            return _mapper.Map<User>(supplierToAdd);
        }

        public async Task PutSupplier(int id, UserDto supplier)
        {
            var supplierToUpdate = await _supplierRepository.GetSupplierAsync(id);
            if (supplierToUpdate == null)
            {
                throw new Exception($"Supplier with ID {id} not found.");
            }
            supplierToUpdate.Name = supplier.Name;
            await _supplierRepository.PutSupplierAsync(supplierToUpdate);

        }
    }
}
