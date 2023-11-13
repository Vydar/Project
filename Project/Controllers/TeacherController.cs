using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Teachers;
using Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    /// <summary>
    /// Controller that handles requests/responses for teachers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public TeacherController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Creates a new teacher
        /// </summary>
        /// <param name="teacherToCreate"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPut("{subjectId}")]
        public IActionResult CreateTeacher([FromRoute] int subjectId, [FromBody] TeacherToCreateDto teacherToCreate)
        {
            if (dal.CreateTeacher(subjectId, teacherToCreate.ToEntity()))
            {
                return Created("success", null);
            }
            return Ok();
        }

        /// <summary>
        /// Removes a teacher from the Database
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher([Range(1, int.MaxValue)] int id)
        {
            try
            {
                dal.DeleteTeacher(id);
            }
            catch (InvalidIdException exception)
            {
                return BadRequest("The id does not exist on the Database");
            }
            return Ok();
        }

        /// <summary>
        /// Updates the Address of a teacher
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newAddress"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id}")]
        public IActionResult UpdateTeacherAddress(int id, string newAddress)
        {
            try
            {
                dal.UpdateTeacherAddress(id, newAddress);
            }
            catch (InvalidIdException exception)
            {
                return BadRequest("The Teacher Id does not exist on the Database");
            }
            return Ok();
        }

        //TODO - assing subject to teacher

        /// <summary>
        /// Promotes a teacher to the next Rank
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Teacher))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("/ id / {id}")]
        public IActionResult PromoteTeacher([Range(1, int.MaxValue)] int id)
        {
            try
            {
                dal.PromoteTeacher(id);
            }
            catch (InvalidIdException exception)
            {
                return BadRequest("The Teacher Id does not exist on the Database");
            }
            return Ok();
        }






        /// <summary>
        /// Returns a all the Notes given by a teacher with their respective 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotesFromTeacherToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        
        public IEnumerable<NotesFromTeacherToGetDto> GetNotesFromTeacher(int id)
        {
            //try
            //{
          
            var allNotes = dal.GetNotesFromTeacher(id);
            return allNotes.Select(s => MarkUtils.ToDto(s)).ToList();
                
                
                
             //   return Ok();
           // }
          //  catch (InvalidIdException exception)
          //  {
          //      return BadRequest(exception.Message);
           // }
        }

    }
}


