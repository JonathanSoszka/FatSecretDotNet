using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class FoodGetRequest : IFatSecretRequest
    {
        private readonly string _method = "food.get.v2";
        public int FoodId { get; set; }
        
        //premier
        public bool FlagDefaultServing { get; set; }
        public bool IncludeSubCategories { get; set; }

        public FoodGetRequest()
        {
         
        }

        public List<(string,string)> GetParameters(bool isPremier)
        {
            var headers = new List<(string,string)>();
                headers.Add(("method", _method));
                headers.Add(("food_id", FoodId.ToString()));
                if (!isPremier) return headers;
                headers.Add(("flag_default_serving", FlagDefaultServing.ToString()));
                headers.Add(("include_sub_categories", IncludeSubCategories.ToString()));
                return headers;
            
        }
    }
}