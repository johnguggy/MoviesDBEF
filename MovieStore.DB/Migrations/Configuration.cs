namespace MovieStore.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MovieStore.Business;
 

    internal sealed class Configuration : DbMigrationsConfiguration<MovieStore.Web.Models.MovieStoreDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieStore.Web.Models.MovieStoreDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
