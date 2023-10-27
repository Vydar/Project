using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
