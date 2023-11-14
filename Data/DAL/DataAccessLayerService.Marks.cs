using Data.Exceptions;
using Data.Models;
using Project.Dtos.Marks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        /// <summary>
        /// Adds a note to a student
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <exception cref="InvalidIdException"></exception>
        public void AddMark(int grade, int studentId, int subjectId)
        {
            if (!context.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"The Id {studentId}, does not match any student on the Database");
            }
            if (!context.Subjects.Any(s => s.Id == subjectId))
            {
                throw new InvalidIdException($"The Id {subjectId}, does not match any student on the Database");
            }

            context.Marks.Add(new Mark { Grade = grade, DateTime = DateTime.Now, StudentId = studentId, SubjectId = subjectId });
            context.SaveChanges();
        }

        /// <summary>
        /// Gets all the notes of a student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public IEnumerable<Mark> GetAllMarks(int studentId)
        {
            var marks = context.Marks.Where(m => m.StudentId == studentId).ToList();
            return marks;
        }

        /// <summary>
        /// Gets all the notes of a student on one specific subject.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public IEnumerable<Mark> GetMarkBySubject(int studentId, int subjectId)
        {
            if (!context.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"The Id {studentId}, does not match any student on the Database");
            }
            if (!context.Subjects.Any(s => s.Id == subjectId))
            {
                throw new InvalidIdException($"The Id {subjectId}, does not match any student on the Database");
            }

            var mark = context.Marks.Where(s => s.StudentId == studentId && s.SubjectId == subjectId);
            return mark.ToList();
        }

        /// <summary>
        /// Returns the average of notes of a student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public IEnumerable<Mark> GetAllMarksAverage(int studentId)
        {
            if (!context.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"The Id {studentId}, does not match any student on the Database");
            }

            var subjectAverages = context.Marks   // calculando el average 
                .Where(m => m.StudentId == studentId)
                .GroupBy(m => m.SubjectId)
                .Select(group => new
                {
                    SubjectId = group.Key,
                    AverageMark = group.Average(m => m.Grade)
                }).ToList();

            foreach (var subjectAverage in subjectAverages)  // actualiza average 
            {
                var marksForSubject = context.Marks
                    .Where(m => m.StudentId == studentId && m.SubjectId == subjectAverage.SubjectId);

                foreach (var mark in marksForSubject)
                {
                    mark.Average = subjectAverage.AverageMark;
                }
            }
            context.SaveChanges();

            var updatedMarks = context.Marks.Where(m => m.StudentId == studentId).ToList();
            return updatedMarks;
        }

        /// <summary>
        /// Returns a list of students based on their averages.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>If true = Groups in ascending order ~ If false = Groups in descending order </returns>
        public IEnumerable<StudentAverageDto> GetStudentsWithAverageGrade(bool order)
        {
            var studentsWithAverages = context.Students
                .Select(student => new StudentAverageDto
                {
                    StudentId = student.Id,
                    Name = student.Name,
                    AverageGrade = student.Marks.Any() ? student.Marks.Average(m => m.Grade) : 0
                });

            if (order == false)
            {
                return studentsWithAverages.OrderBy(s => s.AverageGrade).ToList();
            }
            else
            {
                return studentsWithAverages.OrderByDescending(s => s.AverageGrade).ToList();
            }
        }
    }
}

