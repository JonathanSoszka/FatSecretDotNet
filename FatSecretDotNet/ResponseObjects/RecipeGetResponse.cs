using System.Collections.Generic;

namespace FatSecretDotNet.ResponseObjects
{
   
    public class RecipeGetResponse : FatSecretResponse
    {
        public Recipe Recipe { get; set; }
    }
    
    public class Direction
    {
        public string DirectionDescription { get; set; }
        public string DirectionNumber { get; set; }
    }

    public class Directions
    {
        public List<Direction> Direction { get; set; }
    }

    public class Ingredient
    {
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public string IngredientDescription { get; set; }
        public string IngredientUrl { get; set; }
        public string MeasurementDescription { get; set; }
        public string NumberOfUnits { get; set; }
        public string ServingId { get; set; }
    }

    public class Ingredients
    {
        public List<Ingredient> Ingredient { get; set; }
    }

    public class RecipeCategory
    {
        public string RecipeCategoryName { get; set; }
        public string RecipeCategoryUrl { get; set; }
    }

    public class RecipeCategories
    {
        public List<RecipeCategory> RecipeCategory { get; set; }
    }

    public class RecipeImages
    {
        public string RecipeImage { get; set; }
    }
    

    public class RecipeServing
    {
        public string Calcium { get; set; }
        public string Calories { get; set; }
        public string Carbohydrate { get; set; }
        public string Cholesterol { get; set; }
        public string Fat { get; set; }
        public string Fiber { get; set; }
        public string Iron { get; set; }
        public string MonounsaturatedFat { get; set; }
        public string PolyunsaturatedFat { get; set; }
        public string Potassium { get; set; }
        public string Protein { get; set; }
        public string SaturatedFat { get; set; }
        public string ServingSize { get; set; }
        public string Sodium { get; set; }
        public string Sugar { get; set; }
        public string TransFat { get; set; }
        public string VitaminA { get; set; }
        public string VitaminC { get; set; }
    }

    public class ServingSizes
    {
        public RecipeServing Serving { get; set; }
    }

    public class Recipe
    {
        public string CookingTimeMin { get; set; }
        public Directions Directions { get; set; }
        public Ingredients Ingredients { get; set; }
        public string NumberOfServings { get; set; }
        public string PreparationTimeMin { get; set; }
        public RecipeCategories RecipeCategories { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeId { get; set; }
        public RecipeImages RecipeImages { get; set; }
        public string RecipeName { get; set; }
        public RecipeTypes RecipeTypes { get; set; }
        public string RecipeUrl { get; set; }
        public ServingSizes ServingSizes { get; set; }
    }



}