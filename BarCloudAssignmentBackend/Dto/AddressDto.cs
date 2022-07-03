using System.ComponentModel.DataAnnotations;

namespace Dto
{
    public class AddressDto
    {
        public Guid? Id { get; set; }

        [Required]
        public int BuildingNumber { get; set; }

        [Required]
        public string Description { get; set; }
        public string Landmark { get; set; }

        [Required]
        public Guid PersonId { get; set; }
        public PersonDto? Person { get; set; }
    }
}
