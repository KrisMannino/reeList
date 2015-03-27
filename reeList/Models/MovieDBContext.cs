using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace reeList.Models
{
    public class MovieDBContext: DbContext
    {
        public MovieDBContext()
        {
            Database.SetInitializer<MovieDBContext>(null);
        }
        public DbSet<Movie> movie { get; set; }
    }
}