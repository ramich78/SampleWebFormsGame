using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using SampleWebFormsGame.BusinessLogic;
using SampleWebFormsGame.DataAccess.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.Tests.BusinessLogic
{

    //todo: More tests needed

    [TestFixture]
    public class QuestionServiceTests
    {
        private IQuizRepository _quizRepository;
        private QuestionsService _service;
        private List<Question> _allDatabaseQuestions;

        [SetUp]
        public void SetUp()
        {
            _quizRepository = NSubstitute.Substitute.For<IQuizRepository>();
            _service = new QuestionsService(_quizRepository);
            _allDatabaseQuestions = new List<Question>()
            {
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
                new Question(),
            };
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(10)]
        public void GetSetOfQuestions_ReturnsExpectedNumberOfQuestion_WhenProvidedNumberGreaterThanZero(int numberOfQuestionsToReturn)
        {
            //Arrange
            _quizRepository.GetAllQuestions().Returns(_allDatabaseQuestions.AsQueryable());
            
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

