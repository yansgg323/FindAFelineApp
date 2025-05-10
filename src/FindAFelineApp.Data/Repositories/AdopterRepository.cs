using FindAFelineApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Data.Repositories
{
    public class AdopterRepository : CrudRepository<Adopter>, IAdopterRepository
    {
        private ApplicationDbContext _context;
        public AdopterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AdoptAsync(int adopterId, int catId)
        {
            var adopter = _context.Adopters.Find(adopterId);
            if(adopter != null)
            {
                var cat = _context.Cats.Find(catId);
                if(cat != null)
                {
                    cat.Adopter = adopter;
                    _context.Cats.Update(cat);
                    _context.SaveChangesAsync();
                }
            }
        }
    }
}
