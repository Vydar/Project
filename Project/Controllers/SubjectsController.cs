using Data;
using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Project.Dtos.Subjects;
using Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    /// <summary>
    /// Controller that handles requests/responses for student's subjects
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class SubjectsController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public SubjectsController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Creates a new Subject
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost("New")]
        public void CreateSubject([FromBody] string subjectName) =>
            dal.CreateSubject(subjectName);


        /// <summary>
        /// Removes a subject from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("/Delete/{id}")]
        public IActionResult DeleteSubject([Range(1, int.MaxValue)] int id)
        {
            dal.DeleteSubject(id);
            return Ok();
        }
    }
}

