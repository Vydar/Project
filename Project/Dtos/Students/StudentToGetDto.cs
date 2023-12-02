using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Students
{
    public class StudentToGetDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Student's Name  
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Studemt name can not be empty")]
        public string Name { get; set; }

        /// <summary>
        /// Student's last name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name can not be empty")]
        public string LastName { get; set; }

        /// <summary>
        /// Student's Age
        /// </summary>
        [Range(0, 100, ErrorMessage = "Age value must be between 0 to 100")]
        public int Age { get; set; }

    }
}
