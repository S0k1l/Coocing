using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;

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



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
