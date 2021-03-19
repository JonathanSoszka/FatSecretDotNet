using System.Collections.Generic;

namespace FatSecretDotNet.ResponseObjects
{
    public class RecipieTypesResponse : FatSecretResponse
    {
        public RecipeTypes RecipeTypes { get; set; }
    }
    public class RecipeTypes
    {
        public List<string> RecipeType { get; set; }
    }
}