using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class RecipesSearchRequest : IFatSecretRequest
    {
        private readonly string _method = "recipes.search";
        public string SearchExpression { get; set; }
        public string RecipeType { get; set; }
        public int PageNumber { get; set; } = 1;
        public int MaxResults { get; set; } = 50;
        
        public List<(string, string)> GetParameters()
        {
            var headers = new List<(string,string)>();
            headers.Add(("method", _method));
            headers.Add(("search_expression", SearchExpression));
            headers.Add(("recipe_type", RecipeType));
            headers.Add(("page_number", PageNumber.ToString()));
            headers.Add(("max_results", MaxResults.ToString()));
            return headers;
        }
    }
}