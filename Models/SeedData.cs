using Microsoft.EntityFrameworkCore;

namespace CIDM3312__FinalProject.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Recipes.Any())
        {
            return;
        }

        // Add Students, Courses, and StudentCourses below

        List<Ingredient> ingredients = new List<Ingredient> 
    { 
        new Ingredient { Name = "Flour", DefaultUnit = "cups" }, 
        new Ingredient { Name = "Sugar", DefaultUnit = "cups" }, 
        new Ingredient { Name = "Salt", DefaultUnit = "tsp" }, 
        new Ingredient { Name = "Butter", DefaultUnit = "tbsp" }, 
        new Ingredient { Name = "Eggs", DefaultUnit = "units" }, 
        new Ingredient { Name = "Milk", DefaultUnit = "cups" }, 
        new Ingredient { Name = "Garlic", DefaultUnit = "cloves" }, 
        new Ingredient { Name = "Chicken", DefaultUnit = "lbs" }, 
        new Ingredient { Name = "Rice", DefaultUnit = "cups" }, 
        new Ingredient { Name = "Tomatoes", DefaultUnit = "units" } 
    }; 
    context.AddRange(ingredients); 
    context.SaveChanges(); 
 
    // ------------------------------------------ 
    // RECIPES 
    // ------------------------------------------ 
    List<Recipe> recipes = new List<Recipe> 
    { 
        new Recipe { Title="Pancakes", Instructions="Mix ingredients and cook on griddle.", CookTime=15, DateAdded=DateTime.Now }, 
        new Recipe { Title="Garlic Chicken", Instructions="Season chicken and cook with garlic.", CookTime=40, DateAdded=DateTime.Now }, 
        new Recipe { Title="Tomato Omelette", Instructions="Whisk eggs and tomatoes, fry.", CookTime=10, DateAdded=DateTime.Now }, 
        new Recipe { Title="Butter Rice", Instructions="Cook rice and mix with melted butter.", CookTime=25, DateAdded=DateTime.Now }, 
        new Recipe { Title="Sugar Cookies", Instructions="Mix dough and bake.", CookTime=20, DateAdded=DateTime.Now }, 
        new Recipe { Title="Garlic Butter Pasta", Instructions="Cook pasta and add garlic butter sauce.", CookTime=30, DateAdded=DateTime.Now }, 
        new Recipe { Title="Tomato Soup", Instructions="Blend tomatoes and simmer.", CookTime=35, DateAdded=DateTime.Now }, 
        new Recipe { Title="Scrambled Eggs", Instructions="Whisk eggs and cook on pan.", CookTime=8, DateAdded=DateTime.Now }, 
        new Recipe { Title="Chicken Rice Bowl", Instructions="Cook chicken and serve over rice.", CookTime=45, DateAdded=DateTime.Now }, 
        new Recipe { Title="Milk Bread", Instructions="Mix dough with milk and bake.", CookTime=60, DateAdded=DateTime.Now }, 
        new Recipe { Title="Garlic Fried Rice", Instructions="Fry rice with garlic and seasoning.", CookTime=18, DateAdded=DateTime.Now },
        new Recipe { Title="Tomato Chicken Stew", Instructions="Simmer chicken with tomatoes.", CookTime=50, DateAdded=DateTime.Now },
        new Recipe { Title="Sweet Milk Tea", Instructions="Heat milk and sugar, steep tea bag.", CookTime=7, DateAdded=DateTime.Now },
        new Recipe { Title="Butter Chicken Bites", Instructions="Pan fry chicken pieces in butter.", CookTime=30, DateAdded=DateTime.Now },
        new Recipe { Title="Garlic Bread", Instructions="Spread garlic butter on bread and bake.", CookTime=12, DateAdded=DateTime.Now },
        new Recipe { Title="Tomato Rice", Instructions="Cook rice with chopped tomatoes.", CookTime=28, DateAdded=DateTime.Now },
        new Recipe { Title="Fluffy Scrambled Eggs", Instructions="Whip eggs with milk for fluffiness.", CookTime=6, DateAdded=DateTime.Now },
        new Recipe { Title="Chicken Stir Fry", Instructions="Stir fry chicken with garlic.", CookTime=22, DateAdded=DateTime.Now },
        new Recipe { Title="Simple Rice Pilaf", Instructions="Cook rice with butter and salt.", CookTime=20, DateAdded=DateTime.Now },
        new Recipe { Title="Creamy Tomato Pasta", Instructions="Mix pasta with creamy tomato sauce.", CookTime=32, DateAdded=DateTime.Now },
        new Recipe { Title="Garlic Tomato Chicken", Instructions="Bake chicken with garlic and tomatoes.", CookTime=55, DateAdded=DateTime.Now },
        new Recipe { Title="Sweet Egg Custard", Instructions="Bake egg mixture sweetened with sugar.", CookTime=40, DateAdded=DateTime.Now },
        new Recipe { Title="Butter Fried Eggs", Instructions="Fry eggs in butter.", CookTime=5, DateAdded=DateTime.Now },
        new Recipe { Title="Tomato Garlic Rice Bowl", Instructions="Layer rice with tomatoes and garlic.", CookTime=15, DateAdded=DateTime.Now },
        new Recipe { Title="Herbed Chicken & Rice", Instructions="Cook chicken and rice with simple seasoning.", CookTime=42, DateAdded=DateTime.Now }
    }; 
    context.AddRange(recipes); 
    context.SaveChanges(); 
 
    // ------------------------------------------ 
    // RECIPE INGREDIENTS (JOIN TABLE) 
    // ------------------------------------------ 
    // Use the actual IDs from saved entities 
    List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient> 
    { 
        new RecipeIngredient { RecipeID = recipes[0].RecipeID, IngredientID = ingredients[0].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[0].RecipeID, IngredientID = ingredients[1].IngredientID, Quantity="0.25" },
    new RecipeIngredient { RecipeID = recipes[0].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[0].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="1" },

    // 1 - Garlic Chicken
    new RecipeIngredient { RecipeID = recipes[1].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[1].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[1].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="2" },

    // 2 - Tomato Omelette
    new RecipeIngredient { RecipeID = recipes[2].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[2].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="1" },

    // 3 - Butter Rice
    new RecipeIngredient { RecipeID = recipes[3].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[3].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="2" },

    // 4 - Sugar Cookies
    new RecipeIngredient { RecipeID = recipes[4].RecipeID, IngredientID = ingredients[0].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[4].RecipeID, IngredientID = ingredients[1].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[4].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[4].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="1" },

    // 5 - Garlic Butter Pasta
    new RecipeIngredient { RecipeID = recipes[5].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[5].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[5].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="1" },

    // 6 - Tomato Soup
    new RecipeIngredient { RecipeID = recipes[6].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[6].RecipeID, IngredientID = ingredients[2].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[6].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="1" },

    // 7 - Scrambled Eggs
    new RecipeIngredient { RecipeID = recipes[7].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[7].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="0.25" },
    new RecipeIngredient { RecipeID = recipes[7].RecipeID, IngredientID = ingredients[2].IngredientID, Quantity="1" },

    // 8 - Chicken Rice Bowl
    new RecipeIngredient { RecipeID = recipes[8].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[8].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[8].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="2" },

    // 9 - Milk Bread
    new RecipeIngredient { RecipeID = recipes[9].RecipeID, IngredientID = ingredients[0].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[9].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[9].RecipeID, IngredientID = ingredients[1].IngredientID, Quantity="0.5" },

    // 10 - Garlic Fried Rice
    new RecipeIngredient { RecipeID = recipes[10].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[10].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="2" },

    // 11 - Tomato Chicken Stew
    new RecipeIngredient { RecipeID = recipes[11].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[11].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[11].RecipeID, IngredientID = ingredients[2].IngredientID, Quantity="1" },

    // 12 - Sweet Milk Tea
    new RecipeIngredient { RecipeID = recipes[12].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[12].RecipeID, IngredientID = ingredients[1].IngredientID, Quantity="0.25" },

    // 13 - Butter Chicken Bites
    new RecipeIngredient { RecipeID = recipes[13].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[13].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="2" },

    // 14 - Garlic Bread
    new RecipeIngredient { RecipeID = recipes[14].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[14].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="2" },

    // 15 - Tomato Rice
    new RecipeIngredient { RecipeID = recipes[15].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[15].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="2" },

    // 16 - Fluffy Scrambled Eggs
    new RecipeIngredient { RecipeID = recipes[16].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[16].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="0.5" },

    // 17 - Chicken Stir Fry
    new RecipeIngredient { RecipeID = recipes[17].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[17].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="2" },

    // 18 - Simple Rice Pilaf
    new RecipeIngredient { RecipeID = recipes[18].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[18].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[18].RecipeID, IngredientID = ingredients[2].IngredientID, Quantity="1" },

    // 19 - Creamy Tomato Pasta
    new RecipeIngredient { RecipeID = recipes[19].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="3" },
    new RecipeIngredient { RecipeID = recipes[19].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[19].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="1" },

    // 20 - Garlic Tomato Chicken
    new RecipeIngredient { RecipeID = recipes[20].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[20].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[20].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="2" },

    // 21 - Sweet Egg Custard
    new RecipeIngredient { RecipeID = recipes[21].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="4" },
    new RecipeIngredient { RecipeID = recipes[21].RecipeID, IngredientID = ingredients[1].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[21].RecipeID, IngredientID = ingredients[5].IngredientID, Quantity="1" },

    // 22 - Butter Fried Eggs
    new RecipeIngredient { RecipeID = recipes[22].RecipeID, IngredientID = ingredients[4].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[22].RecipeID, IngredientID = ingredients[3].IngredientID, Quantity="1" },

    // 23 - Tomato Garlic Rice Bowl
    new RecipeIngredient { RecipeID = recipes[23].RecipeID, IngredientID = ingredients[9].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[23].RecipeID, IngredientID = ingredients[6].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[23].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="2" },

    // 24 - Herbed Chicken & Rice
    new RecipeIngredient { RecipeID = recipes[24].RecipeID, IngredientID = ingredients[7].IngredientID, Quantity="1" },
    new RecipeIngredient { RecipeID = recipes[24].RecipeID, IngredientID = ingredients[8].IngredientID, Quantity="2" },
    new RecipeIngredient { RecipeID = recipes[24].RecipeID, IngredientID = ingredients[2].IngredientID, Quantity="1" }
    }; 
    context.AddRange(recipeIngredients); 
    context.SaveChanges();
    }
}