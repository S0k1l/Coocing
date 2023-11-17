using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;
using Microsoft.EntityFrameworkCore;

namespace Coocing.Repository
{
    public class CourseRecipesRepository:ICourseRecipesRepository
    {
        private readonly AppDbContext _context;

        public CourseRecipesRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(CourseRecipes courseRecipes)
        {
            _context.Add(courseRecipes);
            return Save();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
