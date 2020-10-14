
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
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write($@"{resourceManager.GetString("EnterYourGender", culture)}: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDate("birth date {dd.mm.yyyy}");
                var weight = ParseDouble(resourceManager.GetString("EnterYourWeight", culture));
                var height = ParseDouble(resourceManager.GetString("EnterYourHeight", culture));

                userController.SetNewUserData(gender, birthDate, height, weight);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine(@"What do you want to do?");
                Console.WriteLine(@"'E' - eating");
                Console.WriteLine(@"'A' - enter exercise");
                Console.WriteLine(@"'Q' - exit");

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        Console.WriteLine();
                        var foods = StartEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($@"	{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine();
                        var exercise = StartExercise();
                        exerciseController.Add(exercise.activity,exercise.begin,exercise.end);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($@"	{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.WriteLine();
            }


        }

        private static (DateTime begin, DateTime end, Activity activity) StartExercise()
        {
            Console.WriteLine(@"Enter Exercise Name");
            var name = Console.ReadLine();
            var energy = ParseDouble("Energy Consumption per Minute");
            var begin = ParseDate("Start Exercise");
            var end = ParseDate("Finish Exercise");
            var activity = new Activity(name, energy);
            return (begin, end, activity);

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
        public static DateTime ParseDate(string value)
        {
            while (true)
            {

                Console.WriteLine($@"Enter {value}");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
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
