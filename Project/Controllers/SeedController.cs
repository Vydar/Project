using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    /// <summary>
    /// Controller that populates the database with students
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public SeedController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Initializes the database with students data
        /// </summary>
        [HttpPost()]
        public void Seed() =>
          dal.Seed();
    }
}
