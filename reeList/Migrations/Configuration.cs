namespace reeList.Migrations
{
    using reeList.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<reeList.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(reeList.Models.MovieDBContext context)
        {
            context.movie.AddOrUpdate(i => i.Title,
                new Movie
                {
                    Title = "The Godfather",
                    Year = "1972",
                    Rated = "R",
                    Image = "www.who.com"
                },

                 new Movie
                 {
                     Title = "Ghostbusters ",
                     Year = "1999",
                     Rated = "R",
                     Image = "www.what.com"
                 }
           );

        }
    }
}
