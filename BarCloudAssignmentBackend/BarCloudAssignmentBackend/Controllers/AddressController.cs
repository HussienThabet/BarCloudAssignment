using Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Addresses;

namespace BarCloudAssignmentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;
        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetAddresses))]
        public ActionResult<IEnumerable<AddressDto>> GetAddresses()
            => Ok(_service.GetAddresses());

        [HttpPost(nameof(CreateAddress))]
        public ActionResult<AddressDto> CreateAddress(AddressDto address)
            => Ok(_service.CreateAddress(address));

        [HttpPost(nameof(EditAddress))]
        public ActionResult<AddressDto> EditAddress(AddressDto person)
          => Ok(_service.EditAddress(person));

        [HttpPost(nameof(DeleteAddress))]
        public ActionResult<DeletedResponse> DeleteAddress(AddressDto address)
        => Ok(_service.DeleteAddress(address));
    }
}
