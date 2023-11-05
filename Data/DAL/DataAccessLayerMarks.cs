using Data.Models;


namespace Data.DAL
{
    // public partial class DataAccessLayerService
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public void AddMark(int grade, int studentId, int subjectId)
        {
            if (!context.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException("Invalid Student Id");
            }
            if (!context.Subjects.Any(s => s.Id == subjectId))
            {
                throw new InvalidIdException("Invalid Subject Id");
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
                throw new InvalidIdException("Invalid Student Id");
            }
            if (!context.Subjects.Any(s => s.Id == subjectId))
            {
                throw new InvalidIdException("Invalid Subject Id");
            }

            var mark = context.Marks.Where(s => s.StudentId == studentId && s.SubjectId == subjectId);
            return mark.ToList();
        }

        public IEnumerable<Mark> GetAllMarksAverage(int studentId)
        {
            // Calculate the average marks per subject for the student.
            var subjectAverages = context.Marks
                .Where(m => m.StudentId == studentId)
                .GroupBy(m => m.SubjectId)
                .Select(group => new
                {
                    SubjectId = group.Key,
                    AverageMark = group.Average(m => m.Grade)
                }).ToList();

            // Update the average mark for each subject in the Mark model.
            foreach (var subjectAverage in subjectAverages)
            {
                // Find all marks for the current subject and student.
                var marksForSubject = context.Marks
                    .Where(m => m.StudentId == studentId && m.SubjectId == subjectAverage.SubjectId);

                foreach (var mark in marksForSubject)
                {
                    // Update the Average property for each mark.
                    mark.Average = subjectAverage.AverageMark;
                }
            }
            context.SaveChanges();

            var updatedMarks = context.Marks.Where(m => m.StudentId == studentId).ToList();
            return updatedMarks;
        }


        //public IEnumerable<Mark> GetAllStudentsByOrder()
        //{
        //    return context.Marks.Include(s=>s.Student.Name).OrderByDescending(s=>s.Average).ToList();
        //}
        //

        public IEnumerable<StudentAverageDto> GetStudentsWithAverageGrade(string order = "descending")
        {
            var studentsWithAverages = context.Students
                .Select(student => new StudentAverageDto
                {
                    StudentId = student.Id,
                    Name = student.Name,
                    AverageGrade = student.Marks.Any() ? student.Marks.Average(m => m.Grade) : 0
                });

            if (order.ToLower() == "ascending")
            {
                return studentsWithAverages.OrderBy(s => s.AverageGrade).ToList();
            }
            else // Default to descending
            {
                return studentsWithAverages.OrderByDescending(s => s.AverageGrade).ToList();
            }
        }
    }
}
