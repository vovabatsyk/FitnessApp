
using System;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to Fitness Application");

            Console.WriteLine("Your Name ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Your Gender ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDate();
                var weight = ParseDouble("Your Weight");
                var height = ParseDouble("Your Height");

                userController.SetNewUserData(gender, birthDate, height, weight);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("'E' - eating");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                Console.WriteLine();
               var foods = StartEating();
               foreach (var item in eatingController.Eating.Foods)
               {
                   Console.WriteLine($"\t{item.Key} - {item.Value}");
               }
            }


        }

        private static (Food Food,  double Weight) StartEating()
        {
            Console.Write("Enter product name  ");
            var foodName = Console.ReadLine();
            var weight = ParseDouble(" Product weight");
            var calories = ParseDouble(" Calories");
            var proteins = ParseDouble(" Proteins");
            var fats = ParseDouble(" Fats");
            var carbohydrates = ParseDouble(" Carbohydrates");
            var food = new Food(foodName, calories, proteins, fats, carbohydrates);

            return (Food:food,Weight: weight);
        }

        /// <summary>
        /// Parse Double
        /// </summary>
        /// <param name="name">Weight, Height</param>
        /// <returns></returns>
        public static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($" {name.ToUpper()} ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} Format");
                }
            }
        }
        /// <summary>
        /// Parse BirthDay
        /// </summary>
        /// <returns></returns>
        public static DateTime ParseDate()
        {
            while (true)
            {
                Console.WriteLine("Your BirthDate {dd.MM.yyyy} ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Wrong Data Format");
                }
            }
        }
    }
}
