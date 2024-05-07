using System.ComponentModel.DataAnnotations;

namespace WebApp3ByAsim.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Faculty is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Faculty must be between 2 and 50 characters")]
        public string Faculty { get; set; }
    }
}
