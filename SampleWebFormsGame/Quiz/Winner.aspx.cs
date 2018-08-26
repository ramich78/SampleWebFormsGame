using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Ajax.Utilities;
using SampleWebFormsGame.BusinessLogic;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.DataAccess;
using SampleWebFormsGame.DataAccess.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.Quiz
{
    public partial class Winner : System.Web.UI.Page
    {
        private readonly IResultsService _resultsService;
        private GameState _currentGameState;

        protected Winner()
        {
            IQuizRepository quizRepository = new QuizRepository();
            _resultsService = new ResultsService(quizRepository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _currentGameState = (GameState)Session["GameState"];
            _resultsService.StoreResult(_currentGameState, HttpContext.Current.User.Identity.Name);

            LabelElapsedTime.Text = (_currentGameState.EndTime - _currentGameState.StartTime).ToString(@"mm\:ss");
        }

        public IEnumerable<GameResult> Select()
        {
            return _resultsService.GetResults();
        }
    }
}