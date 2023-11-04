using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var marks = context.Marks
                              .Where(m => m.StudentId == studentId)
                              .ToList();

            return marks;
        }

       
    }
}
