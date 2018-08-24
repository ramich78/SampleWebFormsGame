using System;
using System.Collections.Generic;

namespace SampleWebFormsGame.Models
{
    public class GameState
    {
        public Queue<Question> RemainingQuestions { get; set; }
        public Question CurrentQuestion { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool? AnswerGiven { get; set; }
        public State State { get; set; }
    }

    public enum State { StillInTheGame, Won, Lost }
}