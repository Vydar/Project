using Data.Models;
using Project.Dtos;

namespace Project.Utils
{
    public static class StudentUtils
    {
        public static StudentsToGetDto ToDto(this Student student)
        {
            if (student == null)
            {
                return null;
            }
            return new StudentsToGetDto { Id = student.Id, Name = student.Name, LastName = student.LastName, Age = student.Age };
        }

        public static Student ToEntity(this StudentToCreateDto student) // Funcion que trasnforma Dto en entidad
        {
            if (student == null) 
            {
                return null;
            }
            return new Student
            {
                Name = student.Name,
                LastName = student.LastName,
                Age = student.Age,
            };
        }
    }
}
