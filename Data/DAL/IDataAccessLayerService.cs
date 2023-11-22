using Data.Models;
using Project.Dtos.Marks;


namespace Data.DAL
{
    /// <summary>
    /// Interface containing all the methods for the Data Access Layer
    /// </summary>
    public interface IDataAccessLayerService
    {

        /// <summary>
        /// Creates a new student 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateObjectException"></exception>
        Student CreateStudent(Student student);
        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidIdException"></exception>
        void DeleteStudent(int id);
        /// <summary>
        /// Gets all student data from the database.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAllStudents();
        /// <summary>
        /// Gets all student data based on an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        Student GetStudentById(int id);
        /// <summary>
        /// Populates the database with student info
        /// </summary>
        void Seed();
        /// <summary>
        /// Creates a new address for a student. If the student already has an address on the database then updates it. 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        bool UpdateOrCreateStudentAddress(int studentId, Address newAddress);

        /// <summary>
        /// Updates the student data based on Id
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        Student UpdateStudent(Student studentToUpdate);
       


        /// <summary>
        /// Adds a note to a student
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <exception cref="InvalidIdException"></exception>
        void AddMark(int grade, int studentId, int subjectId);
        /// <summary>
        /// Gets all the notes of a student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns> 
        IEnumerable<Mark> GetAllMarks(int studentId);
        /// <summary>
        /// Gets all the notes of a student on one specific subject.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        IEnumerable<Mark> GetMarkBySubject(int studentId, int subjectId);
        /// <summary>
        /// Returns the average of notes of a student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidIdException"></exception>
        public IEnumerable<Mark> GetAllMarksAverage(int studentId);
        /// <summary>
        /// Returns a list of students based on their averages.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>If true = Groups in ascending order ~ If false = Groups in descending order </returns>
        IEnumerable<StudentAverageDto> GetStudentsWithAverageGrade(bool order);


        /// <summary>
        /// Creates a Subject on the database
        /// </summary>
        /// <param name="subjectName"></param>
        /// <returns></returns>
        Subject CreateSubject(string subjectName);
        /// <summary>
        /// Removes a Subject from the database.
        /// </summary>
        /// <param name="id"></param>
        void DeleteSubject(int id);
        /// <summary>
        /// Creates a new Teacher on the database.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="newTeacher"></param>
        /// <returns></returns>
        bool CreateTeacher(int subjectId, Teacher newTeacher);
        /// <summary>
        /// Removes a Teacher from the database
        /// </summary>
        /// <param name="id"></param>
        void DeleteTeacher(int id);
        /// <summary>
        /// Updates the address of a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        Teacher UpdateTeacherAddress(int id, string newAddress);
        /// <summary>
        /// Promotes the rank of a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Teacher PromoteTeacher(int id);
        /// <summary>
        /// Get all the notes given by an specific teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Mark> GetNotesFromTeacher(int id);


    }

}