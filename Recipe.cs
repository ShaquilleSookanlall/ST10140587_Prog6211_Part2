using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10140587_Prog6211_Part2
{
    internal class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set;}
        public List<String> Method { get; set;}
        private List<String> OriginalIngredients { get; set;}
        public double CalorieCount { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Method = new List<String>();
            OriginalIngredients = new List<String>();
        }
    }
}
