using System;
using System.Collections.Generic;
using System.Linq;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.DataAccess.Interfaces;
using SampleWebFormsGame.Extensions;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuizRepository _quizRepository;

        public QuestionsService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public IEnumerable<Question> GetSetOfQuestions(int numberOfQuestionsToReturn = 5)
        {
            if (numberOfQuestionsToReturn<1) throw new ArgumentOutOfRangeException
                (nameof(numberOfQuestionsToReturn),numberOfQuestionsToReturn,$@"Number of questions to return cannot be lesser than 1 but was {numberOfQuestionsToReturn}!");

            return _quizRepository.GetAllQuestions().ToList().Shuffle().Take(numberOfQuestionsToReturn);
            
        }
    }
}