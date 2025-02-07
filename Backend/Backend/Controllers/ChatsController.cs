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
        [HttpPost("create")]
        public IActionResult ChatCreate(ChatModelID chat) 
        {
            if(chat == null) return BadRequest("Chat details cannot be null. Please provide valid chat information.");

            ChatModelID dbChat = ChatsService.Create(chat, Backend.Program.Globals.db.Connection);

            if(dbChat == null)
            {
                return StatusCode(500, "We encountered an issue while creting your chat. Please try again later.");
            }
            return Ok(dbChat);
        }

        [HttpGet("all")]
        public IActionResult GetUserChats(uint userID)
        {
            if(userID == 0) return BadRequest("User ID cannot be null. Please provide valid user ID.");

            IEnumerable<ChatModelID> chats = ChatsService.SelectChatsByUser(userID, Globals.db.Connection);
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
