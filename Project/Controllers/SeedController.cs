using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly DataAccessLayerService dal;
        public SeedController(DataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Initializes the Database
        /// </summary>
        [HttpPost()]
        public void Seed() =>
            dal.Seed();

    }
}
