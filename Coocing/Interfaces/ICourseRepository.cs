using Coocing.Models;
using Coocing.Repository;
using Coocing.ViewModels;

namespace Coocing.Interfaces
{
    public interface ICourseRepository
    {
        Task<CourseViewModel> GetCourseInfoAsync(int id);
        Task<List<Course>> GetCoursesByName(string name);
        Task<List<Course>> GetAllCourses();
        bool Add(Course course);
        bool Save();
    }
}
