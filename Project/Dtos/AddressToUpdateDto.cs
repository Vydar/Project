using System.ComponentModel.DataAnnotations;

namespace Project.Dtos
{
    /// <summary>
    /// Data used to create or replace an address
    /// </summary>
    public class AddressToUpdateDto
    {
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street Name
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Street Number
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Number { get; set; }
    }
}
