using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    class NewRecipe             //Holds all the mothods for the program to complete
    {
        private List<IngredientList> ingredients;
        private List<string> steps;

        public NewRecipe()          //Sets up the list for the data to be stored
        {
            ingredients = new List<IngredientList>();
            steps = new List<string>();
        }

        public void AddIngredient(IngredientList ingredient)    //Method for adding ingredients
        {
            ingredients.Add(ingredient);
        }

        public void AddSteps(string step)
        {
            steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (IngredientList ingredient in ingredients)
            {
                Console.WriteLine("{0} {1} {2}", ingredient.Quantity, ingredient.Unit, ingredient.Name);
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (IngredientList ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (IngredientList ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }
    }

    class IngredientList
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        private double originalQuantity;

        public IngredientList(string name, double quantity, string unitOfMeasure)
        {
            Name = name;
            Quantity = quantity;
            Unit = unitOfMeasure;
            originalQuantity = quantity;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewRecipe recipe = new NewRecipe();

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
                    string unitOfMeasure = Console.ReadLine();

                    recipe.AddIngredient(new IngredientList(name, quantity, unitOfMeasure));
                }

                Console.WriteLine("Enter the number of steps:");
                int numSteps = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine("Enter step {0}:", i + 1);
                    string step = Console.ReadLine();
                    recipe.AddSteps(step);
                }

                recipe.DisplayRecipe();

                while (true)
                {
                    Console.WriteLine("Enter '1' to scale the recipe, '2' to reset quantities, '3' to clear recipe, or press anything else to exit:");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
                        double factor = Convert.ToDouble(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        recipe.DisplayRecipe();
                    }
                    else if (input == "2")
                    {
                        recipe.ResetQuantities();
                        recipe.DisplayRecipe();
                    }
                    else if (input == "3")
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

