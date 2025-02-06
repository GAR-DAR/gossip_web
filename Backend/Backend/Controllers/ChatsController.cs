using Backend.Models.ModelsID;
using Backend.Models.ModelsFull;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
