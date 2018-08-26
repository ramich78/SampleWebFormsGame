using System;
using System.Linq;
using NUnit.Framework;
using SampleWebFormsGame.BusinessLogic;
using SampleWebFormsGame.DataAccess;
using SampleWebFormsGame.DataAccess.Interfaces;

namespace SampleWebFormsGame.Tests.BusinessLogic
{

    //todo: More tests needed

    [TestFixture]
    public class QuestionServiceTests
    {
        private IQuizRepository _quizRepository;
        private QuestionsService _service;

        [SetUp]
        public void SetUp()
        {
            _quizRepository = NSubstitute.Substitute.For<IQuizRepository>();
            _service = new QuestionsService(_quizRepository);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(10)]
        public void GetSetOfQuestions_ReturnsExpectedNumberOfQuestion_WhenProvidedNumberGreaterThanZero(int numberOfQuestionsToReturn)
        {
            //Arrange
            //Act
            var result = _service.GetSetOfQuestions(numberOfQuestionsToReturn);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(numberOfQuestionsToReturn));
        }

        [TestCase(0)]
        [TestCase(-12)]
        public void GetSetOfQuestions_ThrowsArgumentOutOfRangeException_WhenProvidedNumberLesserThanOne(int numberOfQuestionsToReturn)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetSetOfQuestions(numberOfQuestionsToReturn));
        }

    }
}

