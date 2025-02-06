using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("SignUp")]
    public class SignUpController : Controller
    {
        [HttpGet("statuses")]
        public IActionResult GetStatuses()
        {
            var statuses = UsersService.GetStatuses(Backend.Program.Globals.db.Connection);
            return Ok(statuses);
        }

        [HttpGet("fields")]
        public IActionResult GetFields()
        {
            var fields = UsersService.GetFieldsOfStudy(Backend.Program.Globals.db.Connection);
            return Ok(fields);
        }

        [HttpGet("specializations")]
        public IActionResult GetSpecializations()
        {
            var specializations = UsersService.GetSpecializations(Backend.Program.Globals.db.Connection);
            return Ok(specializations);
        }

        [HttpGet("universities")]
        public IActionResult GetUniversities()
        {
            var universities = UsersService.GetUniversities(Backend.Program.Globals.db.Connection);
            return Ok(universities);
        }

        [HttpGet("degrees")]
        public IActionResult GetDegrees()
        {
            var degrees = UsersService.GetDegrees(Backend.Program.Globals.db.Connection);
            return Ok(degrees);
        }
    }
}
