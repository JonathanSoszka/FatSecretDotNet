using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class RecipieTypesRequest : IFatSecretRequest
    {
        public readonly string _method = "recipe_types.get";

        public List<(string, string)> GetParameters(bool isPremier)
        {
            var headers = new List<(string,string)>();
            headers.Add(("method", _method));
            return headers;
        }
    }
}