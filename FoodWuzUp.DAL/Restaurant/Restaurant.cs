﻿using FoodWuzUp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWuzUp.DAL
{
    public class Restaurant : Base<Restaurant>, IBaseWithComments<Restaurant, RestaurantComment>
    {

        public int GroupID { get; set; }
        public Guid UniqueID { get; set; }
        public virtual Group Group { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public string Address { get; set; }
        [ForeignKey("Restautrant")]
        public int? RestaurantTypeID { get; set; }
        public RestaurantType RestaurantType { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<RestaurantComment> Comments { get; set; }
        public virtual ICollection<RestaurantEmployee> Employees { get; set; }
        public Restaurant()
        {
            Comments = new List<RestaurantComment>();
            Employees = new List<RestaurantEmployee>();
            MenuItems = new List<MenuItem>();
            UniqueID = Guid.NewGuid();
        }
    }
}