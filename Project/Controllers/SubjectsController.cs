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
        private readonly IDataAccessLayerService dal;
        public SubjectsController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Initializes the Database
        /// </summary>
        [HttpPost()]
        public void CreateSubject([FromBody] string subjectName) =>
            dal.CreateSubject(subjectName); //toDTO missing

    }
}

