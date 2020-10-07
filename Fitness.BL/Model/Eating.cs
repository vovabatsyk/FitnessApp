using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Eating Food 
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Mealtime
        /// </summary>
        public DateTime Mealtime { get; }

        /// <summary>
        /// Amount of Food
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Food User
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Constructor Eating (User)
        /// </summary>
        /// <param name="user"></param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Empty User");
            Mealtime = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Add Food
        /// </summary>
        /// <param name="food">Food Name</param>
        /// <param name="weight">Food weight</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
                Foods.Add(food, weight);
            else
                Foods[product] += weight;
        }
    }
}
