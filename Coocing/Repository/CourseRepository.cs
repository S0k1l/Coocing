using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;
using Coocing.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Coocing.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Course course)
        {
            _context.Add(course);
            return Save();
        }

        public async Task<CourseViewModel> GetCourseInfo(int id)
        {

            var query = await (from course in _context.Course
                               join courseRecipe in _context.CourseRecipes on course.Id equals courseRecipe.CourseId
                               join recipe in _context.Recipes on courseRecipe.RecipesId equals recipe.Id
                               where course.Id == 1
                               select new
                               {
                                   CourseName = course.Name,
                                   CourseDateTime = course.DateTime,
                                   CourseDescription = course.Description,
                                   RecipeName = recipe.Name,
                                   RecipeDescription = recipe.Description,
                                   ImageUrl = recipe.ImageUrl
                               }).FirstOrDefaultAsync();//.ToListAsync();

          //  var courses = await _context.Course.ToListAsync();


            var model = new CourseViewModel
            {
                Name = query.CourseName,




            };
            return model;

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
