using AutoMapper;
using Domain.Entities;
using Dto;
using Repositories.PersonRepo;


namespace Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonReposiory _reposiory;
        private readonly IMapper _mapper;
        public PersonService(IPersonReposiory reposiory, IMapper mapper)
        {
            _reposiory = reposiory;
            _mapper = mapper;
        }
        public IEnumerable<PersonDto> GetPeople()
          => _mapper.Map<IEnumerable<PersonDto>>(_reposiory.GetPeople());
        public PersonDto CreatePerson(PersonDto person)
        {
            var _person = _mapper.Map<PersonDto>(_reposiory.CreatePerson(_mapper.Map<Person>(person)));
            if (_person != null)
                return _person;
            else return null;
        }
        public PersonDto EditPerson(PersonDto person)
        {
            var _person = _mapper.Map<PersonDto>(_reposiory.EditPerson(_mapper.Map<Person>(person)));
            if (_person != null)
                return _person;
            else return null;
        }
        public DeletedResponse DeletePerson(PersonDto person)
            => new DeletedResponse { IsDeleted = _reposiory.DeletePerson(_mapper.Map<Person>(person)) };

    }
}
