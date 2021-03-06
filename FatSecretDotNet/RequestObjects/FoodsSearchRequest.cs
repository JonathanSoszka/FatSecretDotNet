using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class FoodsSearchRequest : IFatSecretRequest
    {
        private readonly string _method = "foods.search";
        public string SearchExpression { get; set; }
        public int PageNumber { get; set; } = 0;
        public int MaxResults { get; set; } = 50;
        public GenericDescription GenericDescription { get; set; }

        public List<(string, string)> GetParameters(bool isPremier)
        {
            var headers = new List<(string, string)>();
            headers.Add(("method", _method));
            headers.Add(("search_expression", SearchExpression));
            headers.Add(("page_number", PageNumber.ToString()));
            headers.Add(("max_results", MaxResults.ToString()));
            if (!isPremier) return headers;
            
            headers.Add(("generic_description", GenericDescription.ToString()));
            return headers;
        }
    }
    
    public enum GenericDescription
    {
       Weight = 0,
       Portion = 1
    }
}