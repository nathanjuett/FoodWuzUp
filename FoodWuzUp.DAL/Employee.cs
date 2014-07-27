﻿using FoodWuzUp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class Employee : Base<Employee>, IBaseWithComments<Employee, EmployeeComment>
    {
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<EmployeeComment> Comments { get; set; }
        public Employee()
        {
            Comments = new List<EmployeeComment>();
        }
    }
}