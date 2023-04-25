using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10158660_RuanZwarts_Prog6221_POE
{
    internal class RecipeList
    {

        public List <IngredientList> RuanIngredients;
        public List <string> steps;

        public RecipeList()
        {
            RuanIngredients = new List<IngredientList>();
            steps = new List<string>();
        }

        public void AddIngredients(IngredientList ingredient)
        {
            RuanIngredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (IngredientList ingredient in RuanIngredients)
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
            foreach (IngredientList ingredient in RuanIngredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (IngredientList ingredient in RuanIngredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearRecipe()
        {
            RuanIngredients.Clear();
            steps.Clear();
        }
    }
}
