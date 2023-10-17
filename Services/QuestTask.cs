using Newtonsoft.Json;

namespace AncientRelicQuest.Services
{
    public class Riddle
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    public class QuestTask
    {
        private List<Riddle> riddles;

        public QuestTask()
        {
            var json = File.ReadAllText("JsonData/ChatMessages.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            riddles = JsonConvert.DeserializeObject<List<Riddle>>(data.riddles.ToString());
        }

        public Riddle GetRandomRiddle()
        {
            return riddles[new Random().Next(0, riddles.Count)];
        }

        public bool EvaluateAnswer(int riddleId, string userAnswer)
        {
            var riddle = riddles.FirstOrDefault(r => r.Id == riddleId);
            if (riddle != null)
            {
                return string.Equals(riddle.Answer, userAnswer, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

    }
}