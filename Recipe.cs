using System;
using System.Collections.Generic;

namespace ST10140587_Prog6211_Part2
{
    // Class to manage the recipe
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        private List<Ingredient> OriginalIngredients { get; set; }
        private double CalorieLimit { get; set; } = 300;

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            OriginalIngredients = new List<Ingredient>();
        }

        // Method to add an ingredient
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            var ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            Ingredients.Add(ingredient);
            OriginalIngredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup)); // Save original quantity

            // Check calories after adding the ingredient
            double totalCalories = CalculateTotalCalories();
            if (totalCalories > CalorieLimit)
            {
                Console.WriteLine($"Warning: Total calories exceed {CalorieLimit}!");
            }
        }

        // Method to add a step
        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        // Method to scale ingredients
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
            CalorieLimit *= factor; // Scale the calorie limit
        }

        // Method to reset ingredients to original quantities
        public void ResetQuantities()
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = OriginalIngredients[i].Quantity;
            }
            CalorieLimit = 300; // Reset the calorie limit to the original value
        }

        // Method to calculate total calories
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories * ingredient.Quantity;
            }
            return totalCalories;
        }

        // Method to check if total calories exceed a limit
        public bool ExceedsCalorieLimit()
        {
            return CalculateTotalCalories() > CalorieLimit;
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} - {ingredient.Calories * ingredient.Quantity} calories ({ingredient.FoodGroup})");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"\nTotal Calories: {totalCalories}");
            if (totalCalories > CalorieLimit)
            {
                Console.WriteLine($"Warning: Total calories exceed {CalorieLimit}!");
            }
        }
    }
}