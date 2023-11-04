using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using Data;
using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Students;
using Project.Utils;
using System.ComponentModel.DataAnnotations;
using Data.Models;

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
        /// 
       
        [HttpGet("ByStudent/{studentId}")]
        public IEnumerable<Mark> GetAllMarks([FromRoute] int studentId) =>
          dal.GetAllMarks(studentId).ToList();


       
      

        //[HttpGet("ByStudent/{studentId}")]
        //public List<Mark> GetMarksByStudent(int studentId)
        //{
        //    var allMarks = dal.GetAllMarks(studentId);
        //    return allMarks.Select(m=>MarksUtils.ToDto(m)).ToList();
        //}

        //public IEnumerable<StudentToGetDto> GetAllStudents()
        //{
        //    var allStudents = dal.GetAllStudents();
        //    return allStudents.Select(s => StudentUtils.ToDto(s)).ToList();     

        //public IEnumerable<StudentToGetDto> GetAllStudents()
        //{
        //    var allStudents = dal.GetAllStudents();
        //    return allStudents.Select(s => StudentUtils.ToDto(s)).ToList();

    }
}
