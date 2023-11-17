using Coocing.Models;
using Coocing.ViewModels;

namespace Coocing.Interfaces
{
    public interface IComentsRepository
    {
        Task<List<ComentsViewModel>> GetAllComentsAsync(int recipeId);
        bool Add(Coments coments);
        bool Save();
    }
}
