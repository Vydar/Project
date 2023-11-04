using System.ComponentModel.DataAnnotations;

namespace Project.Dtos.Marks
{
    public class MarkToGetDto
    {
        public int Id { get; set; }

        public int Grade { get; set; }
        public DateTime DateTime { get; set; }
        public int? SubjectId { get; set; }
        public int StudentId { get; set; }
    }
}
