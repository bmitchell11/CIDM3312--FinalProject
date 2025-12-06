using Microsoft.EntityFrameworkCore;
namespace CIDM3312__FinalProject.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    // Needed for Many-to-Many association entity
    // StudentCourse entity has 2 attributes as the primary key.
    // This code tells EF Core that StudentID and CourseID combine for the primary key
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeIngredient>().HasKey(r => new {r.RecipeID, r.IngredientID});
    }

    public DbSet<Recipe> Recipes {get; set;}
    public DbSet<Ingredient> Ingredients {get; set;}
    public DbSet<RecipeIngredient> RecipeIngredients {get; set;}
}