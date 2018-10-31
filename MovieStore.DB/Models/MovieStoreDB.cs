using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieStore.Web.Models
{
    public class MovieStoreDB : DbContext
    {
        public MovieStoreDB() : base("name=MovieStoreDB")
        {
        }

        public DbSet<MoviesTable> MoviesTable { get; set; }

        public DbSet<GenreTable> GenreTable { get; set; }
    }
}