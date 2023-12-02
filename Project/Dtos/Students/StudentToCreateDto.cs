using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Students
{
    public class StudentToCreateDto
    {
        /// <summary>
        /// Student's Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student name can not be empty")]
        public string Name { get; set; }

        /// <summary>
        /// Student's Last Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street last name can not be empty")]
        public string LastName { get; set; }

        /// <summary>
        /// Student's Age
        /// </summary>
        [Range(0,100, ErrorMessage = "Age value must be between 0 to 100")]
        public int Age { get; set; }
    }
}
