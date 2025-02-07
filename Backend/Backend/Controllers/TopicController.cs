using Backend.Models.ModelsID;
using Backend.Models.ModelsFull;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpPost("createTopic")]
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
        public IActionResult GetReplies(uint topicID)
        {
            IEnumerable<ParentReplyModelID> replies = TopicsService.SelectParentRepliesByTopic(topicID, Globals.db.Connection);

            if (replies == null)
            {
                return StatusCode(500, "A database error occurred while fetching the replies.");
            }
            else
            {
                //client can add it to its local model and we will load other replies when user clicks on the reply to reply (for each of them separately)
                return Ok(replies);
            }
        }

        [HttpGet("getReplyToReply")]
        public IActionResult GetReplyToReply(uint parentReplyID)
        {
            
            IEnumerable<ChildReplyModelID> replies = RepliesService.SelectChildRepliesByParent(parentReplyID, Globals.db.Connection);

            if (replies == null)
            {
                return StatusCode(500, "A database error occurred while fetching the replies.");
            }
            else
            {
                //client can add it to its local model and we will load other replies when user clicks on the reply to reply (for each of them separately)
                return Ok(replies);
            }
        }

       

        [HttpPost("createReply")]
        public IActionResult createReply([FromBody] ParentReplyModelID reply)
        {
            if (RepliesService.AddParent(reply, Globals.db.Connection) != null)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "A database error occurred while creating the reply.");
            }
        }

        [HttpPost("createReplyToReply")]
        public IActionResult createReplyToReply([FromBody] ChildReplyModelID reply)
        {
            if(RepliesService.AddChild(reply, Globals.db.Connection) != null)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "A database error occurred while creating the reply.");
            }
        }





    }
}
