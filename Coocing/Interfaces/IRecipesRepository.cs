using Coocing.Models;

namespace Coocing.Interfaces
{
    public interface IRecipesRepository
    {
        bool Add(Recipes recipes);
        bool Save();
    }
}
