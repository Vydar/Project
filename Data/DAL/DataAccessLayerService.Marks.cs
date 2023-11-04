using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService
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

        //public IEnumerable<Student> GetAllStudents()
        //{
        //    using var context = new StudentsDbContext();
        //    return context.Students.ToList();
        //}
        //public IEnumerable<Mark> GetAllMarks(int studentId)
        //{
        //    using var context = new StudentsDbContext();
        //   //ar student = context.Students.Any(s => s.Id == studentId);

        //   var marks = context.Marks.All(s => s.Id == studentId);
        //    return marks.ToString();
        //}
    }
}
