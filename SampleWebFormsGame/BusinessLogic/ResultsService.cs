using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.DataAccess.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic
{
    class ResultsService : IResultsService
    {
        private readonly IQuizRepository _quizRepository;

        public ResultsService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public void StoreResult(GameState currentGameState, string userName)
        {
            if (currentGameState.State != State.Won)
            {
                throw new InvalidOperationException("Can't store the result if the game was not won!");
            }

            GameResult gameResult = new GameResult
            {
                PlayerName = userName,
                DateOfGameCompletion = currentGameState.EndTime,
                TimeToComplete = currentGameState.EndTime - currentGameState.StartTime
            };

            _quizRepository.InsertResult(gameResult);
        }

        public IEnumerable<GameResult> GetResults()
        {
            return _quizRepository.GetAllResults().ToList();
        }
    }
}