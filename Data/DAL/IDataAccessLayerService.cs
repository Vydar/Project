using Data.Models;
using Project.Dtos.Marks;


namespace Data.DAL
{
    public interface IDataAccessLayerService
    {
        #region Student Interfaces
        Student CreateStudent(Student student);
        void DeleteStudent(int id);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void Seed();
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);
        Student UpdateStudent(Student studentToUpdate);
        Subject CreateSubject(string subjectName);
        #endregion

        #region Subject Interfaces
        void AddMark(int grade, int studentId, int subjectId);
        IEnumerable<Mark> GetAllMarks(int studentId);
        IEnumerable<Mark> GetMarkBySubject(int studentId, int subjectId);
        public IEnumerable<Mark> GetAllMarksAverage(int studentId);
        IEnumerable<StudentAverageDto> GetStudentsWithAverageGrade(bool order);
        #endregion

        #region Teacher Interfaces
        void DeleteSubject(int id);
        //Teacher CreateTeacher(Teacher teacher);
        bool CreateTeacher(int subjectId, Teacher newTeacher);
        void DeleteTeacher(int id);
        #endregion
    }

}