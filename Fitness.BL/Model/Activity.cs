using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        
        public string Name { get;  }

        public double CaloriesPerMinute { get;  }

        public Activity(string name, double caloriesPerMinute)
        {
            // check

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString() => Name;
    }
}
