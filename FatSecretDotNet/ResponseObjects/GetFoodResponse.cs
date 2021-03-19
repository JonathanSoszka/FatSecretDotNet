using System.Collections.Generic;

namespace FatSecretDotNet.ResponseObjects
{
    public class GetFoodResponse : FatSecretResponse
    {
        public Food Food { get; set; }
    }
    
    public class Food
    {
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public string FoodUrl { get; set; }
        public Servings Servings { get; set; }
    }
    
    public class Servings
    {
        public List<Serving> Serving { get; set; }
    }
    
    public class Serving
    {
        public string Calcium { get; set; }
        public string Calories { get; set; }
        public string Carbohydrate { get; set; }
        public string Cholesterol { get; set; }
        public string Fat { get; set; }
        public string Fiber { get; set; }
        public string Iron { get; set; }
        public string MeasurementDescription { get; set; }
        public string MetricServingAmount { get; set; }
        public string MetricServingUnit { get; set; }
        public string MonounsaturatedFat { get; set; }
        public string NumberOfUnits { get; set; }
        public string PolyunsaturatedFat { get; set; }
        public string Potassium { get; set; }
        public string Protein { get; set; }
        public string SaturatedFat { get; set; }
        public string ServingDescription { get; set; }
        public string ServingId { get; set; }
        public string ServingUrl { get; set; }
        public string Sodium { get; set; }
        public string Sugar { get; set; }
        public string VitaminA { get; set; }
        public string VitaminC { get; set; }
    }
}