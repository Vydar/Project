﻿using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Students;
using Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    /// <summary>
    /// Controller that handles requests/responses for Students
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {

        private readonly IDataAccessLayerService dal;
        public StudentsController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Returns all students from the database.
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAllStudents()
        {
            var allStudents = dal.GetAllStudents();
            return allStudents.Select(s => StudentUtils.ToDto(s)).ToList();
        }

        /// <summary>
        /// Returns a Student based on the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/ id / {id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<StudentToGetDto> GetStudentById([Range(1, int.MaxValue)] int id) =>
             dal.GetStudentById(id).ToDto(); //DTO as Extension Method - allow a method to be added to an object, including a class or a type, after it has been compiled.




        /// <summary>
        /// Creates a new Student
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>creates student data</returns>
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(StudentToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Removes a Student from the Database
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("{id}")]
        public void DeleteStudent([Range(1, int.MaxValue)] int id)
        {
            dal.DeleteStudent(id);
        }


        /// <summary>
        /// Updates an existent Student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns>New values of a Student</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate)
                 => dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();


        /// <summary>
        /// Updates or creates an Address
        /// </summary>
        /// <param name="addressToUpdate"></param>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("{id}")]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {

            if (dal.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity()))
            {
                return Created("success", null);
            }
            return Ok();
        }



    }
}
