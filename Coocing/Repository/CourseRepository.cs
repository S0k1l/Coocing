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
        public async Task<Course> GetCourseInfoAsync(int id)
        {

            var query = await (from course in _context.Course
                               where course.Id == id
                               select new
                               {
                                   Id = course.Id,
                                   Name = course.Name,
                                   DateTime = course.DateTime,
                                   Description = course.Description,
                               }).FirstOrDefaultAsync();

            var model = new Course
            {
                Id = query.Id,
                Name = query.Name,
                DateTime = query.DateTime,
                Description = query.Description,
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
