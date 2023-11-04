using Data.Models;
using Project.Dtos.Marks;
using Project.Dtos.Students;
using Project.Dtos.Subjects;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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


        public static Subject ToEntity(this SubjectToCreateDto subject)
        {
            if (subject == null)
            {
                return null;
            }
            return new Subject
            {
                Name = subject.Name
            };
        }


        //public static MarkToGetDto ToDto(this Mark mark)
        //{
        //    if (mark == null)
        //    {
        //        return null;
        //    }
        //    return new MarkToGetDto { Id = mark.Id, DateTime = mark.DateTime, Grade = mark.Grade }; // maybe add Subject or student id 
        //}

 
        }

    }

