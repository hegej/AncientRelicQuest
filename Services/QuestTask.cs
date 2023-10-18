using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
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

        private int currentRiddleIndex = 0;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public QuestTask(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            InitializeRiddles();
        }

        private void InitializeRiddles()
        {
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, "JsonData", "ChatMessages.json");
            var json = File.ReadAllText(path);
            riddles = JsonConvert.DeserializeObject<List<Riddle>>(json);
        }

        public Riddle GetNextRiddle()
        {
            if (currentRiddleIndex < riddles.Count)
            {
                return riddles[currentRiddleIndex++];
            }
            else
            {
                currentRiddleIndex = 1;
                return riddles[currentRiddleIndex++];
            }
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