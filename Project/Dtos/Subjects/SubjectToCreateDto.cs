using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Dtos.Subjects
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectToCreateDto 
    {
       
        public string Name { get; set; }

    }
}
