using Coocing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coocing.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Coments> Coments { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseRecipes> CourseRecipes { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<UserCourses> RecUserCoursesipes { get; set; }
    }
}
