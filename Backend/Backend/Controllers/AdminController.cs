using Backend.Models.ModelsID;
using Backend.Models.ModelsFull;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Admin")]
    public class AdminController : Controller
    {
        [HttpGet("banned/list")]
        public IActionResult GetList()
        {
            List<UserModelID> bannedUsers = UsersService.SelectBannedUsers(Backend.Program.Globals.db.Connection);
            return Ok(bannedUsers);
        }

        [HttpPost("ban")]
        public IActionResult BanUser(uint userID)
        {
            if (userID == 0) return BadRequest("Message cannot be empty. Please provide a valid message.");

            if (!UsersService.Ban(userID, Backend.Program.Globals.db.Connection))
            {
                return StatusCode(500, "We encountered an issue while baning user. Please try again later.");
            }
            return Ok();
        }

        [HttpPost("unban")]
        public IActionResult UnbanUser(uint userID)
        {
            if (userID == 0) return BadRequest("Message cannot be empty. Please provide a valid message.");

            if (!UsersService.Unban(userID, Backend.Program.Globals.db.Connection))
            {
                return StatusCode(500, "We encountered an issue while baning user. Please try again later.");
            }
            return Ok();
        }
    }
}
