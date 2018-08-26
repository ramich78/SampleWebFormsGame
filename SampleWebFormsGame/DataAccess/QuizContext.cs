using System.Data.Entity;
using SampleWebFormsGame.Models;

namespace SampleWebFormsGame.DataAccess
{
    public class QuizContext :DbContext
    {
        public QuizContext() : base("name=QuizDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QuizContext, Migrations.Configuration>());
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<GameResult> GemeResults { get; set; }


    }
}