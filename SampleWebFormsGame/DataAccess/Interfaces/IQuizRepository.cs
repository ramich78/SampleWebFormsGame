using System.Linq;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.DataAccess.Interfaces
{
    public interface IQuizRepository
    {
        /// <summary>
        /// Gets all questions from repository.
        /// </summary>
        /// <returns></returns>
        IQueryable<Question> GetAllQuestions();

        /// <summary>
        /// Gets all results from repository.
        /// </summary>
        /// <returns></returns>
        IQueryable<GameResult> GetAllResults();
        
        /// <summary>
        /// Insert result of the game to repository.
        /// </summary>
        /// <param name="gameResult"></param>
        void InsertResult(GameResult gameResult);
    }
}