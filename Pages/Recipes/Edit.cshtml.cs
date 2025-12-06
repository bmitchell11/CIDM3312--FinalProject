using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIDM3312__FinalProject.Models;

namespace CIDM3312__FinalProject.Pages_Recipes
{
    public class EditModel : PageModel
    {
        private readonly CIDM3312__FinalProject.Models.AppDbContext _context;

        public EditModel(CIDM3312__FinalProject.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        public List<Ingredient> Ingredients {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data using Include and ThenInclude
            var recipe =  await _context.Recipes.Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(m => m.RecipeID == id);
            // Get a list of all courses. This list is used to make the checkboxes
            Ingredients = _context.Ingredients.ToList();

            if (recipe == null)
            {
                return NotFound();
            }
            Recipe = recipe;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int[] selectedIngredients)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var recipeToUpdate = await _context.Recipes.Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(m => m.RecipeID == Recipe.RecipeID);
            if (recipeToUpdate != null)
            {
                recipeToUpdate.Title = Recipe.Title;
                // recipeToUpdate.RecipeIngredients = Recipe.RecipeIngredients;
                UpdateRecipeIngredients(selectedIngredients, recipeToUpdate);
                // await _context.SaveChangesAsync();
            }



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.RecipeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }

        private void UpdateRecipeIngredients(int[] selectedIngredients, Recipe recipeToUpdate)
        {
            if (selectedIngredients == null)
            {
                recipeToUpdate.RecipeIngredients = new List<RecipeIngredient>();
                return;
            }

            List<int> currentIngredients = recipeToUpdate.RecipeIngredients.Select(i => i.IngredientID).ToList();
            List<int> selectedIngredientsList = selectedIngredients.ToList();

            foreach (var ingredient in _context.Ingredients)
            {
                if (selectedIngredientsList.Contains(ingredient.IngredientID))
                {
                    if (!currentIngredients.Contains(ingredient.IngredientID))
                    {
                        // Add recipe here
                        recipeToUpdate.RecipeIngredients!.Add(
                            new RecipeIngredient { RecipeID = recipeToUpdate.RecipeID, IngredientID = ingredient.IngredientID });
                    }
                }
                else
                {
                    if (currentIngredients.Contains(ingredient.IngredientID))
                    {
                        // Remove recipe here
                        RecipeIngredient ingredientToRemove = recipeToUpdate.RecipeIngredients.SingleOrDefault(r => r.IngredientID == ingredient.IngredientID)!;
                        _context.Remove(ingredientToRemove);
                    }
                }
                
            }
        }
    }
}
