using System.Collections.Generic;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic.Interfaces
{
    public interface IQuestionsService
    {
        /// <summary>
        /// Gets set of unique questions. 
        /// </summary>
        /// <param name="numberOfQuestionsToReturn">Number of questions to be returned.</param>
        /// <returns>A list of questions.</returns>
        IEnumerable<Question> GetSetOfQuestions(int numberOfQuestionsToReturn = 5);
    }
}
