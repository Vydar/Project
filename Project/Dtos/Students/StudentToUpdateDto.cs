using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Students
{
    public class StudentToUpdateDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Studemt name can not be empty")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name can not be empty")]
        public string LastName { get; set; }

        [Range(0, 100, ErrorMessage = "Age value must be between 0 to 100")]
        public int Age { get; set; }
    }
}
