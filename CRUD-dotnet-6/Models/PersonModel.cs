using System.ComponentModel.DataAnnotations;

namespace CRUD_dotnet_6.Models
{
    public class PersonModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

    }
}
