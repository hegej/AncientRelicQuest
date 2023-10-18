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

        [HttpGet(nameof(GetRiddle))]
        public IActionResult GetRiddle()
        {
            try
            {
                var riddle = _questTask.GetNextRiddle();
                if (riddle == null)
                {
                    return NotFound("No more riddles available.");
                }

                return Ok(riddle);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while retrieving the riddle: " + ex.Message);
            }
        }

        [HttpPost(nameof(EvaluateAnswer))]
        public IActionResult EvaluateAnswer(int riddleId, string answer)
        {
            try
            {
                bool isCorrect = _questTask.EvaluateAnswer(riddleId, answer);
                return Ok(isCorrect);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while evaluating the answer: " + ex.Message);
            }
        }
    }
}