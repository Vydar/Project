﻿using Data;
using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Project.Dtos.Subjects;
using Project.Utils;

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
        [HttpPost()]
        public void CreateSubject([FromBody] string subjectName) =>
            dal.CreateSubject(subjectName); //toDTO missing


        /// <summary>
        /// Removes a subject from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("{id}")] 
        public IActionResult DeleteSubject(int id)
        {
            if (id == 0)
            {
                return BadRequest("ID can not be 0");
            }
            try
            {
                dal.DeleteSubject(id);
            }
            catch (InvalidIdException exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok();
        }
    }
}

