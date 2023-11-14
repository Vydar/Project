using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    /// <summary>
    /// Implementation of the Data Access Layer. 
    /// </summary>
    /// <remarks>
    /// Contains methods for accessing the database data
    /// </remarks>
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly StudentsDbContext context;
        public DataAccessLayerService(StudentsDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all student data from the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }

        /// <summary>
        /// Gets all student data based on an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public Student GetStudentById(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"The Id {id}, does not match any student on the Database");
            }
            return student;
        }

        /// <summary>
        /// Creates a new student 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateObjectException"></exception>
        public Student CreateStudent(Student student)
        {
            if (context.Students.Any(s => s.Id == student.Id))
            {
                throw new DuplicateObjectException($"The student {student.Name} {student.LastName} already exists on the Database");
            }
            context.Add(student);
            context.SaveChanges();
            return student;
        }

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidIdException"></exception>
        public void DeleteStudent(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"The Id {id}, does not match any student on the Database");
            }
            context.Students.Remove(student);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates the student data based on Id
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                throw new InvalidIdException($"The Id {studentToUpdate.Id}, does not match any student on the Database");
            }
            student.Address = studentToUpdate.Address;
            student.Name = studentToUpdate.Name;
            student.LastName = studentToUpdate.LastName;
            student.Age = studentToUpdate.Age;

            context.SaveChanges();
            return student;
        }

        /// <summary>
        /// Creates a new address for a student. If the student already has an address on the database then updates it. 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public bool UpdateOrCreateStudentAddress(int studentId, Address newAddress)
        {
            var student = context.Students
                .Include(s => s.Address)
                .FirstOrDefault(s => s.Id == studentId);

            if (studentId == null)
            {
                throw new InvalidIdException($"The Id {studentId}, does not match any student on the Database");
            }
            var isCreated = false;
            if (student.Address == null)
            {
                student.Address = newAddress;
                isCreated = true;
            }

            student.Address.City = newAddress.City;
            student.Address.Street = newAddress.Street;
            student.Address.Number = newAddress.Number;
            context.SaveChanges();
            return isCreated;
        }


    }
}
