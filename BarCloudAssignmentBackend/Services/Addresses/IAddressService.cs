using Dto;

namespace Services.Addresses
{
    public interface IAddressService
    {
        AddressDto CreateAddress(AddressDto address);
        DeletedResponse DeleteAddress(AddressDto address);
        AddressDto EditAddress(AddressDto address);
        IEnumerable<AddressDto> GetAddresses();
    }
}