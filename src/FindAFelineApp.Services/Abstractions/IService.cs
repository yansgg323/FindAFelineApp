using FindAFelineApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.Abstractions
{
    public interface ICatService
    {
        Task<List<CatDTO>> GetAllAsync();
        Task<CatDTO> GetByIdAsync(int id);
        Task<List<CatDTO>> GetCarByBrandAsync(string name);
        Task AddAsync(CatDTO breed);
        Task UpdateAsync(CatDTO breed);
        Task DeleteByIdAsync(int id);
    }
}
