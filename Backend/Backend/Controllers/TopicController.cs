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
        [HttpGet("home")]
        public IActionResult LoadAllTopics(int? page, int? amount)
        {
            if (page < 1 || amount < 1) return BadRequest("Page number or amount of pages cannot be null. Please provide valid information.");

            IEnumerable<TopicModelID> topicModelIDs = (page.HasValue && amount.HasValue)
                ? TopicsService.SelectPage(page.Value, amount.Value, Program.Globals.db.Connection)
                : TopicsService.SelectAll(Backend.Program.Globals.db.Connection);

            return Ok(topicModelIDs);
        }
    }
}
