using System;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Food
    /// </summary>
    public class Food
    {
        #region Methods

        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calories { get; set; }
        private double CaloriesOnOneGram => Calories / 100.0;
        private double ProteinsOnOneGram => Proteins / 100.0;
        private double FatsOnOneGram => Fats / 100.0;
        private double CarbohydratesOnOneGram => Carbohydrates / 100.0;

        #endregion

        /// <summary>
        /// Create Food with Name
        /// </summary>
        /// <param name="name">Food Name</param>
        public Food(string name) : this(name, 0, 0, 0, 0) { }

        /// <summary>
        /// Create Food with Name, Proteins,Fats and Carbohydrates
        /// </summary>
        /// <param name="name">Food Name</param>
        /// <param name="proteins">Proteins</param>
        /// <param name="fats">Fats</param>
        /// <param name="carbohydrates">Carbohydrates</param>
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Empty Food Name");
            }
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString() => Name;
    }
}
