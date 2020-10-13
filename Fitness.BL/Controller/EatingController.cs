using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class EatingController : BaseController
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eatings.dat";

        private readonly User _user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user), "User don't found");

            Foods = GetAllFoods();
            Eating = GetEating();
        }


        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }

        }

        private Eating GetEating() => Load<Eating>(EATING_FILE_NAME) ?? new Eating(_user);

        /// <summary>
        /// Get Foods
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods() => Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

        /// <summary>
        /// Save Foods
        /// </summary>
        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
