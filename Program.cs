using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            while (true)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");
                string choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    recipe.EnterDetails();
                    break;
                case "2":
                    recipe.Display();
                    break;
                case "3":
                    recipe.Scale();
                    break;
                case "4":
                    recipe.Reset();
                    break;
                case "5":
                    recipe.ClearData();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;


            }
        }
    }
}

