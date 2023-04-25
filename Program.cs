using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    class Recipe
    {
        private List<Ingredient> ingredients;
        private List<string> steps;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void AddIngredients(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
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
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

        /// <summary>
        /// 
        /// </summary>

        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            private double originalQuantity;

            public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                originalQuantity = quantity;
            }

            public void ResetQuantity()
            {
                Quantity = originalQuantity;
            }
        }
    }








    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

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

                    recipe.AddIngredients (new Ingredient (name, quantity, unit));
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
