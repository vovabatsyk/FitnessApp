﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class EatingController : BaseController
    {

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

        private Eating GetEating() => Load<Eating>().FirstOrDefault() ?? new Eating(_user);

        /// <summary>
        /// Get Foods
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods() => Load<Food>() ?? new List<Food>();

        /// <summary>
        /// Save Foods
        /// </summary>
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
    }
}
