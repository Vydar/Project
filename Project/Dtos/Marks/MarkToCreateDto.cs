using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Marks
{
    public class MarkToCreateDto
    {

        /// <summary>
        /// Grade value [1 - 10]
        /// </summary>
        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int Grade { get; set; }
        /// <summary>
        /// Student identification number 
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Value must be a positive")]
        public int StudentId { get; set; }
        /// <summary>
        /// Subject identification number 
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Value must be a positive")]
        public int SubjectId { get; set; }



    }

}
