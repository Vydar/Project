using Data.DAL;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Project.Dtos.Subjects;
using Project.Utils;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubjectsController : ControllerBase
    {


        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubjectToCreateDto))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        //public IActionResult CreateSubject(string subject)
        //{
        //    using var context = new StudentsDbContext();
        //    if (context.Subjects.Any(s => s.Name == subject))
        //    {
        //        return BadRequest("The Subject already exists on the Database");
        //    }
        //    var newSubject = new Subject { Name = subject };
        //    context.Subjects.Add(newSubject);
        //    context.SaveChanges();
        //    return Ok(newSubject);
        //}

        private readonly IDataAccessLayerService dal;
        public SubjectsController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Initializes the Database
        /// </summary>
        [HttpPost()]
        public void CreateSubject([FromBody]string subjectName) =>
            dal.CreateSubject(subjectName); //toDTO missing

    }
}

