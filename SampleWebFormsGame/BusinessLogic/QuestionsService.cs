using System;
using System.Collections.Generic;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic
{
    public class QuestionsService : IQuestionsService
    {
        
        public IEnumerable<Question> GetSetOfQuestions(int numberOfQuestionsToReturn = 5)
        {
            if (numberOfQuestionsToReturn<1) throw new ArgumentOutOfRangeException
                (nameof(numberOfQuestionsToReturn),numberOfQuestionsToReturn,$"Number of questions to return cannot be lesser than 1 but was {numberOfQuestionsToReturn}!");

            return new List<Question>()
            {
                new Question(){Id = 1, QuestionSentence = "1 True", CorrectAnswer = true},
                new Question(){Id = 2, QuestionSentence = "2 False", CorrectAnswer = false},
                new Question(){Id = 3, QuestionSentence = "3 True", CorrectAnswer = true},
                new Question(){Id = 4, QuestionSentence = "4 True", CorrectAnswer = true},
                new Question(){Id = 5, QuestionSentence = "5 False", CorrectAnswer = false}
            };
        }
    }
}