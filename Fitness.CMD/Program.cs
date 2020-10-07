
using System;
using Fitness.BL.Controller;

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
            if (userController.IsNewUser)
            {
                Console.WriteLine("Your Gender ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDate();
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");

                userController.SetNewUserData(gender, birthDate, height, weight);
            }

            Console.WriteLine(userController.CurrentUser);


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
                Console.WriteLine($"Your {name} ");
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
