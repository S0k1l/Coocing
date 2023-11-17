using Coocing.Models;

namespace Coocing.Interfaces
{
    public interface IUserCoursesRepository
    {
        bool Add(UserCourses userCourses);
        bool Save();
    }
}
