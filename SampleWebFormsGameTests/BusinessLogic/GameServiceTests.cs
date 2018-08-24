using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using SampleWebFormsGame.BusinessLogic;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.Tests.BusinessLogic
{
    [TestFixture]
    class GameServiceTests
    {
        private IQuestionsService _questionsService;
        private GameService _service;

        //todo: More tests should be written

        [SetUp]
        public void SetUp()
        {
            _questionsService = Substitute.For<IQuestionsService>();
            _service = new GameService(_questionsService);
        }

        //todo: Seems like tests are not obvious, should I refactor GameService class?
        [Test]
        public void ValidateAnswer_SetsGameStateToLost_WhenProvidedWithWrongAnswer()
        {
            //Arrange
            GameState providedGameState = new GameState
            {
                RemainingQuestions = new Queue<Question>(),
                CurrentQuestion = new Question { CorrectAnswer = true },
                AnswerGiven = false
            };

            GameState expectedGameState =
                JsonConvert.DeserializeObject<GameState>(JsonConvert.SerializeObject(providedGameState));

            expectedGameState.State = State.Lost;

            //Act
            _service.ValidateAnswer(ref providedGameState);

            //Assert
            Assert.That(providedGameState.State,Is.EqualTo(expectedGameState.State));
        }

        [Test]
        public void ValidateAnswer_SetsGameStateToGameWon_WhenProvidedWithCorrectAnswerToLastQuestion()
        {
            //Arrange
            GameState providedGameState = new GameState
            {
                RemainingQuestions = new Queue<Question>(),
                CurrentQuestion = new Question { CorrectAnswer = true },
                AnswerGiven = true
            };

            GameState expectedGameState =
                JsonConvert.DeserializeObject<GameState>(JsonConvert.SerializeObject(providedGameState));

            expectedGameState.State = State.Won;

            //Act
            _service.ValidateAnswer(ref providedGameState);

            //Assert
            Assert.That(providedGameState.State,Is.EqualTo(expectedGameState.State));
        }

        [Test]
        public void ValidateAnswer_SetStateToStillInTheGame_WhenProvidedWithCorrectAnswerToNotLastQuestion()
        {
            //Arrange
            GameState providedGameState = new GameState
            {
                RemainingQuestions = new Queue<Question>(new List<Question>{new Question()}),
                CurrentQuestion = new Question { CorrectAnswer = true },
                AnswerGiven = true
            };

            GameState expectedGameState =
                JsonConvert.DeserializeObject<GameState>(JsonConvert.SerializeObject(providedGameState));

            expectedGameState.State = State.StillInTheGame;

            //Act
            _service.ValidateAnswer(ref providedGameState);

            //Assert
            Assert.That(JsonConvert.SerializeObject(providedGameState),Is.EqualTo(JsonConvert.SerializeObject(expectedGameState)));
        }

        [Test]
        public void ValidateAnswer_ThrowsInvalidOperationException_WhenQuestionIsNotGiven()
        {
            //Arrange
            GameState state = new GameState
            {
                AnswerGiven = null
            };

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => _service.ValidateAnswer(ref state));

        }


    }
}
