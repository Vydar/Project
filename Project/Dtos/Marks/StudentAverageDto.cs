using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Marks
{
    public class StudentAverageDto
    {
        /// <summary>
        /// Student Identification Number
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Student Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }

        /// <summary>
        /// Average of all notes of a student
        /// </summary>
        public double AverageGrade { get; set; }
    }
}
