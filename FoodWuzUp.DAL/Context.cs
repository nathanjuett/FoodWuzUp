using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class Context : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }

        
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RecordType> RecordTypes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<RatingsList> RatingsLists { get; set; }

        public Context()
        {
            Database.SetInitializer<Context>(new ContextInitializer());


            this.Configuration.LazyLoadingEnabled = false;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }
}
