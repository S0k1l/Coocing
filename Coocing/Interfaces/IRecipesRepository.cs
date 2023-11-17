using Coocing.Models;
using Coocing.ViewModels;

namespace Coocing.Interfaces
{
    public interface IRecipesRepository
    {
        Task<List<Recipes>> GetAllRecipesAsync();
        Task<RecipesViewModel> GetRecipesInfoAsync(int id);
        bool Add(Recipes recipes);
        bool Save();
    }
}
