using Domain.Entities;

namespace Repositories.PersonRepo
{
    public interface IPersonReposiory
    {
        Person CreatePerson(Person person);
        bool DeletePerson(Person person);
        Person EditPerson(Person person);
        IEnumerable<Person> GetPeople();
    }
}