using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Address
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int BuildingNumber { get; set; }

        [Required]
        public string Description { get; set; }
        public string Landmark { get; set; }

        [Required]
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
