using FindAFelineApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.Abstractions
{
    public interface IAdopterService
    {
        Task<List<AdopterDTO>> GetAllAsync();
        Task<AdopterDTO> GetByIdAsync(int id);
        Task<List<AdopterDTO>> GetAdopterByFirstNameAsync(string firstName);
        Task AddAsync(AdopterDTO firstName);
        Task UpdateAsync(AdopterDTO firstName);
        Task DeleteByIdAsync(int id);
    }
}