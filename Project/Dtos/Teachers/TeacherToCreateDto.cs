using System.ComponentModel.DataAnnotations;
using static Data.DAL.DataAccessLayerService;

namespace Project.Dtos.Teachers
{
    public class TeacherToCreateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Teacher name can not be empty")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address can not be empty")]
        public string Address { get; set; }
               
        [Range(0, 3, ErrorMessage ="Range value must be between 0 - 3")]
        public Rank Rank { get; set; }
       
    }
}
