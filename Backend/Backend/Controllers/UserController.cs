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
        public IActionResult UsernameLogin(string username, string password)
        {

            UserModelID userModelID = UsersService.SignIn(null, username, password, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return NotFound();
            }

            return Ok(userModelID);
        }

        [HttpPost("login/email")]
        public IActionResult EmailLogin(string email, string password)
        {
            UserModelID userModelID = UsersService.SignIn(email, null, password, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return NotFound();
            }

            return Ok(userModelID);
        }

        [HttpPost("register/first")]
        public IActionResult RegisterFirst(string username, string email, string password)
        {

            if (UsersService.Exists("email", email, Backend.Program.Globals.db.Connection))
            {
                return Conflict();
            }

            return Ok();
        }

        [HttpPost("register/second")]
        public IActionResult RegisterSecond([FromBody] UserModelID userModelID)
        {
            if (userModelID == null)
            {
                return BadRequest("Invalid data.");
            }

            userModelID = UsersService.SignUp(userModelID, Backend.Program.Globals.db.Connection);

            if (userModelID == null)
            {
                return BadRequest("Couldn't insert to DB. Check if request is valid.");
            }

            return Ok();
        }

        [HttpPost("edit/userinfo")]
        public IActionResult EditUserInfo([FromBody] UserModelID ChangedUserModelID)
        {
            if (ChangedUserModelID == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!UsersService.ChangeInfo(ChangedUserModelID, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update info in DB. Check if user exist or request is valid.");
            }

            return Ok();
        }

        [HttpPost("edit/userphoto")]
        public IActionResult EditUserPhoto(uint userID, string photo)
        {
            if (userID == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!UsersService.ChangePhoto(userID, photo, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update photo in DB. Check if user exist or request is valid.");
            }

            return Ok();
        }

        [HttpPost("edit/userpassword")]
        public IActionResult EditUserPassword(uint userID, string password)
        {
            if (userID == null)
            {
                return BadRequest("Invalid data");
            }

            if (!UsersService.ChangePassword(userID, password, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update password in DB. Check if user exist or request is valid.");
            }

            return Ok();
        }

    }
}
