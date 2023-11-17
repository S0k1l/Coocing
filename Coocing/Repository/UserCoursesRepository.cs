using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;

namespace Coocing.Repository
{
    public class UserCoursesRepository : IUserCoursesRepository
    {
        private readonly AppDbContext _context;

        public UserCoursesRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(UserCourses userCourses)
        {
            _context.Add(userCourses);
            return Save();
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
