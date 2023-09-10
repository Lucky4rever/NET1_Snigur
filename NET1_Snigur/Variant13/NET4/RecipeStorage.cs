using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET4
{
    class RecipeStorage
    {
        private readonly List<Recipe> Recipes;

        public RecipeStorage()
        {
            this.Recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return this.Recipes;
        }

        public void CheckDate()
        {
            List<Recipe> recipesCopy = new List<Recipe>(this.Recipes);

            recipesCopy.ForEach(recipe =>
            {
                if (recipe.EndDate <= DateTime.Now.Date)
                {
                    this.RemoveRecipe(recipe);
                }
            });
        }

        public Recipe GetPatientRecipe(Patient patient)
        {
            return this.Recipes.Find(recipe => recipe.Patient == patient);
        }

        public void IncreaseEndDate(Recipe recipe, double days)
        {
            this.Recipes
                .Find(_recipe => _recipe == recipe)
                .IncreaseEndDate(days);
        }
    }
}
