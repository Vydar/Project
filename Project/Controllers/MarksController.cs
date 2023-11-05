using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Data;
using Project.Utils;
using Data.Models;
using Project.Dtos.Subjects;
using Project.Dtos.Students;

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

        ////   V2!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ////[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarkToGetDto))]
        ////[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        ////[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        //[HttpGet("{studentId}")]
        //public ActionResult<IEnumerable<SubjectAverageDto>> GetAllMarksAverage(int studentId)
        //{
        //    var averages = dal.GetAllMarksAverage(studentId);
        //    try
        //    {
        //        dal.GetAllMarksAverage(studentId);
        //        return Ok(averages);
        //    }
        //    catch (InvalidIdException exception)
        //    {
        //        return BadRequest(exception.Message);
        //    }
        //}

        ///// <summary>
        ///// Returns a list of student ordered by Grade
        ///// </summary>
        ///// <returns></returns>

        //[HttpGet("OrderedByMarks")]
        //public IEnumerable<MarkToGetDto> GetAllStudentsByOrder()
        //{
        //    var student = new Student();
        //    Mark mark;
        //    return dal.GetAllStudentsByOrder().Select(s=> StudentUtils.ToDto2(s,student)).ToList();     //works but doesnt return the name and doesnt sum all the 
        //}

        // GET: api/Students/WithAverages?order=ascending
        [HttpGet("WithAverages")]
        public ActionResult<IEnumerable<StudentAverageDto>> GetStudentsWithAverages([FromQuery] string order = "descending")
        {
            try
            {
                var studentsOrderedByAverages = dal.GetStudentsWithAverageGrade(order);

                return Ok(studentsOrderedByAverages);
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }

}
