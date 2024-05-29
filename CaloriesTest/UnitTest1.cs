using ST10140587_Prog6211_Part2;
using Xunit;
using Assert = Xunit.Assert;

namespace CalorieTest
{
    public class RecipeCalorieTest
    {
        [Fact]
        public void TestCalorieExceedsLimit()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Sugar", 10, "grams", 50, "Sweets");
            recipe.AddIngredient("Butter", 20, "grams", 100, "Dairy");
            recipe.AddIngredient("Flour", 30, "grams", 50, "Grains");

            // Act
            bool exceedsLimit = recipe.ExceedsCalorieLimit();

            // Assert
            Assert.True(exceedsLimit);
        }

        [Fact]
        public void TestCalorieDoesNotExceedLimit()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Sugar", 5, "grams", 50, "Sweets");
            recipe.AddIngredient("Butter", 10, "grams", 100, "Dairy");

            // Act
            bool exceedsLimit = recipe.ExceedsCalorieLimit();

            // Assert
            Assert.False(exceedsLimit);
        }

        [Fact]
        public void TestCalorieLimitAfterScaling()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Sugar", 5, "grams", 50, "Sweets");
            recipe.AddIngredient("Butter", 10, "grams", 100, "Dairy");

            // Act
            recipe.ScaleRecipe(2);
            bool exceedsLimit = recipe.ExceedsCalorieLimit();

            // Assert
            Assert.True(exceedsLimit);
        }

        [Fact]
        public void TestCalorieLimitAfterResetting()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Sugar", 5, "grams", 50, "Sweets");
            recipe.AddIngredient("Butter", 10, "grams", 100, "Dairy");

            // Act
            recipe.ScaleRecipe(2);
            recipe.ResetQuantities();
            bool exceedsLimit = recipe.ExceedsCalorieLimit();

            // Assert
            Assert.False(exceedsLimit);
        }
    }
}
