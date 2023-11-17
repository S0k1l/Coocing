using Coocing.Models;
using Coocing.Repository;

namespace Coocing.Interfaces
{
    public interface ICourseRepository
    {
        bool Add(Course course);
        bool Save();
    }
}
