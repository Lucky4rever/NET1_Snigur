using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET4
{
    class RecipeStorage
    {
        private readonly List<Recipe> _recipes;

        public RecipeStorage()
        {
            this._recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            this._recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            this._recipes.Remove(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return this._recipes;
        }

        public void CheckDate()
        {
            List<Recipe> recipesCopy = new List<Recipe>(this._recipes);

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
            return this._recipes.Find(recipe => recipe.Patient == patient);
        }

        public void IncreaseEndDate(Recipe recipe, double days)
        {
            this._recipes
                .Find(_recipe => _recipe == recipe)
                .IncreaseEndDate(days);
        }
    }
}
