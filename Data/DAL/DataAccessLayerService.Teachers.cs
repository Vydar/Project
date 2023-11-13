using Data;
using Data.Exceptions;
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
                throw new InvalidIdException($"The Id {subjectId} does not match any subject on the Database");
            }

            var isCreated = false;
            if (subject.Teacher == null)
            {
                subject.Teacher = newTeacher;
                isCreated = true;
            }

            subject.Teacher.Name = newTeacher.Name;
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
                throw new InvalidIdException($"The Id {id} does not match any teacher on the Database");
            }
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }

        public Teacher UpdateTeacherAddress(int id, string newAddress)
        {
            var teacher = context.Teachers.FirstOrDefault(s => s.Id == id);
            if (teacher == null)
            {
                throw new InvalidIdException($"The Id {id} does not match any teacher on the Database");
            }
            teacher.Address = newAddress;
            context.SaveChanges();
            return teacher;
        }

        public Teacher PromoteTeacher(int id)
        {
            var teacher = context.Teachers.FirstOrDefault(s => s.Id == id);

            if (teacher == null)
            {
                throw new InvalidIdException($"The Id {id} does not match any teacher on the Database");
            }

            switch (teacher.Rank)
            {
                case Rank.Professor:
                    teacher.Rank = Rank.AssociateProfessor;
                    break;
                case Rank.AssociateProfessor:
                    teacher.Rank = Rank.AssistantProfessor;
                    break;
                case Rank.AssistantProfessor:
                    teacher.Rank = Rank.Instructor;
                    break;
            }

            context.SaveChanges();
            return teacher;
        }


        public IEnumerable<Mark> GetNotesFromTeacher(int id)
        {

            if (!context.Subjects.Any(s => s.Id == id && s.Teacher.Id == id)) // revisar
            {
                throw new InvalidIdException($"The Id {id} does not match any teacher on the Database");
            }

            var mark = context.Marks.Where(s => s.SubjectId == id);
            return mark.ToList();



        }

    }
}
