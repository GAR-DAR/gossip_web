using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Messages")]
    public class MessagesController : Controller
    {
        /*[HttpPost("send")] //gets MessageModelID from client, writes to db and sends it back with correct message ID given by db.
        //Shold delete and use ChatHub?
        public IActionResult Send([FromBody] MessageModelID message)
        {
            if(message == null) return BadRequest("Message cannot be empty. Please provide a valid message.");

            MessageModelID dbMessage = MessagesService.Add(message, Backend.Program.Globals.db.Connection);

            if (dbMessage == null)
            {
                return StatusCode(500, "We encountered an issue while sending your message. Please try again later.");
            }
            return Ok(dbMessage);
        }*/

        /*        [HttpGet("all")] //gets all messages of client from db and sends them as List<MessageModelID> back.
                //Maybe we need signal(db service) to get latest message from every client's chat from db to display them for each chat window.
                //And signal(db service) to get all messages of chat by chat's ID. How to send user ID or selected chat ID, is it get or post method?
                public IActionResult GetAll(uint userID)
                {
                    if (userID == 0) return BadRequest("User ID cannot be null. Please provide valid user ID.");
                    List<MessageModelID> messages = MessagesService.SelectMessageModelsByUserId(userID, Backend.Program.Globals.db.Connection);
                    return Ok(messages);
                }*/
        
    }
}
