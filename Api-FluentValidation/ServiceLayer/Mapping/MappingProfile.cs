using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.Customer;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerListDto>();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerEditDto>().ReverseMap().ForAllMembers(m => m.Condition((dest,src,obj) => obj != null));
        }
    }
}
