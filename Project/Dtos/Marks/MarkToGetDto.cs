using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Marks
{
    public class MarkToGetDto
    {
        /// <summary>
        /// Name of the student
        /// </summary>
        
        public string StudentName { get; set; }
        /// <summary>
        /// Average of all notes
        /// </summary>
        public double Average { get; set; } 
     
    }
}
