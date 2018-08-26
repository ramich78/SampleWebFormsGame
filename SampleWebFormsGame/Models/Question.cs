using System.ComponentModel.DataAnnotations;

namespace SampleWebFormsGame.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string QuestionSentence { get; set; }
        public bool CorrectAnswer { get; set; }
    }
}