using AutoMapper;
using Domain.Entities;
using Dto;
using Repositories.AddressRepo;

namespace Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _reposiory;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository reposiory, IMapper mapper)
        {
            _reposiory = reposiory;
            _mapper = mapper;
        }
        public IEnumerable<AddressDto> GetAddresses()
          => _mapper.Map<IEnumerable<AddressDto>>(_reposiory.GetAddresses());
        public AddressDto CreateAddress(AddressDto address)
        {
            var _address = _mapper.Map<AddressDto>(_reposiory.CreateAddress(_mapper.Map<Address>(address)));
            if (_address != null)
                return _address;
            else return null;
        }
        public AddressDto EditAddress(AddressDto address)
        {
            var _address = _mapper.Map<AddressDto>(_reposiory.EditAddress(_mapper.Map<Address>(address)));
            if (_address != null)
                return _address;
            else return null;
        }
        public DeletedResponse DeleteAddress(AddressDto address)
            => new DeletedResponse { IsDeleted = _reposiory.DeleteAddress(_mapper.Map<Address>(address)) };

    }
}
