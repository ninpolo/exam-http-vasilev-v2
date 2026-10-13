using System.Data.Entity;

namespace ExamMvc.Models
{
    public class ExamContext : DbContext
    {
        // "name=ExamContext" refers to the connection string in Web.config.
        public ExamContext() : base("name=ExamContext")
        {
            // CreateExamDb.sql creates the table; Entity Framework must not
            // create or modify the database.
            Database.SetInitializer<ExamContext>(null);
        }

        public DbSet<Album> Albums { get; set; }
    }
}
