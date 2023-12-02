using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Students
{

    public class AddressToGetDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        
        [MaxLength(100, ErrorMessage = "Maximum City Name lenght = 100 characters")]
        public string City { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street name can not be empty")]
        public string Street { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
    }
}
