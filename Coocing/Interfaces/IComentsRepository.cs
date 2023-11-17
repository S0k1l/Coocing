using Coocing.Models;

namespace Coocing.Interfaces
{
    public interface IComentsRepository
    {
        Task<List<Coments>> GetAllComentsAsync(int comentId);
        bool Add(Coments coments);
        bool Save();
    }
}
