using Data;
using Data.Data_Access_Layers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos.Marks;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        /// <summary>
        /// Adds a new Note to a Subject
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>
        
        [HttpPost]
        public void AddMark([FromBody] MarkToCreateDto mark) =>
           DataAccessLayerMarks.Instance.AddMark(mark.Grade, mark.StudentId, mark.SubjectId);

        /// <summary>
        /// Gets all notes from a student
        /// </summary>
        /// <param name="markToCreate"></param>
        /// <returns></returns>

        [HttpGet("{studentId}")]
        public void GetAllMarks( [FromRoute] int studentId) => 
           DataAccessLayerMarks.Instance.GetAllMarks(studentId);

    }
}
