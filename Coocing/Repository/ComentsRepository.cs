using Coocing.Data;
using Coocing.Interfaces;
using Coocing.Models;

namespace Coocing.Repository
{
    public class ComentsRepository : IComentsRepository
    {
        private readonly AppDbContext _context;

        public ComentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Coments coments)
        {
            _context.Add(coments);
            return Save();
        }



        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
