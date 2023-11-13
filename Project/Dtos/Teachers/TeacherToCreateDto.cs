using System.ComponentModel.DataAnnotations;
using static Data.DAL.DataAccessLayerService;

namespace Project.Dtos.Teachers
{
    public class TeacherToCreateDto
    {
        /// <summary>
        /// Teacher's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Rank
        /// </summary>
        [Range(0, 3)]
        public Rank Rank { get; set; }
        //public int SubjectId { get; set; }
    }
}
