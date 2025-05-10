using FindAFelineApp.Data.Entities;
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
        Task<List<CatDTO>> GetFeaturedAsync(int limit);
        Task<List<CatDTO>> GetAllAsync();
        Task<CatDTO> GetByIdAsync(int id);
        Task<List<CatDTO>> GetCatByBreedAsync(string breed);
        Task AddAsync(CatDTO model);
        Task UpdateAsync(CatDTO model);
        Task DeleteByIdAsync(int id);
    }
}
