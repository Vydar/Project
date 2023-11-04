using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {

        private readonly IDataAccessLayerService dal;
        public MarksController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Adds a new Note to a Subject
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>

        [HttpPost]
        public void AddMark([FromBody] MarkToCreateDto mark) =>
        dal.AddMark(mark.Grade, mark.StudentId, mark.SubjectId);

        /// <summary>
        /// Gets all notes from a student
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>

        [HttpGet("{studentId}")]
        public void GetAllMarks([FromRoute] int studentId) =>
           dal.GetAllMarks(studentId).ToList();

    }
}
