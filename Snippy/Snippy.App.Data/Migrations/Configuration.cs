using System.Collections.Generic;

namespace Snippy.App.Data.Migrations
{
    using Model;
    using System.Data.Entity.Migrations;


    public sealed class Configuration : DbMigrationsConfiguration<Snippy.App.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Snippy.App.Data.ApplicationDbContext";
        }

        protected override void Seed(Snippy.App.Data.ApplicationDbContext context)
        {
            
            var languages = new List<Language>()
            {
                new Language() { Name = "C#"},
                new Language() { Name = "JavaScript"},
                new Language() { Name = "Python"},
                new Language() { Name = "CSS"},
                new Language() { Name = "SQL"},
                new Language() { Name = "PHP"},
            };

            foreach (var language in languages)
            {
                context.Languages.AddOrUpdate(language);
            }

            context.SaveChanges();
        }
    }
}
