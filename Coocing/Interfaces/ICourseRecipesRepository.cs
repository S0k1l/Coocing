using Coocing.Models;
using Coocing.Repository;

namespace Coocing.Interfaces
{
    public interface ICourseRecipesRepository
    {
        bool Add(CourseRecipes courseRecipes);
        bool Save();
    }
}
