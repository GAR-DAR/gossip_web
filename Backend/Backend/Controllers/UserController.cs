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

        [HttpPost("register/first")]
        public IActionResult RegisterFirst(String username, String email, String password)
        {

            if (UsersService.Exists("email", email, Backend.Program.Globals.db.Connection))
            {
                return Conflict();
            }

            return Ok();
        }

        [HttpPost("register/second")]
        public IActionResult RegisterSecond([FromBody] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest("Invalid data.");
            }

            UserModelID userModelID = new(userModel);
            userModelID = UsersService.SignUp(userModelID, Backend.Program.Globals.db.Connection);
            
            if(userModelID == null)
            {
                return BadRequest("Couldn't insert to DB. Check if request is valid.");
            }

            return Ok(userModelID);
        }

        [HttpPost("edit/userinfo")]
        public IActionResult EditUserInfo([FromBody] UserModel ChangedUserModel)
        {
            if(ChangedUserModel == null)
            {
                return BadRequest("Invalid data.");
            }

            UserModelID ChangedUserModelID = new(ChangedUserModel);

            if (!UsersService.ChangeInfo(ChangedUserModelID, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update info in DB. Check if user exist or request is valid.");
            }

            return Ok(ChangedUserModel);
        }

        [HttpPost("edit/userphoto")]
        public IActionResult EditUserPhoto([FromBody] UserModel ChangedUserModel)
        {
            if (ChangedUserModel == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!UsersService.ChangePhoto(ChangedUserModel.ID, ChangedUserModel.Photo, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update photo in DB. Check if user exist or request is valid.");
            }

            return Ok(ChangedUserModel);
        }

        [HttpPost("edit/userpassword")]
        public IActionResult EditUserPassword([FromBody] UserModel ChangedUserModel)
        {
            if (ChangedUserModel == null)
            {
                return BadRequest("Invalid data");
            }

            if (!UsersService.ChangePassword(ChangedUserModel.ID, ChangedUserModel.Password, Backend.Program.Globals.db.Connection))
            {
                return BadRequest("Couldn't update password in DB. Check if user exist or request is valid.");
            }

            return Ok(ChangedUserModel);
        }
        
    }
}
