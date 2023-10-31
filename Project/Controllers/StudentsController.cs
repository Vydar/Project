using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos;
using Project.Utils;
using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// Initializes the Database
        /// </summary>
        [HttpPost("seed")]
        public void Seed() =>
            DataAccessLayerSingleton.Instance.Seed();

        /// <summary>
        /// Returns all Students from the Database
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAllStudents()
        {
            var allStudents = DataAccessLayerSingleton.Instance.GetAllStudents();
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
        public ActionResult<StudentToGetDto> GetStudentById([Range(1, int.MaxValue)] int id)
        {
            try
            {
                return DataAccessLayerSingleton.Instance.GetStudentById(id).ToDto(); //DTO as Extension Method
            }
            catch (InvalidIdException exception)
            {
                return BadRequest(exception.Message);
            }
        }


        /// <summary>
        /// Creates a new Student
        /// </summary>
        /// <param name="studenToCreate">student to create data</param>
        /// <returns>creates student data</returns>
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studenToCreate) =>
            DataAccessLayerSingleton.Instance.CreateStudent(studenToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Removes a Student from the Database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent([Range(1, int.MaxValue)] int id)
        {
            //if (id == 0)
            //{
            //    return BadRequest("ID can not be 0");
            //}
            try
            {
                DataAccessLayerSingleton.Instance.DeleteStudent(id);
            }
            catch (InvalidIdException exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok();
        }


        /// <summary>
        /// Updates an existent Student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns>New values of a Student</returns>
        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            DataAccessLayerSingleton.Instance.UpdateStudent(studentToUpdate.ToEntity()).ToDto();

        /// <summary>
        /// Updates an existent Address
        /// </summary>
        /// <param name="addressToUpdate"></param>
        /// <returns></returns>
        /// 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        [HttpPut("{id}")]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {

            if (DataAccessLayerSingleton.Instance.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity())
            {
                return Created("success", null);
            }
            return Ok();
        }

    }
}
