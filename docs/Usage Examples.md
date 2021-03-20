# Usage Examples

## Foods Search
```
            var foodSearchRequest = new FoodsSearchRequest()
            {
                SearchExpression = "Apples",
                MaxResults = 25, //optional
                PageNumber = 1   //optional
            };
            var foods = client.FoodsSearch(foodSearchRequest);
```

## Food Get
```
            var request = new FoodGetRequest()
            {
                FoodId = foodId
            };
            var response = client.FoodGet(request);
```

## Recipes Search
```
            var request = new RecipesSearchRequest()
            {
                SearchExpression = "Cake",
                MaxResults = 25, //optional
                PageNumber = 1   //optional
            };
            var response = client.RecipesSearch(request);
 ```
 
 ## Recipe Get
 ```
            var request = new RecipeGetRequest()
            {
                RecipeId = 0
            };
            var response = client.RecipeGet(request);
 ```
 
 ## Get Recipes Type
 ```
            var client = GetClient();
            var response = client.GetRecipieTypes();
 ```
