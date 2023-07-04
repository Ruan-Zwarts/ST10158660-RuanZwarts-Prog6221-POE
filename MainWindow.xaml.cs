using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6221_POE_FinalPart
{
    public class IngredientList
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public IngredientList(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<IngredientList> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<IngredientList>();
            Steps = new List<string>();
        }

        public void AddIngredient(IngredientList ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = 0;
            }
        }

        public void ResetRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }
        public double GetTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories * ingredient.Quantity;
            }
            return totalCalories;
        }

        public string GetFoodGroup()
        {
            string foodGroup = "";
            if (Ingredients.Count > 0)
            {
                foodGroup = Ingredients[0].FoodGroup;
            }
            return foodGroup;
        }

        public void CheckCaloriesExceedLimit(Action<string> notifyUser)
        {
            double totalCalories = Ingredients.Sum(i => i.Calories * i.Quantity);
            const double calorieLimit = 2000;

            if (totalCalories > calorieLimit)
            {
                notifyUser($"The recipe '{Name}' has exceeded the calorie limit.");
            }
        }
    }

    public partial class MainWindow : Window
    {
        public List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Add Recipe
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the recipe:", "Add Recipe");

            int numIngredients = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the number of ingredients:", "Add Recipe"));
            Recipe recipe = new Recipe(name);

            for (int i = 0; i < numIngredients; i++)
            {
                string ingredientName = Microsoft.VisualBasic.Interaction.InputBox($"Enter the name of ingredient {i + 1}:", "Add Recipe");
                double quantity = double.Parse(Microsoft.VisualBasic.Interaction.InputBox($"Enter the quantity of ingredient {i + 1}:", "Add Recipe"));
                string unit = Microsoft.VisualBasic.Interaction.InputBox($"Enter the unit of measurement of ingredient {i + 1}:", "Add Recipe");
                double calories = double.Parse(Microsoft.VisualBasic.Interaction.InputBox($"Enter the number of calories for ingredient {i + 1}:", "Add Recipe"));
                string foodGroup = Microsoft.VisualBasic.Interaction.InputBox($"Enter the food group for ingredient {i + 1}:", "Add Recipe");

                recipe.AddIngredient(new IngredientList(ingredientName, quantity, unit, calories, foodGroup));
            }

            int numSteps = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the number of steps:", "Add Recipe"));

            for (int i = 0; i < numSteps; i++)
            {
                string step = Microsoft.VisualBasic.Interaction.InputBox($"Enter step {i + 1}:", "Add Recipe");
                recipe.AddStep(step);
            }

            recipes.Add(recipe);

            MessageBox.Show("Recipe added successfully");

            // Check if calories exceed the limit
            recipe.CheckCaloriesExceedLimit(NotifyUser);
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            // Modify Recipe
            string recipeOptions = "Select a recipe to modify:\n";
            for (int i = 0; i < recipes.Count; i++)
            {
                recipeOptions += $"{i + 1}. {recipes[i].Name}\n";
            }
            int recipeIndex = int.Parse(Microsoft.VisualBasic.Interaction.InputBox(recipeOptions, "Modify Recipe")) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                Recipe selectedRecipe = recipes[recipeIndex];

                string modifyOptions = "Select an option to modify the recipe:\n";
                modifyOptions += "1. Scale Recipe\n";
                modifyOptions += "2. Reset Recipe Quantities\n";
                modifyOptions += "3. Reset Recipe\n";
                string modifyInput = Microsoft.VisualBasic.Interaction.InputBox(modifyOptions, "Modify Recipe");

                if (modifyInput == "1")
                {
                    double factor = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the scaling factor (e.g., 1.5 to increase by 50%):", "Modify Recipe"));

                    selectedRecipe.ScaleRecipe(factor);
                    MessageBox.Show("Recipe scaled successfully");
                }
                else if (modifyInput == "2")
                {
                    selectedRecipe.ResetQuantities();
                    MessageBox.Show("Recipe quantities reset successfully");
                }
                else if (modifyInput == "3")
                {
                    selectedRecipe.ResetRecipe();
                    MessageBox.Show("Recipe reset successfully");
                }
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else
            {
                MessageBox.Show("Invalid recipe index");
            }
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            // Display Recipes
            string recipeList = "Recipes:\n";
            for (int i = 0; i < recipes.Count; i++)
            {
                recipeList += $"{i + 1}. {recipes[i].Name}\n";
            }

            int recipeIndex = int.Parse(Microsoft.VisualBasic.Interaction.InputBox(recipeList + "Enter the number of the recipe to display:", "Display Recipe")) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                Recipe selectedRecipe = recipes[recipeIndex];

                string recipeDetails = $"Recipe: {selectedRecipe.Name}\n\n";

                recipeDetails += "Ingredients:\n";
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    recipeDetails += $"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit}\n";
                }

                recipeDetails += "\nSteps:\n";
                foreach (var step in selectedRecipe.Steps)
                {
                    recipeDetails += $"{step}\n";
                }

                MessageBox.Show(recipeDetails);
            }
            else
            {
                MessageBox.Show("Invalid recipe index");
            }
        }

        private void NotifyUser(string message)
        {
            MessageBox.Show(message);
        }

        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {
            // Display All Recipes
            string recipeList = "All Recipes:\n";
            for (int i = 0; i < recipes.Count; i++)
            {
                Recipe recipe = recipes[i];

                recipeList += $"{i + 1}. {recipe.Name}\n";

                recipeList += "Ingredients:\n";
                foreach (IngredientList ingredient in recipe.Ingredients)
                {
                    recipeList += $"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}\n";
                }

                recipeList += "Steps:\n";
                foreach (string step in recipe.Steps)
                {
                    recipeList += $"- {step}\n";
                }

                recipeList += "Calories: ";
                double totalCalories = recipe.GetTotalCalories();
                recipeList += $"{totalCalories} kcal\n";

                recipeList += "Food Group: ";
                string foodGroup = recipe.GetFoodGroup();
                recipeList += $"{foodGroup}\n";

                recipeList += "\n";
            }
            MessageBox.Show(recipeList);
        }

        private void btnResetQuan_Click(object sender, RoutedEventArgs e)
        {
            // Reset Quantities
            string recipeOptions = "Select a recipe to reset quantities:\n";
            for (int i = 0; i < recipes.Count; i++)
            {
                recipeOptions += $"{i + 1}. {recipes[i].Name}\n";
            }
            int recipeIndex = int.Parse(Microsoft.VisualBasic.Interaction.InputBox(recipeOptions, "Reset Quantities")) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                Recipe selectedRecipe = recipes[recipeIndex];
                selectedRecipe.ResetQuantities();
                MessageBox.Show("Recipe quantities reset successfully");
            }
            else
            {
                MessageBox.Show("Invalid recipe index");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // Reset Recipe
            string recipeOptions = "Select a recipe to reset:\n";
            for (int i = 0; i < recipes.Count; i++)
            {
                recipeOptions += $"{i + 1}. {recipes[i].Name}\n";
            }
            int recipeIndex = int.Parse(Microsoft.VisualBasic.Interaction.InputBox(recipeOptions, "Reset Recipe")) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                Recipe selectedRecipe = recipes[recipeIndex];
                selectedRecipe.ResetRecipe();
                MessageBox.Show("Recipe reset successfully");
            }
            else
            {
                MessageBox.Show("Invalid recipe index");
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            // Filter Recipes
            string filterOptions = "Select an option to filter the recipes:\n";
            filterOptions += "1. Filter by ingredient\n";
            filterOptions += "2. Filter by maximum calories\n";
            filterOptions += "3. Filter by food group\n";
            string filterInput = Microsoft.VisualBasic.Interaction.InputBox(filterOptions, "Filter Recipes");

            if (filterInput == "1")
            {
                string ingredientName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the ingredient to filter by:", "Filter Recipes");

                string filteredRecipes = "Filtered Recipes (Ingredient):\n";
                foreach (var recipe in recipes)
                {
                    bool hasIngredient = recipe.Ingredients.Any(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));

                    if (hasIngredient)
                    {
                        filteredRecipes += $"{recipe.Name}\n";
                    }
                }

                if (filteredRecipes == "Filtered Recipes (Ingredient):\n")
                {
                    filteredRecipes += "No recipes found matching the ingredient filter criteria.";
                }

                MessageBox.Show(filteredRecipes);
            }
            else if (filterInput == "2")
            {
                double maxCalories = double.Parse(Microsoft.VisualBasic.Interaction.InputBox("Enter the maximum calories to filter by:", "Filter Recipes"));

                string filteredRecipes = "Filtered Recipes (Maximum Calories):\n";
                foreach (var recipe in recipes)
                {
                    double totalCalories = recipe.Ingredients.Sum(i => i.Calories * i.Quantity);

                    if (totalCalories <= maxCalories)
                    {
                        filteredRecipes += $"{recipe.Name}\n";
                    }
                }

                if (filteredRecipes == "Filtered Recipes (Maximum Calories):\n")
                {
                    filteredRecipes += "No recipes found matching the maximum calories filter criteria.";
                }

                MessageBox.Show(filteredRecipes);
            }
            else if (filterInput == "3")
            {
                string foodGroup = Microsoft.VisualBasic.Interaction.InputBox("Enter the food group to filter by:", "Filter Recipes");

                string filteredRecipes = "Filtered Recipes (Food Group):\n";
                foreach (var recipe in recipes)
                {
                    bool hasFoodGroup = recipe.Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase));

                    if (hasFoodGroup)
                    {
                        filteredRecipes += $"{recipe.Name}\n";
                    }
                }

                if (filteredRecipes == "Filtered Recipes (Food Group):\n")
                {
                    filteredRecipes += "No recipes found matching the food group filter criteria.";
                }

                MessageBox.Show(filteredRecipes);
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // Exit the application
            Application.Current.Shutdown();
        }
    }
}