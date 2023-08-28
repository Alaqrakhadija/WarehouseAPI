using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.Application.Models;
using Warehouse.Domain.Entities;
using Warehouse.Domain.RepoInterfaces;

namespace Warehouse.Application.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,
            ILogger<CustomerService> logger,IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _customerRepository = customerRepository;

        }

        public async Task<IEnumerable<PackageForCustomerDto>> GetCustomerPackagesAsync(int customerId)
        {

            if (!_customerRepository.CustomerExists(customerId))
            {
                throw new Exception();
            }
            var customerPackages = await _customerRepository
                .GetCustomerPackagesAsync(customerId);

            return _mapper.Map<IEnumerable<PackageForCustomerDto>>(customerPackages);

        }
        public async Task<IEnumerable<User>> GetCustomersAsync()
        {
            var customers = _customerRepository.GetCustomersAsync();
            if (customers == null)
            {
                throw new Exception();
            }
            return _mapper.Map<IEnumerable<User>>(await _customerRepository.GetCustomersAsync());
        }
        public async Task<User> GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);
            if (customer == null)
            {
                throw new Exception();
            }
            return _mapper.Map<User>(customer);
        }
        public async Task<User> AddCustomerAsync(UserDto customer)
        {
            var customerToStore = _mapper.Map<Customer>(customer);
            await _customerRepository.AddCustomerAsync(customerToStore);
            return _mapper.Map<User>(customerToStore);
        }
        public async Task PutCustomerAsync(int id, UserDto customer)
        {
            if (!_customerRepository.CustomerExists(id))
            {
                throw new Exception();
            }
            var customerToUpdate = await _customerRepository.GetCustomerAsync(id);
            customerToUpdate.Name = customer.Name;
            await _customerRepository.UpdateCustomerAsync(customerToUpdate);

        }




    }
}
