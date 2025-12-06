using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM3312__FinalProject.Models;

namespace CIDM3312__FinalProject.Pages_Recipes
{
    public class IndexModel : PageModel
    {
        private readonly CIDM3312__FinalProject.Models.AppDbContext _context;

        public IndexModel(CIDM3312__FinalProject.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;
        public int TotalPages {get; set;}

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;

        // Search support
        [BindProperty(SupportsGet = true)]
        public string CurrentSearch {get; set;} = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Recipes.Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient).Select(r => r);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(r => r.Title.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            switch (CurrentSort)
            {
                case "title_asc":
                    query = query.OrderBy(r => r.Title);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(r => r.Title);
                    break;
            }

            TotalPages = (int)Math.Ceiling(_context.Recipes.Count() / (double)PageSize);
    
            Recipe = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
