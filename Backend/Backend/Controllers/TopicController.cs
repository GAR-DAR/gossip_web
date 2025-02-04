using Backend.Models.ModelsID;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Topics")]
    public class TopicController : Controller
    {
        //pagination will be implemented in the future
        [HttpPost("home")]
        public IActionResult LoadAllTopics()
        {
            IEnumerable<TopicModelID> topicModelIDs = TopicsService.SelectAll(Backend.Program.Globals.db.Connection);
          
            return Ok(topicModelIDs);
        }


    }
}
