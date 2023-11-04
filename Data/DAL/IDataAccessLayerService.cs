using Data.Models;

namespace Data.DAL
{
    public interface IDataAccessLayerService
    {
        Student CreateStudent(Student student);
        void DeleteStudent(int id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void Seed();
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);
        Student UpdateStudent(Student studentToUpdate);
        Subject CreateSubject(string subjectName);
    }
}