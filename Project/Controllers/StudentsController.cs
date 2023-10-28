using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Dtos;
using Project.Utils;
using Data.Models;

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
        public IEnumerable<StudentToGetDto> GetAllStudents()
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
        public StudentToGetDto GetStudentById(int id) =>
            DataAccessLayerSingleton.Instance.GetStudentById(id).ToDto(); //DTO as Extension Method

        /// <summary>
        /// Creates a new Student
        /// </summary>
        /// <param name="studenToCreate">student to create data</param>
        /// <returns>creates student data</returns>
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studenToCreate) =>
            DataAccessLayerSingleton.Instance.CreateStudent(studenToCreate.ToEntity()).ToDto();

        [HttpDelete]
        public void DeleteStudent(int id) =>
            DataAccessLayerSingleton.Instance.DeleteStudent(id);

        /// <summary>
        /// Updates an existent Student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns>New values of a Student</returns>
        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            DataAccessLayerSingleton.Instance.UpdateStudent(studentToUpdate.ToEntity()).ToDto();

        /// <summary>
        /// Updates an existent Address
        /// </summary>
        /// <param name="addressToUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        public AddressToGetDto UpdateAddress([FromBody] AddressToUpdateDto addressToUpdate) =>
            DataAccessLayerSingleton.Instance.UpdateAddress(addressToUpdate.ToEntity()).ToDto();


    }
}
