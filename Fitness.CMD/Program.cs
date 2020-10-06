
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

            Console.WriteLine("Your Gender ");
            var gender = Console.ReadLine();


            Console.WriteLine("Your BirthDate ");
            var birthDate = DateTime.Parse(Console.ReadLine());


            Console.WriteLine("Your Weight ");
            var weight = double.Parse(Console.ReadLine());


            Console.WriteLine("Your Height ");
            var height = double.Parse(Console.ReadLine());


            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();


        }
    }
}
