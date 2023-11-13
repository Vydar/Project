using Data.Models;
using Project.Dtos.Teachers;

namespace Project.Utils
{
    public static class MarkUtils
    {

        public static NotesFromTeacherToGetDto ToDto(Mark mark)
        {
            if (mark == null)
            {
                return null;
            }
            return new NotesFromTeacherToGetDto
            {
                DateTime = mark.DateTime,
                Grade = mark.Grade,
                StudentId = mark.StudentId,
            };
        }
    }
}
