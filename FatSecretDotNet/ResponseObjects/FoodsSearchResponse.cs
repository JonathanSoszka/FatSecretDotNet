using System.Collections.Generic;

namespace FatSecretDotNet.ResponseObjects
{
    public class FoodsSearchResponse : FatSecretResponse
    {
        public SearchedFoods Foods { get; set; }
    }
    public class SearchedFoods
    {
        public List<SearchedFood> Food { get; set; }
        public string MaxResults { get; set; }
        public string PageNumber { get; set; }
        public string TotalResults { get; set; }
    }
    public class SearchedFood
    {
        public string BrandName { get; set; }
        public string FoodDescription { get; set; }
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public string FoodUrl { get; set; }
    }
}