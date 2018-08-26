using System;
using SampleWebFormsGame.BusinessLogic;
using SampleWebFormsGame.BusinessLogic.Interfaces;
using SampleWebFormsGame.DataAccess;
using SampleWebFormsGame.DataAccess.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.Quiz
{
    public partial class Quiz : System.Web.UI.Page
    {
        private readonly IGameService _gameService;
        private GameState _currentGameState;
        private TimeSpan _elapsedTime;

        protected Quiz()
        {
            IQuizRepository quizRepository = new QuizRepository();
            IQuestionsService questionsService = new QuestionsService(quizRepository);
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

            CalculateGameTime();
            RefreshAllControls();
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

            RefreshAllControls();
        }

        protected void TimerGameClock_OnTick(object sender, EventArgs e)
        {
            CalculateGameTime();
            RefreshUpdatePanelControls();
        }

        private void CalculateGameTime()
        {
            _elapsedTime = DateTime.Now - _currentGameState.StartTime;
        }

        private void RefreshAllControls()
        {
            LabelQuestionSentence.Text = _currentGameState.CurrentQuestion.QuestionSentence;
            RefreshUpdatePanelControls();
        }

        private void RefreshUpdatePanelControls()
        {
            LabelGameClock.Text = _elapsedTime.ToString(@"mm\:ss");
        }
    }
}