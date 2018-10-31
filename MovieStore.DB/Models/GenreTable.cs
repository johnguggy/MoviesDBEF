using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Web.Models
{
    public class GenreTable
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
    }
}