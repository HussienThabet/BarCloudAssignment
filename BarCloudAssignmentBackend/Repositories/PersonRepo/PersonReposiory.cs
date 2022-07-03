

using Domain.Data;
using Domain.Entities;

namespace Repositories.PersonRepo
{
    public class PersonReposiory : IPersonReposiory
    {
        private readonly AppDbContext _context;
        public PersonReposiory(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPeople()
            => _context.Persons.ToArray();
        public Person CreatePerson(Person person)
        {
            var guid = Guid.NewGuid();
            person.Id = guid;

            _context.Persons.Add(person);

            if (_context.SaveChanges() > 0)
                return person;
            else return null;
        }
        public Person EditPerson(Person person)
        {
            var personInDb = _context.Persons.SingleOrDefault(x => x.Id == person.Id);
            personInDb.Name = person.Name;

            if (_context.SaveChanges() > 0)
                return person;
            else return null;
        }
        public bool DeletePerson(Person person)
        {
            var personInDb = _context.Persons.SingleOrDefault(x => x.Id == person.Id);
            _context.Persons.Remove(personInDb);

            if (_context.SaveChanges() > 0)
                return true;
            else return false;
        }

    }
}
