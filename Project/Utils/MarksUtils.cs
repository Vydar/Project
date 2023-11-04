using Data.Models;
using Project.Dtos.Marks;
using Project.Dtos.Students;

namespace Project.Utils
{
    public static class MarksUtils
    {
        public static MarkToGetDto ToDto(this MarkToGetDto mark)
        {
           
            if (mark == null)
            {
                return null;
            }

            return new MarkToGetDto { Id = mark.Id, DateTime = mark.DateTime, Grade = mark.Grade, StudentName = mark.StudentName, SubjectName = mark.SubjectName };
        }

      
    }
}
