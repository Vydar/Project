namespace Data.Models
{
    /// <summary>
    /// Address model - Id, City, Street, Number, StudentId
    /// </summary>
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int StudentId { get; set; }
    }
}
