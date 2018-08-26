using System;
using System.ComponentModel.DataAnnotations;

namespace SampleWebFormsGame.Models
{
    public class GameResult
    {
        [Key]
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public TimeSpan TimeToComplete { get; set; }
        public DateTime DateOfGameCompletion { get; set; }
    }
}