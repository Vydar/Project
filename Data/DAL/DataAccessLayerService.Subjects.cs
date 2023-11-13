using Data.Exceptions;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{

    public partial class DataAccessLayerService : IDataAccessLayerService
    {     
        public Subject CreateSubject(string subjectName)
        {           
            var existingSubject = context.Subjects.FirstOrDefault(s => s.Name == subjectName);
            if (existingSubject != null) 
            {
                throw new DuplicateObjectException($"The subject {subjectName} already exists in the Database");
            }

            var subject = new Subject { Name = subjectName };
            context.Subjects.Add(subject);
            context.SaveChanges();
            return subject;
        }

        public void DeleteSubject(int id)
        {
            var subject = context.Subjects.FirstOrDefault(s => s.Id == id );
            var marks = context.Marks.Where(s => s.SubjectId == id );
            if (subject == null)
            {
                throw new InvalidIdException($"The Id {id} does not match any subject on the Database");
            }
          
            context.RemoveRange(marks);
            context.Subjects.Remove(subject);           
            context.SaveChanges();
        }
    }
}
