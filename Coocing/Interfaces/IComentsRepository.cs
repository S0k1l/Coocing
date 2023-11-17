using Coocing.Models;

namespace Coocing.Interfaces
{
    public interface IComentsRepository
    {
        bool Add(Coments coments);
        bool Save();
    }
}
