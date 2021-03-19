using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class FoodsSearchRequest : IFatSecretRequest
    {
        private readonly string _method = "foods.search";
        public string SearchExpression { get; set; }
        public int PageNumber { get; set; } = 1;
        public int MaxResults { get; set; } = 50;

        public List<(string, string)> GetHeaders()
        {
           var headers = new List<(string,string)>();
                headers.Add(("method", _method));
                headers.Add(("search_expression", SearchExpression));
                headers.Add(("page_number", PageNumber.ToString()));
                headers.Add(("max_results", MaxResults.ToString()));
                return headers;
        }
    }
}