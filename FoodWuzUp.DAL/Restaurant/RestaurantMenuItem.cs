﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class RestaurantMenuItem : BaseXref<RestaurantMenuItem, Restaurant, MenuItem>
    {
        public int? RatingID { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
