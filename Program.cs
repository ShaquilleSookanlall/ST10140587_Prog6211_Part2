using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10140587_Prog6211_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            while (true)
            {
                Console.WriteLine("Recipe Manager");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe to display");
                Console.WriteLine("4. Clear all recipes");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EnterRecipe(recipes);
                        break;
                    case "2":
                        DisplayAllRecipes(recipes);
                        break;
                    case "3":
                        SelectRecipeToDisplay(recipes);
                        break;
                    case "4":
                        recipes.Clear();
                        Console.WriteLine("All recipes cleared.");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void EnterRecipe(List<Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = new Recipe(recipeName);

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write("Enter ingredient name: ");
                string name = Console.ReadLine();
                Console.Write("Enter quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Enter unit of measurement: ");
                string unit = Console.ReadLine();
                Console.Write("Enter calories per unit: ");
                double calories = double.Parse(Console.ReadLine());
                Console.Write("Enter food group: ");
                string foodGroup = Console.ReadLine();
                recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully.");
        }

        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("Recipes:");
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        static void SelectRecipeToDisplay(List<Recipe> recipes)
        {
            Console.Write("Enter the name of the recipe to display: ");
            string recipeName = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.DisplayRecipe();
                DisplayScaleMenu(recipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void DisplayScaleMenu(Recipe recipe)
        {
            while (true)
            {
                Console.WriteLine("\nScale Recipe Menu");
                Console.WriteLine("1. Scale recipe by 0.5");
                Console.WriteLine("2. Scale recipe by 2");
                Console.WriteLine("3. Scale recipe by 3");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Return to home screen");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipe.ScaleRecipe(0.5);
                        recipe.DisplayRecipe();
                        break;
                    case "2":
                        recipe.ScaleRecipe(2);
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        recipe.ScaleRecipe(3);
                        recipe.DisplayRecipe();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        recipe.DisplayRecipe();
                        break;
                    case "5":
                        recipe.ResetQuantities(); // Reset quantities before returning
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}