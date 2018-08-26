using System;
using System.Collections.Generic;
using System.Linq;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic
{
    public class GameService : IGameService
    {
        //todo: Number of questions in a game could be taken from config file using e.g. config service
        private const int NumberOfQuestionsInAGame = 5;
        private readonly IQuestionsService _questionsService;

        public GameService(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        public GameState GetInitialGameState()
        {
            // ReSharper disable once RedundantArgumentDefaultValue
            var questionSet = new Queue<Question>(_questionsService.GetSetOfQuestions(NumberOfQuestionsInAGame));

            return new GameState
            {
                RemainingQuestions = questionSet,
                CurrentQuestion = questionSet.Dequeue(),
                State = State.StillInTheGame,
                AnswerGiven = null,
                StartTime = DateTime.Now
            };
        }

        public void AdvanceToNextQuestion(ref GameState currentGameState)
        {
            if (!currentGameState.RemainingQuestions.Any())
            {
                throw new InvalidOperationException("There is no more questions on the list!");
            }

            currentGameState.CurrentQuestion = currentGameState.RemainingQuestions.Dequeue();
            currentGameState.AnswerGiven = null;
        }

        public void ValidateAnswer(ref GameState currentGameState)
        {
            if (currentGameState.AnswerGiven == null)
            {
                throw new InvalidOperationException("Can't validate answer if it's not yet given!");
            }

            bool answerIsCorrect = currentGameState.AnswerGiven.Equals(currentGameState.CurrentQuestion.CorrectAnswer);

            if (!answerIsCorrect)
            {
                currentGameState.State = State.Lost;
                return;
            }

            if (!currentGameState.RemainingQuestions.Any())
            {
                currentGameState.State = State.Won;
                currentGameState.EndTime = DateTime.Now;
            }
        }

    }

}
