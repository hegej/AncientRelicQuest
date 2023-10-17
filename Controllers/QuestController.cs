using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AncientRelicQuest.Services;

namespace AncientRelicQuest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestController : ControllerBase
    {
        private readonly QuestTask _questTask;

        public QuestController(QuestTask questTask)
        {
            _questTask = questTask;
        }

        [HttpGet("GetRiddle")]
        public ActionResult<Riddle> GetRiddle()
        {
            return Ok(_questTask.GetRandomRiddle());
        }

        [HttpPost("EvaluateAnswer")]
        public ActionResult<bool> EvaluateAnswer(int riddleId, string answer)
        {
            return Ok(_questTask.EvaluateAnswer(riddleId, answer));
        }
    }
}

