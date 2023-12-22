using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC3.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }
        public string TypeOfUser { get; set; }
        [ForeignKey("UserId")]  
        public ICollection<Employee> Employees { get; set; }

    }
}
