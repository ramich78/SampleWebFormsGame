using System.Collections.Generic;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic.Interfaces
{
    interface IResultsService
    {
        /// <summary>
        /// Stores result in persistent storage. 
        /// </summary>
        /// <param name="currentGameState"></param>
        /// <param name="userName"></param>
        void StoreResult(GameState currentGameState, string userName);
        
        /// <summary>
        /// Gets results from persistent storage.
        /// </summary>
        /// <returns>A list of game results.</returns>
        IEnumerable<GameResult> GetResults();
    }
}
