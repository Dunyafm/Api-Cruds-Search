using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Customer;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CustomerListDto>> GetAllAsync()
        {
            
            return _mapper.Map<List<CustomerListDto>>(await _repository.GetAllAsync());
        }

        public async Task InsertAsync(CustomerCreateDto customer)
        {
            await _repository.CreateAsync(_mapper.Map<Customer>(customer));
        }

        public async Task UpdateAsync(int id, CustomerEditDto customer)
        {
            var entity = await _repository.GetAsync(id);

            _mapper.Map(customer, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task<CustomerListDto> GetByNameAsync(string search)
        {
            var model = await _repository.FindAsync(m => m.FullName == search);

            return _mapper.Map<CustomerListDto>(model);
            
        }

        public async Task<IEnumerable<CustomerListDto>> GetAllByConditionAsync(string search)
        {
            return _mapper.Map<IEnumerable<CustomerListDto>>(await _repository.FindAllAsync(m => m.FullName.Contains(search)));
        }
    }
}
