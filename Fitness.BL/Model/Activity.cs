﻿using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        public virtual ICollection<Exercise>Exercises { get; set; }

        public Activity() {}
        public Activity(string name, double caloriesPerMinute)
        {
            // check

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString() => Name;
    }
}
