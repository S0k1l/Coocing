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

        public async Task<List<Course>> GetAllCourses()
        {
         var courses = await _context.Course.ToListAsync();
            return courses;
        }

        public async Task<List<Course>> GetCoursesByName(string name)
        {
            var courses = await _context.Course.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            return courses;
        }
        public async Task<CourseViewModel> GetCourseInfoAsync(int id)
        {

            var courses = await _context.Course
                .Where(course => course.Id == id).FirstOrDefaultAsync();
            var recipes = await _context.CourseRecipes
                        .Take(1000)
                        .Select(cr => new Recipes
                        {
                            Id = cr.Recipes.Id,
                            Name = cr.Recipes.Name,
                            Description = cr.Recipes.Description,
                            ImageUrl = cr.Recipes.ImageUrl
                        })
                        .ToListAsync();

            var model = new CourseViewModel{ 
                Id = courses.Id,
                Name = courses.Name,
                Description = courses.Description,
                DateTime = courses.DateTime,
                Recipes = recipes
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
