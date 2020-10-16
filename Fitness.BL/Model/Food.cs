using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Food
    /// </summary>
    [Serializable]
    public class Food
    {

        #region Methods
        public int Id { get; set; }

        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
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
        public Food() { }

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
