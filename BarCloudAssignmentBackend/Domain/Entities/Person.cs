using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Person
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
               
    }
}
