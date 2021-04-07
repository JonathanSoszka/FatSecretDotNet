using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class RecipeGetRequest : IFatSecretRequest
    {
        private readonly string _method = "recipe.get";
        public long RecipeId { get; set; }
        
        public List<(string,string)> GetParameters(bool isPremier)
        {
            var headers = new List<(string,string)>();
            headers.Add(("method", _method));
            headers.Add(("recipe_id", RecipeId.ToString()));
            return headers;
            
        }
    }
}