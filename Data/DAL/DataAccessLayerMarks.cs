using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    // public partial class DataAccessLayerService
    public class DataAccessLayerMarks
    {
        private readonly StudentsDbContext context;
        public DataAccessLayerMarks(StudentsDbContext context)
        {
            this.context = context;
        }
        public void AddMark(int grade, int studentId, int subjectId)
        {
           // using var context = new StudentsDbContext(connectionString);
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

        //public IEnumerable<Student> GetAllStudents()
        //{
        //    using var context = new StudentsDbContext();
        //    return context.Students.ToList();
        //}

        public IEnumerable<Mark> GetAllMarks(int studentId)
        {
           // using var context = new StudentsDbContext(connectionString);
            var marks = context.Marks.Where(s => s.Id == studentId);
            return marks;
        }
    }
}
