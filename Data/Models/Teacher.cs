using static Data.DAL.DataAccessLayerService;

namespace Data.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Rank Rank { get; set; }
        public int SubjectId { get; set; }
    }
}
