using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public ProfessorController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{ProfessorId}")]
        public IActionResult Get(int ProfessorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpPut("{ProfessorId}")]
        public IActionResult put(int ProfessorId)
        {
            return Ok();
        }

        [HttpDelete("{ProfessorId}")]
        public IActionResult delete(int ProfessorId)
        {
            return Ok();
        }
    }
}