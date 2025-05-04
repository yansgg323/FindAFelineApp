using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FindAFelineApp.Data.Entities;
using FindAFelineApp.Data.Repositories.Abstractions;
using FindAFelineApp.Services.Abstractions;
using FindAFelineApp.Services.DTOs;

namespace FindAFelineApp.Services
{
    public class FosterParentService : IFosterParentService
    {
        private readonly ICrudRepository<FosterParent> _fosterRepository;
        private readonly IMapper _mapper;

        public FosterParentService(ICrudRepository<FosterParent> fosterRepository,
            IMapper mapper)
        {
            _fosterRepository = fosterRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(FosterParentDTO firstName)
        {
            var fosterParent = _mapper.Map<FosterParent>(firstName);
            await _fosterRepository.AddAsync(fosterParent);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _fosterRepository.DeleteByIdAsync(id);
        }

        public async Task<List<FosterParentDTO>> GetAllAsync()
        {
            var fosterParents = await _fosterRepository.GetAllAsync();
            return _mapper.Map<List<FosterParentDTO>>(fosterParents);
        }

        public async Task<FosterParentDTO> GetByIdAsync(int id)
        {
            var fosterParent = await _fosterRepository.GetByIdAsync(id);
            return _mapper.Map<FosterParentDTO>(fosterParent);
        }

        public async Task<List<FosterParentDTO>> GetFosterParentByFirstNameAsync(string firstName)
        {
            var firstNameFosterParent = await _fosterRepository.GetByFilterAsync(fosterParent => fosterParent.FirstName == firstName);
            return _mapper.Map<List<FosterParentDTO>>(firstNameFosterParent);
        }

        public async Task UpdateAsync(FosterParentDTO firstName)
        {
            var fosterParent = _mapper.Map<FosterParent>(firstName);
            await _fosterRepository.UpdateAsync(fosterParent);
        }
    }
}
