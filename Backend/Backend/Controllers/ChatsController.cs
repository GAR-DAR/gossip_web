using Backend.Models.ModelsID;
using Backend.Models.ModelsFull;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Backend.Program;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Chats")]
    public class ChatsController : Controller
    {
        [HttpGet("all")]
        public IActionResult GetUserChats([FromBody] UserModelID userModelID)
        {
            IEnumerable<ChatModelID> chats = ChatsService.SelectChatsByUser(userModelID.ID, Globals.db.Connection);
            if (chats == null)
            {
                return StatusCode(500, "A database error occurred while fetching the chats.");
            }
            else
            {
                return Ok(chats);
            }
        }
    }
}
