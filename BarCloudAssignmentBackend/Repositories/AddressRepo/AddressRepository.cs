using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.AddressRepo
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAddresses()
           => _context
                .Addresses
                .Include(a => a.Person)
                .ToList();
        public Address CreateAddress(Address address)
        {
            var guid = Guid.NewGuid();
            address.Id = guid;
            address.Person = null;
            _context.Addresses.Add(address);

            if (_context.SaveChanges() > 0)
                return address;
            else return null;
        }
        public Address EditAddress(Address address)
        {
            var addressInDb = _context.Addresses.SingleOrDefault(x => x.Id == address.Id);
            addressInDb.BuildingNumber = address.BuildingNumber;
            addressInDb.Landmark = address.Landmark;
            addressInDb.PersonId = address.PersonId;
            addressInDb.Description = address.Description;

            if (_context.SaveChanges() > 0)
                return address;
            else return null;
        }
        public bool DeleteAddress(Address address)
        {
            var addressInDb = _context.Addresses.SingleOrDefault(x => x.Id == address.Id);
            _context.Addresses.Remove(addressInDb);

            if (_context.SaveChanges() > 0)
                return true;
            else return false;
        }
    }
}
