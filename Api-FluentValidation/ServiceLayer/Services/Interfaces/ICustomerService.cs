using ServiceLayer.DTOs.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerListDto>> GetAllAsync();
        Task InsertAsync(CustomerCreateDto customer);
        Task UpdateAsync(int id, CustomerEditDto customer);
        Task<CustomerListDto> GetByNameAsync(string name);
        Task<IEnumerable<CustomerListDto>> GetAllByConditionAsync(string search);
    }
}
