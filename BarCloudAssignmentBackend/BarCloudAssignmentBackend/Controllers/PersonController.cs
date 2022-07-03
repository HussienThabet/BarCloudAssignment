using Dto;
using Microsoft.AspNetCore.Mvc;
using Services.PersonServices;

namespace BarCloudAssignmentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetPeople))]
        public ActionResult<IEnumerable<PersonDto>> GetPeople()
            => Ok(_service.GetPeople());

        [HttpPost(nameof(CreatePerson))]
        public ActionResult<PersonDto> CreatePerson(PersonDto person)
            => Ok(_service.CreatePerson(person));

        [HttpPost(nameof(EditPerson))]
        public ActionResult<PersonDto> EditPerson(PersonDto person)
          => Ok(_service.EditPerson(person));

        [HttpPost(nameof(DeletePerson))]
        public ActionResult<DeletedResponse> DeletePerson(PersonDto person)
        => Ok(_service.DeletePerson(person));
    }
}
