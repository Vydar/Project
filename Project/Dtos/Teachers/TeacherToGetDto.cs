using static Data.DAL.DataAccessLayerService;

namespace Project.Dtos.Teachers
{
    public class TeacherToGetDto
    {
        /// <summary>
        /// Teacher's identification number
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Teacher's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Teacher's Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Teacher's Rank
        /// </summary>
        internal Rank Rank { get; set; }

    }
}
