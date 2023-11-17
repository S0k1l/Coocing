using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;
using Coocing.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Coocing.Repository
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly AppDbContext _context;

        public RecipesRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Recipes recipes )
        {
            _context.Add(recipes);
            return Save();
        }

        public async Task<RecipesViewModel> GetRecipesInfoAsync(int id)
        {
            var query = await (from recipes in _context.Recipes
                               where recipes.Id == id
                               select new
                               {
                                   Id = recipes.Id,
                                   Name = recipes.Name,
                                   Description = recipes.Description,
                                   ImageUrl = recipes.ImageUrl,
                               }).FirstOrDefaultAsync();
            var model = new RecipesViewModel
            {
                Id= query.Id,
                Name = query.Name,
                Description = query.Description,
                ImageUrl = query.ImageUrl,
            };
            return model;

        }
        public async Task<List<Recipes>> GetAllRecipesAsync()
        {
            var query = await (from recipe in _context.Recipes
                               select new
                               {
                                   Id = recipe.Id,
                                   Name = recipe.Name,
                                   Description = recipe.Description,
                                   ImageUrl = recipe.ImageUrl,
                               }).ToListAsync();

            var model = await _context.Recipes.ToListAsync();
            return model;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
