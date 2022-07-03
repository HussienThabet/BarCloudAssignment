using Domain.Entities;

namespace Repositories.AddressRepo
{
    public interface IAddressRepository
    {
        Address CreateAddress(Address address);
        bool DeleteAddress(Address address);
        Address EditAddress(Address address);
        IEnumerable<Address> GetAddresses();
    }
}