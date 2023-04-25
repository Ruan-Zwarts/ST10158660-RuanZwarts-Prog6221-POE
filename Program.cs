using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    public class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            List <Ingredient> Recipe1 = new List <Ingredient>();

            while (true)
            {
                Console.WriteLine("Enter the number of ingredients:");
                int numIngredients = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine("Enter the name of ingredient {0}:", i + 1);
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the quantity of ingredient {0}:", i + 1);
                    double quantity = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter the unit of measurement of ingredient {0}:", i + 1);
                    string unit = Console.ReadLine();


                    //Program Ingredient = new Program; 

                    recipe.AddIngredients (new Recipe.Ingredient (name, quantity, unit));
                }
                
                Console.WriteLine("Enter the number of steps:");
                int numSteps = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine("Enter step {0}:", i + 1);
                    string step = Console.ReadLine();
                    recipe.AddStep(step);
                }
                
                recipe.DisplayRecipe();

                while (true)
                {
                    Console.WriteLine("Enter 's' to scale the recipe, 'r' to reset quantities, 'c' to clear recipe, or any other key to exit:");
                    string input = Console.ReadLine();

                    if (input == "s")
                    {
                        Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
                        double factor = Convert.ToDouble(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        recipe.DisplayRecipe();
                    }
                    else if (input == "r")
                    {
                        recipe.ResetQuantities();
                        recipe.DisplayRecipe();
                    }
                    else if (input == "c")
                    {
                        recipe.ClearRecipe();
                        break;
                    }
                    else
                    {

                    }



                }
            }
            
        }
        
    }
}
