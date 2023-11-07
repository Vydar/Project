using Data.Models;
using Project.Dtos.Students;
using Project.Dtos.Teachers;

namespace Project.Utils
{
    public static  class TeacherUtils
    {
        public static Teacher ToEntity(this TeacherToCreateDto teacher)
        {
            if (teacher == null)
            {
                return null;
            }
            return new Teacher
            {
                Name = teacher.Name,
                Address = teacher.Address,
                Rank = teacher.Rank,
                //SubjectId = teacher.SubjectId,
            };
        }

        public static TeacherToGetDto ToDto(this Teacher teacher)
        {
            if (teacher == null)
            {
                return null;
            }
            return new TeacherToGetDto
            {
                Name = teacher.Name,
                Address = teacher.Address,
                Rank = teacher.Rank,
                //SubjectId = teacher.SubjectId,

            };

        }
    }
}
