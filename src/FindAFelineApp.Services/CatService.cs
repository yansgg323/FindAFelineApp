using AutoMapper;
using FindAFelineApp.Data.Entities;
using FindAFelineApp.Data.Repositories;
using FindAFelineApp.Data.Repositories.Abstractions;
using FindAFelineApp.Services.Abstractions;
using FindAFelineApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Services
{
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;
        private readonly IMapper _mapper;

        public CatService(ICatRepository catRepository,
            IMapper mapper)
        {
            _catRepository = catRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CatDTO model)
        {
            var cat = _mapper.Map<Cat>(model);
            await _catRepository.AddAsync(cat);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _catRepository.DeleteByIdAsync(id);
        }

        public async Task<List<CatDTO>> GetAllAsync()
        {
            var cats = await _catRepository.GetAllAsync();
            return _mapper.Map<List<CatDTO>>(cats);
        }

        public async Task<CatDTO> GetByIdAsync(int id)
        {
            var cat = await _catRepository.GetByIdAsync(id);
            return _mapper.Map<CatDTO>(cat);
        }

        public async Task<List<CatDTO>> GetCatByBreedAsync(string breed)
        {
            var breedCats= await _catRepository.GetByFilterAsync(cat => cat.Breed == breed);
            return _mapper.Map<List<CatDTO>>(breedCats);
        }

        public async Task<List<CatDTO>> GetFeaturedAsync(int limit)
        {
            var cats = await _catRepository.GetLatestAsync(limit);
            return _mapper.Map<List<CatDTO>>(cats);
        }

        public async Task<List<CatDTO>> GetNotAdoptedAsync()
        {
            var cats = await _catRepository.GetByFilterAsync(cat => cat.AdopterId == null);
            return _mapper.Map<List<CatDTO>>(cats);
        }

        public async Task UpdateAsync(CatDTO model)
        {
            var cat = _mapper.Map<Cat>(model);
            await _catRepository.UpdateAsync(cat);
        }
    }
}
