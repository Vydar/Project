using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Marks
{
    public class MarkToCreateDto
    {
        
        /// <summary>
        /// Grade value [1 - 10 ]
        /// </summary>
        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
         public int Grade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Range(0, int.MaxValue)]
        public int StudentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SubjectId { get; set; }
    }

}
