using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public enum Rank
        {
            Professor,
            AssociateProfessor,
            AssistantProfessor,
            Instructor,
        }  

        public bool CreateTeacher(int subjectId, Teacher newTeacher)
        {
            var subject = context.Subjects.Include(s => s.Teacher).FirstOrDefault(s => s.Id == subjectId);
            if (subjectId == null)
            {
                throw new InvalidIdException("The Subject Id does not exist on the Database");
            }

            var isCreated = false;
            if (subject.Teacher == null)
            {
                subject.Teacher = newTeacher;
                isCreated = true;
            }

            subject.Teacher.Name= newTeacher.Name;
            subject.Teacher.Address = newTeacher.Address;
            subject.Teacher.Rank = newTeacher.Rank;
            context.SaveChanges();
            return isCreated;
        }

        public void DeleteTeacher(int id)
        {
            var teacher = context.Teachers.FirstOrDefault(s => s.Id == id);

            if (teacher == null)
            {
                throw new InvalidIdException("The Id does not match any student on the Database");
            }
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }
    }
}
