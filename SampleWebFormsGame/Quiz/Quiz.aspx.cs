using System;
using SampleWebFormsGame.BusinessLogic;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.Quiz
{
    public partial class Quiz : System.Web.UI.Page
    {
        private readonly IGameService _gameService;
        private GameState _currentGameState;

        protected Quiz()
        {
            IQuestionsService questionsService = new QuestionsService();
            _gameService = new GameService(questionsService);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _currentGameState = _gameService.GetInitialGameState();
                Session["GameState"] = _currentGameState;
            }
            else
            {
                _currentGameState = (GameState) Session["GameState"];
            }

            RefreshControls();
        }

        protected void ButtonLeaveGame_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ButtonNo_OnClick(object sender, EventArgs e)
        {
            CheckTheAnswerAndMoveOn(false);
        }

        protected void ButtonYes_OnClick(object sender, EventArgs e)
        {
            CheckTheAnswerAndMoveOn(true);
        }

        private void CheckTheAnswerAndMoveOn(bool answerGiven)
        {
            _currentGameState.AnswerGiven = answerGiven;
            _gameService.ValidateAnswer(ref _currentGameState);

            switch (_currentGameState.State)
            {
                case State.StillInTheGame:
                    _gameService.AdvanceToNextQuestion(ref _currentGameState);
                    break;
                case State.Won:
                    Response.Redirect("/Quiz/Winner.aspx");
                    break;
                case State.Lost:
                    Response.Redirect("/Quiz/Looser.aspx");
                    break;
            }

            RefreshControls();
        }

        private void RefreshControls()
        {
            TextBoxQuestionSentence.Text = _currentGameState.CurrentQuestion.QuestionSentence;
        }
    }
}