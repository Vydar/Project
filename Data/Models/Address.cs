namespace Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }    
        public string Street { get; set; }
        public int Number { get; set; }

        public int StudentId { get; set; } //volver a borrar en caso
        //public Student Student { get; set; }

    }
}
