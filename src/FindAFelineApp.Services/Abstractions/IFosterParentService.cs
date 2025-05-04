using FindAFelineApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services.Abstractions
{
    public interface IFosterParentService
    {
        Task<List<FosterParentDTO>> GetAllAsync();
        Task<FosterParentDTO> GetByIdAsync(int id);
        Task<List<FosterParentDTO>> GetFosterParentByFirstNameAsync(string firstName);
        Task AddAsync(FosterParentDTO firstName);
        Task UpdateAsync(FosterParentDTO firstName);
        Task DeleteByIdAsync(int id);
    }
}
