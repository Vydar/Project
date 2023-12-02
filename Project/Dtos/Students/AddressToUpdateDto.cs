using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Students
{
    /// <summary>
    /// Data used to create or replace an address
    /// </summary>
    public class AddressToUpdateDto
    {
        /// <summary>
        /// City Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "City name can not be empty")]
        public string City { get; set; }

        /// <summary>
        /// Street Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street name can not be empty")]
        public string Street { get; set; }


        /// <summary>
        /// Street Number
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
    }
}
