using System.ComponentModel.DataAnnotations;
using static Data.DAL.DataAccessLayerService;

namespace Project.Dtos.Teachers
{
    public class TeacherToCreateDto
    {
        /// <summary>
        /// Teacher's Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Teacher name can not be empty")]
        public string Name { get; set; }

        /// <summary>
        /// Teacher's Address
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address can not be empty")]
        public string Address { get; set; }
               
        /// <summary>
        /// Teacher's Rank
        /// </summary>
        [Range(0, 3, ErrorMessage ="Range value must be between 0 - 3")]
        internal Rank Rank { get; set; }
       
    }
}
