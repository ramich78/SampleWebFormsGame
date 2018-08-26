using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        /// <summary>
        /// Changes current question to next from the list and sets state of the game accordingly.
        /// <param name="currentGameState">Current state of the game.</param>
        /// </summary>
        /// <returns></returns>
        void AdvanceToNextQuestion(ref GameState currentGameState);

        /// <summary>
        /// Gets initial state of the game.
        /// </summary>
        /// <returns>State of newly started game.</returns>
        GameState GetInitialGameState();

        /// <summary>
        /// Checks if the answer given to the question is correct and sets state of the game accordingly.
        /// </summary>
        /// <param name="currentGameState">Current state of the game.</param>
        /// <returns></returns>
        void ValidateAnswer(ref GameState currentGameState);
    }
}