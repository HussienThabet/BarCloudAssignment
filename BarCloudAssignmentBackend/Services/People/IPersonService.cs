using Dto;

namespace Services.PersonServices
{
    public interface IPersonService
    {
        PersonDto CreatePerson(PersonDto person);
        DeletedResponse DeletePerson(PersonDto person);
        PersonDto EditPerson(PersonDto person);
        IEnumerable<PersonDto> GetPeople();
    }
}