using Data.Models;
using Microsoft.EntityFrameworkCore.Query;
using Project.Dtos.Marks;
using Project.Dtos.Students;
using Project.Dtos.Subjects;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Project.Utils
{
    public static class StudentUtils //Must be static
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

        public static Address ToEntity(this AddressToUpdateDto addressToUpdate)
        {
            if (addressToUpdate == null)
            {
                return null;
            }
            return new Address
            {
                City = addressToUpdate.City,
                Street = addressToUpdate.Street,
                Number = addressToUpdate.Number,
            };
        }









        public static MarkToGetDto ToDto2(this Mark mark, Student student)
        {
            if (mark == null)
            {
                return null;
            }

            return new MarkToGetDto { StudentName = student.Name, Average = mark.Average };
        }
        //public static Mark ToEntity2(this MarkToGetDto mark)
        //{
        //    if (mark == null)
        //    {
        //        return null;
        //    }            

        //    return new Mark
        //    {
        //        Average = mark.Average,
        //        //StudentName = mark.StudentName       
        //    };
        //}

     
       


    }

}

