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

        public void AddSteps(string step)           //Method for adding the amount of steps
        {
            steps.Add(step);
        }

        public void DisplayRecipe()             //Adds the display function so the user is able to see the recipe
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

        public void ScaleRecipe(double factor)      // Adds the scale function for scaling the recipe
        {
            foreach (IngredientList ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void Reset()           //Adds the reset dunction so the recipe can be reset
        {
            foreach (IngredientList ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearRecipe()       //Adds the clear recipe method
        {
            ingredients.Clear();
            steps.Clear();
        }
    }

    class IngredientList        //The ingredients class with all the getters and setters, as well as havign the imprtant names, quantities, units of measurement and the original quantity so be able to go back tp the original recipe
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

        public void ResetQuantity() // Allows for the resetting of the quantity in the recipe to its orginal quantity
        {
            Quantity = originalQuantity;
        }
    }

    class Program
    {
        static void Main(string[] args)     //Main method to put everything together
        {
            NewRecipe recipe = new NewRecipe();

            while (true)
            {
                Console.WriteLine("Enter the number of ingredients:");      //entering the number of ingredients
                int numIngredients = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine("Enter the name of ingredient {0}:", i + 1);      //entering the name of the ingredient, eg Eggs/Flour/Milk,etc
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter the quantity of ingredient {0}:", i + 1);  //entering the amount of this ingredient
                    double quantity = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter the unit of measurement of ingredient {0}:", i + 1);   //giving the unit of measurement of the ingredient above
                    string unitOfMeasure = Console.ReadLine();

                    recipe.AddIngredient(new IngredientList(name, quantity, unitOfMeasure));
                }

                Console.WriteLine("Enter the number of steps:");            //entering the amount of steps needed to make the recipe
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

                    if (input == "1")       //gives the user the ability to scale the order
                    {
                        Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
                        double factor = Convert.ToDouble(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        recipe.DisplayRecipe();
                    }
                    else if (input == "2")  //gives the user the ability to reset the recipe quantities
                    {
                        recipe.Reset();
                        recipe.DisplayRecipe();
                    }
                    else if (input == "3")  //gives the user the ability to clear the recipe
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

