using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using static Backend.Program;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Topics")]
    public class TopicController : Controller
    {
        //pagination will be implemented in the future
        [HttpGet("home")]
        public IActionResult LoadAllTopics(int? page, int? amount)
        {
            IEnumerable<TopicModelID> topicModelIDs = (page.HasValue && amount.HasValue)
                ? TopicsService.SelectPage(page.Value, amount.Value, Program.Globals.db.Connection)
                : TopicsService.SelectAll(Backend.Program.Globals.db.Connection);

            return Ok(topicModelIDs);
        }

        [HttpGet("createTopic")]
        public IActionResult CreateTopic([FromBody] TopicModelID topicModelID)
        {
            if (topicModelID == null)
            {
                return BadRequest("Invalid data.");
            }

            var isCorrect = TopicsService.Insert(topicModelID, Globals.db.Connection);

            if (isCorrect == null)
                return StatusCode(500, "A database error occurred while creating the topic.");
            else
                return Ok();
        }

        [HttpGet("getReplies")]
        public IActionResult GetReplies()
        {

            return Ok();
        }

        [HttpGet("createReply")]
        public IActionResult createReply()
        {
            
            return Ok();
        }



    }
}
