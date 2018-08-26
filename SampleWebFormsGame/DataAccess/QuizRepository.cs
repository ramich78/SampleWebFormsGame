using System.Linq;
using SampleWebFormsGame.DataAccess.Interfaces;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.DataAccess
{
    //In case more models are stored in a database seperate repository for each models should be created. 
    //Each repository could inherit from generic repository, which implements generic insert, update, delete, get methods.
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizContext _db = new QuizContext();

        public IQueryable<Question> GetAllQuestions()
        {
            return _db.Questions.AsQueryable();
        }

    }
}