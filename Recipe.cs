using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    public class Recipe
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        public void EnterDetails() 
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();

                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                Ingredient ingredient = new Ingredient(name, quantity, unit);
                ingredients.Add(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                steps.Add(step);
            }
        }

        public void Display()
        {
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void Scale()
        {
            Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
            double factor = double.Parse(Console.ReadLine());

            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void Reset()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Reset();
            }
        }

        public void ClearData()
        {
            ingredients.Clear();
            steps.Clear();
        }




    }
}