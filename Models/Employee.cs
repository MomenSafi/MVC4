using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC3.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int IdEmployee { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        public int UserId { get; set; }  // Renamed to follow convention
        public Users Users { get; set; }  // Navigation property

    }
}
