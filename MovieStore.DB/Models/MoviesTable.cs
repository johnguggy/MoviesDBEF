using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Web.Models
{
    public class MoviesTable
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual int YearRelasesed { get; set; }

        public virtual int Price { get; set; }

        public virtual int GenreId { get; set; }

        public virtual GenreTable GenreTable { get; set; }
    }
}