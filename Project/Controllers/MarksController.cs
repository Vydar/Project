using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Data.Models;

namespace Project.Controllers
{
    /// <summary>
    /// Controller that handles requests/responses for student notes
    /// </summary>
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
        /// Assigns a note to a student
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>

        [HttpPost]
        public void AddMark([FromBody] MarkToCreateDto mark) =>
        dal.AddMark(mark.Grade, mark.StudentId, mark.SubjectId);

        /// <summary>
        /// Gets all notes of a student
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>
        /// 

        [HttpGet("ByStudent/{studentId}")]
        public IEnumerable<Mark> GetAllMarks([FromRoute] int studentId) =>
          dal.GetAllMarks(studentId).ToList();


        /// <summary>
        /// Gets notes of a student for a specific course
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<Mark> GetMarkbySubject(int studentId, int subjectId) =>
            dal.GetMarkBySubject(studentId, subjectId);


        /// <summary>
        /// Returns the average for each Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}")]
        public IEnumerable<Mark> GetAllMarksAverage(int studentId) =>
            dal.GetAllMarksAverage(studentId);

        /// <summary>
        /// Returns the students ordered by the averages of their grades (False = Ascending / True = Descending)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentAverageDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [HttpGet("WithAverages")]
        public ActionResult<IEnumerable<StudentAverageDto>> GetStudentsWithAverages([FromQuery] bool order)
        {
            try
            {
                var studentsOrderedByAverages = dal.GetStudentsWithAverageGrade(order);
                return Ok(studentsOrderedByAverages);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No data found on the database");
            }
        }

    }

}
