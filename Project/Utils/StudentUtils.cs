using Data.Models;
using Project.Dtos;

namespace Project.Utils
{
    public static class StudentUtils
    {
        public static StudentToGetDto ToDto(this Student student)
        {
            if (student == null)
            {
                return null;
            }
            return new StudentToGetDto { Id = student.Id, Name = student.Name, LastName = student.LastName, Age = student.Age };
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

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Age = student.Age,
            };
        }

        public static AddressToGetDto ToDto(this Address address)
        {
            if (address == null)
            {
                return null;
            }
            return new AddressToGetDto { Id = address.Id, City = address.City, Number = address.Number, Street = address.Street };
        }
        public static Address ToEntity(this AddressToUpdateDto address)
        {
            if (address == null)
            {
               // return null;
            }
            return new Address
            {
                StudentId = address.Id,
                City = address.City,
                Street = address.Street,
                Number = address.Number,
            };
        }
    }
}
