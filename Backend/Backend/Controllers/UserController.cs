using Backend.Models.ModelsFull;
using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {

        [HttpPost("login/username")]
        public IActionResult UsernameLogin(String username, String password)
        {
           
            UserModelID userModelID = UsersService.SignIn(null, username, password, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return NotFound();
            }

            return Ok(userModelID);
        }

        [HttpPost("login/email")]
        public IActionResult EmailLogin(String email, String password)
        {
            UserModelID userModelID = UsersService.SignIn(email, null, password, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return NotFound();
            }

            return Ok(userModelID);
        }
    }
}
