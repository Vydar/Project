using Data.Exceptions;
using Data.Models;
using Project.Dtos.Marks;

namespace Data.DAL
{
    internal partial class DataAccessLayerService : IDataAccessLayerService
    {
       
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


        public IEnumerable<Mark> GetAllMarks(int studentId)
        {
            var marks = context.Marks.Where(m => m.StudentId == studentId).ToList();
            return marks;
        }


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


        public IEnumerable<Mark> GetAllMarksAverage(int studentId)
        {
            if (!context.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"The Id {studentId}, does not match any student on the Database");
            }

            var subjectAverages = context.Marks   // chequear si calcula el promedio
                .Where(m => m.StudentId == studentId)
                .GroupBy(m => m.SubjectId)
                .Select(group => new
                {
                    SubjectId = group.Key,
                    AverageMark = group.Average(m => m.Grade)
                }).ToList();

            foreach (var subjectAverage in subjectAverages)  // chequear si actualiza promedio 
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

