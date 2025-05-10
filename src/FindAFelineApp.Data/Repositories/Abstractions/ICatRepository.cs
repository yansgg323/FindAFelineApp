using FindAFelineApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Data.Repositories.Abstractions
{
    public interface ICatRepository : ICrudRepository<Cat>
    {
    }
}
