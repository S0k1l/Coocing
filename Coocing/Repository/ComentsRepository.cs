using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;
using Coocing.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Coocing.Repository
{
    public class ComentsRepository : IComentsRepository
    {
        private readonly AppDbContext _context;

        public ComentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Coments coments)
        {
            _context.Add(coments);
            return Save();
        }

        public async Task<List<Coments>> GetAllComentsAsync(int comentId)
        {
            var query = await (from coments in _context.Coments
                               join recipes in _context.Recipes on coments.Id equals recipes.Id
                               where recipes.Id == comentId
                               select new
                               {
                                   RecipesName = recipes.Name,
                                   RecipeId = recipes.Id,
                                   RecipesImageUrl = recipes.ImageUrl,
                                   ComentsId = coments.Id,
                                   ComentsDescription = coments.Description,
                                   ComentsUserId = coments.AppUserId,
                               }).ToListAsync();
            var model = await _context.Coments.ToListAsync();
            return model;
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
