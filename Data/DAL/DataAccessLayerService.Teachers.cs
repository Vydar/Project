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
        /// <summary>
        /// Ranks available for teachers
        /// </summary>
        public enum Rank
        {
            Professor,
            AssociateProfessor,
            AssistantProfessor,
            Instructor,
        }

        /// <summary>
        /// Creates a new teacher
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="newTeacher"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
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

        /// <summary>
        /// Deletes the instance of a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidIdException"></exception>
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

        /// <summary>
        /// Updates the Address of a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
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

        /// <summary>
        /// Promotes the Rank of a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
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

        /// <summary>
        /// Get all the notes associated to a teacher.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
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
