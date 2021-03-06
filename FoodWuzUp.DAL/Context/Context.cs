﻿using System;
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
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RestaurantEmployee> RestaurantEmployees { get; set; }
        public DbSet<RecordType> RecordTypes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<RatingsList> RatingsLists { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        //public DbSet<GroupRestaurant> GroupRestaurants { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<UserEmployeeRating> UserEmployeeRatings { get; set; }
        public DbSet<ApplicationAuthType> ApplicationAuthTypes { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }

        public Context()
        {
            Database.SetInitializer<Context>(new ContextInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }
        public Context(ContextInitializer init)
        {
            Database.SetInitializer<Context>(init);
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<FoodWuzUp.DAL.RestaurantMenuItem> RestaurantMenuItems { get; set; }


    }
}
