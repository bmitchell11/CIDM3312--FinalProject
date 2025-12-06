using System.ComponentModel.DataAnnotations; 
namespace CIDM3312__FinalProject.Models; 

public class Recipe 

{ 
    public int RecipeID {get; set;} // Primary Key 

    public string Title {get; set;} = string.Empty; 

    public string Instructions {get; set;} = string.Empty; 

    [Display(Name = "Cook Time")]
    public int CookTime {get; set;} 

    [Display(Name = "Date Added")]
    public DateTime DateAdded {get; set;}

    // This property is not optional (?) because Recipes cannot exist without any ingredients.
    [Display(Name = "Recipe Ingredients")]
    public List<RecipeIngredient> RecipeIngredients {get; set;} = default!; // Navigation property
} 