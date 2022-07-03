using AutoMapper;
using Domain.Entities;
using Dto;


namespace Services.Mapping
{
    public  class PersonAddressProfile : Profile
    {
        public PersonAddressProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap(); 
            CreateMap<Address, AddressDto>().ReverseMap(); 
        }
    }
}
