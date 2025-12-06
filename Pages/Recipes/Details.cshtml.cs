using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIDM3312__FinalProject.Models;

namespace CIDM3312__FinalProject.Pages_Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly CIDM3312__FinalProject.Models.AppDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(ILogger<DetailsModel> logger, CIDM3312__FinalProject.Models.AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public Recipe Recipe { get; set; } = default!;

        [BindProperty]
        [Display(Name = "Add Ingredient to Recipe")]
        [Required(ErrorMessage = "Invalid Ingredient")]
        public int IngredientIDToAdd {get; set;}
        public SelectList IngredientsDropDown {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            IngredientsDropDown = new SelectList(_context.Ingredients.ToList(), "DefaultUnit", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(m => m.RecipeID == id);

            if (recipe is not null)
            {
                Recipe = recipe;
                return Page();
            }

            return NotFound();
            
        }

         public IActionResult OnPostAddIngredient(int? id)
        {
            _logger.LogWarning($"Add Ingredient: RecipeId {id}, ADD ingredient {IngredientIDToAdd}");

            if (id == null)
            {
                return NotFound();
            }

            var recipe = _context.Recipes.Include(r => r.RecipeIngredients!).ThenInclude(ri => ri.Ingredient).FirstOrDefault(m => m.RecipeID == id);

            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = recipe;
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Model State is INVALID");
                return Page();
            }

            if (!_context.RecipeIngredients.Any(ri => ri.IngredientID == IngredientIDToAdd && ri.RecipeID == id))
            {
                RecipeIngredient ingredientToAdd = new RecipeIngredient {RecipeID = id.Value, IngredientID = IngredientIDToAdd};
                _context.Add(ingredientToAdd);
                _context.SaveChanges();
            } else {
                _logger.LogWarning("This recipe already uses this ingredient");
            }

            return Page();
        }
    }
}
