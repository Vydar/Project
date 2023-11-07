using Data.Models;
using static Data.DAL.DataAccessLayerService;

namespace Project.Dtos.Teachers
{
    public class TeacherToCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Rank Rank { get; set; }
        //public int SubjectId { get; set; }
    }
}
