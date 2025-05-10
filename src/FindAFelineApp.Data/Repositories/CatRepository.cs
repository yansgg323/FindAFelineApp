using FindAFelineApp.Data.Entities;
using FindAFelineApp.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Data.Repositories
{
    public class CatRepository : CrudRepository<Cat>, ICatRepository
    {
        private ApplicationDbContext _context;
        public CatRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cat>> GetLatestAsync(int limit)
        {
            return _context.Cats
                .Where(item => item.AdopterId == null)
                .OrderByDescending(item => item.Id)
                .Take(limit);
        }
    }
}
