using Coocing.Models;
using Coocing.Repository;

namespace Coocing.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesByName(string name);
        Task<List<Course>> GetAllCourses();
        bool Add(Course course);
        bool Save();
    }
}
