using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Students
{
    /// <summary>
    /// Data used to create or replace an address
    /// </summary>
    public class AddressToUpdateDto
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "City name can not be empty")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Street name can not be empty")]
        public string Street { get; set; }

        [Range(1, int.MaxValue)]
        public int Number { get; set; }
    }
}
