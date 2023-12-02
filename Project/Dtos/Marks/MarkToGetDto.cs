using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Marks
{
    public class MarkToGetDto
    {
        /// <summary>
        /// Name of the student
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Student name can not be empty")]
        public string StudentName { get; set; }
        /// <summary>
        /// Average of all notes
        /// </summary>
        public double Average { get; set; } 
     
    }
}
