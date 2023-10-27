using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos;
using Project.Utils;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// Initializes the Database
        /// </summary>
        [HttpPost("seed")]
        public void Seed() =>
            DataAccessLayerSingleton.Instance.Seed();

        /// <summary>
        /// Returns all Students from the Database
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentsToGetDto> GetAllStudents()
        {
            var allStudents = DataAccessLayerSingleton.Instance.GetAllStudents();
            return allStudents.Select(s => StudentUtils.ToDto(s)).ToList();

        }

        /// <summary>
        /// Returns a Student based on the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/ id / {id}")]
        public StudentsToGetDto GetStudentById(int id) =>
            DataAccessLayerSingleton.Instance.GetStudentById(id).ToDto(); //DTO as Extension Method

        /// <summary>
        /// Creates a new Student
        /// </summary>
        /// <param name="studenToCreate">student to create data</param>
        /// <returns>creates student data</returns>
        [HttpPost]
        public StudentsToGetDto CreateStudent([FromBody] StudentToCreateDto studenToCreate) =>
            DataAccessLayerSingleton.Instance.CreateStudent(studenToCreate.ToEntity()).ToDto();

    }
}
