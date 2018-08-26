using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleWebFormsGame.DataAccess.QuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SampleWebFormsGame.DataAccess.QuizContext context)
        {
            context.Questions.AddOrUpdate(
                new Question
                {
                    Id = 1,
                    QuestionSentence = "Is Warsaw capital of Poland?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 2,
                    QuestionSentence = "Is Amsterdam capital of Holland?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 3,
                    QuestionSentence = "Is Paris capital of France?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 4,
                    QuestionSentence = "Is Moscow capital of Russia?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 5,
                    QuestionSentence = "Is Berlin capital of Germany?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 6,
                    QuestionSentence = "Is London capital of England?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 7,
                    QuestionSentence = "Is Lisbon capital of Portugal?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 8,
                    QuestionSentence = "Is Rome capital of Italy?",
                    CorrectAnswer = true
                },
                new Question
                {
                    Id = 9,
                    QuestionSentence = "Is Prague capital of Slovakia?",
                    CorrectAnswer = false
                },
                new Question
                {
                    Id = 10,
                    QuestionSentence = "Is Oslo capital of Sweden?",
                    CorrectAnswer = false
                },
                new Question
                {
                    Id = 11,
                    QuestionSentence = "Is Stockholm capital of Denmark?",
                    CorrectAnswer = false
                },
                new Question
                {
                    Id = 12,
                    QuestionSentence = "Is Sevilla capital of Spain?",
                    CorrectAnswer = false
                },
                new Question
                {
                    Id = 13,
                    QuestionSentence = "Is Sofia capital of Romania?",
                    CorrectAnswer = false
                },
                new Question
                {
                    Id = 14,
                    QuestionSentence = "Is Budapest capital of Greece?",
                    CorrectAnswer = false
                },
                new Question
                {
                    Id = 15,
                    QuestionSentence = "Is Malme capital of Norway?",
                    CorrectAnswer = false
                });

            context.SaveChanges();

        }
    }
}
