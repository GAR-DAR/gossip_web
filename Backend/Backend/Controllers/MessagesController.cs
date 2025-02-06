using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Messages")]
    public class MessagesController : Controller
    {
        [HttpPost("send")]
        public IActionResult Send([FromBody] MessageModelID message)
        {
            if(message == null) return BadRequest("Message cannot be empty. Please provide a valid message.");

            MessageModelID dbMessage = MessagesService.Add(message, Backend.Program.Globals.db.Connection);

            if (dbMessage == null)
            {
                return StatusCode(500, "We encountered an issue while sending your message. Please try again later.");
            }
            return Ok(dbMessage);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            Data
            return null;
        }


    }
}
