using Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
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
        /// Initializes the Database with Students data
        /// </summary>
        [HttpPost()]
        public void Seed() =>
          dal.Seed();
    }
}
