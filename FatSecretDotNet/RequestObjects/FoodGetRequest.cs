using System.Collections.Generic;

namespace FatSecretDotNet.RequestObjects
{
    public class FoodGetRequest : IFatSecretRequest
    {
        private readonly string _method = "food.get.v2";
        public int FoodId { get; set; }

        public FoodGetRequest()
        {
         
        }

        public List<(string,string)> GetParameters()
        {
            var headers = new List<(string,string)>();
                headers.Add(("method", _method));
                headers.Add(("food_id", FoodId.ToString()));
                return headers;
            
        }
    }
}