using Microsoft.AspNetCore.Mvc.ModelBinding; 
namespace CIDM3312__FinalProject.Models; 

public class Ingredient 

{ 

    public int IngredientID {get; set;} // Primary Key

    public string Name {get; set;} = string.Empty;

    public string DefaultUnit {get; set;} = string.Empty;

    // Optional (?) property because Ingredients can exist without being in a recipe
    public List<RecipeIngredient>? RecipeIngredients {get; set;} = default!; // Navigation property

} 

 

public class RecipeIngredient 

{ 
    public int RecipeID {get; set;} // Composite Primary Key, Foreign Key 1 

    public int IngredientID {get; set;} // Composite Primary Key, Foreign Key 2 

    public string Quantity {get; set;} = string.Empty; 

    public Recipe Recipe {get; set;} = default!; // Navigation Property 

    public Ingredient Ingredient {get; set;} = default!; // Navigation Property 
} 

 