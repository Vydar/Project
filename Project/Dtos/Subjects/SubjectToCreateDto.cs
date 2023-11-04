using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Dtos.Subjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectToCreateDto // : ControllerBase
    {
        /// <summary>
        /// Subject Name
        /// </summary>
        public string Name { get; set; }

    }
}
