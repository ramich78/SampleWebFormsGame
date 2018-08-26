using System.Linq;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.DataAccess.Interfaces
{
    public interface IQuizRepository
    {
        IQueryable<Question> GetAllQuestions();
    }
}