using System.Collections.Generic;

namespace FatSecretDotNet.ResponseObjects
{
    public class RecipesSearchResponse : FatSecretResponse
    {
        public SearchRecipes Recipes { get; set; }
    }
    
    public class SearchRecipeNutrition
    {
        public string Calories { get; set; }
        public string Carbohydrate { get; set; }
        public string Fat { get; set; }
        public string Protein { get; set; }
    }

    public class SearchRecipe
    {
        public string RecipeDescription { get; set; }
        public string RecipeId { get; set; }
        public string RecipeImage { get; set; }
        public string RecipeName { get; set; }
        public SearchRecipeNutrition RecipeNutrition { get; set; }
        public string RecipeUrl { get; set; }
    }

    public class SearchRecipes
    {
        public string MaxResults { get; set; }
        public string PageNumber { get; set; }
        public List<Recipe> Recipe { get; set; }
        public string TotalResults { get; set; }
    }
}