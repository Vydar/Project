using Data;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Students;
using Project.Dtos.Teachers;
using Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
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
    }
}

