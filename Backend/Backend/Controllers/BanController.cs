using Backend.Models.ModelsID;
using Backend.Models.ModelsFull;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Ban")]//sounds weird, meybe we should do it some other way? Like from some gossip.com/user&id=1/ban or something?
    //But List of banned users maybe should be in gossip.com/ban/list or something in other hand?
    public class BanController : Controller
    {
        [HttpGet("list")]
        public IActionResult GetList()
        {
            List<UserModelID> bannedUsers = UsersService.SelectBannedUsers(Backend.Program.Globals.db.Connection);
            return Ok(bannedUsers);
        }

        [HttpPost("ban/user")]
        public IActionResult BanUser(uint userID)
        {
            if (userID == 0) return BadRequest("Message cannot be empty. Please provide a valid message.");

            if (!UsersService.Ban(userID, Backend.Program.Globals.db.Connection))
            {
                return StatusCode(500, "We encountered an issue while baning user. Please try again later.");
            }
            return Ok();
        }

        [HttpPost("unban/user")]
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
