
using System;
using System.Globalization;
using System.Resources;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main()
        {
            var culture = Culture("ru_Ru");
            var resourceManager = ResourceManager();

            Console.WriteLine($@"	{resourceManager.GetString("Hello", culture)}");

            Console.Write($@"{resourceManager.GetString("EnterYourName", culture)}: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write($@"{resourceManager.GetString("EnterYourGender", culture)}: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDate();
                var weight = ParseDouble(resourceManager.GetString("EnterYourWeight", culture));
                var height = ParseDouble(resourceManager.GetString("EnterYourHeight", culture));

                userController.SetNewUserData(gender, birthDate, height, weight);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();

            Console.WriteLine(@"What do you want to do?");
            Console.WriteLine(@"'E' - eating");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                Console.WriteLine();
                var foods = StartEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($@"	{item.Key} - {item.Value}");
                }
            }


        }

        private static (Food Food, double Weight) StartEating()
        {
            Console.Write($@"{ResourceManager().GetString("EnterProductName")}: ");
            var foodName = Console.ReadLine();
            var weight = ParseDouble(" Product weight");
            var calories = ParseDouble(" Calories");
            var proteins = ParseDouble(" Proteins");
            var fats = ParseDouble(" Fats");
            var carbohydrates = ParseDouble(" Carbohydrates");
            var food = new Food(foodName, calories, proteins, fats, carbohydrates);

            return (Food: food, Weight: weight);
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
                Console.WriteLine($@" {name} ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(ResourceManager().GetString("WrongFormat"));
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

                Console.WriteLine(ResourceManager().GetString("EnterYourBirthDate") + @" {dd.MM.yyyy}");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(ResourceManager().GetString("WrongFormat"));
                }
            }
        }

        public static CultureInfo Culture(string culture) => CultureInfo.CreateSpecificCulture(culture);

        public static ResourceManager ResourceManager() => new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
    }
}
