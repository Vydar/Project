namespace Data.Models
{

    /// <summary>
    /// Notes model - Id, Grade, DateTime, Average, SubjectId, StudentId
    /// </summary>
    public class Mark
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public DateTime DateTime { get; set; } 

        public double Average { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int StudentId { get; set; } //navigational property
        public Student Student { get; set; }

    }
}
