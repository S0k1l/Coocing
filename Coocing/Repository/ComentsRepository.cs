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

        public async Task<List<Coments>> GetAllComentsAsync(int recipeId)
        {
            var query = await (from coments in _context.Coments
                               join recipes in _context.Recipes on coments.Id equals recipes.Id    
                               join user in _context.Users on coments.AppUserId equals user.Id
                               where coments.RecipesId == recipeId
                               select new
                               {
                                   UserName = user.UserName,
                                   ComentsId = coments.Id,
                                   ComentsDescription = coments.Description,

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
