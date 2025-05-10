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
    public class AdopterService : IAdopterService
    {
        private readonly IAdopterRepository _adopterRepository;
        private readonly IMapper _mapper;

        public AdopterService(IAdopterRepository adopterRepository,
            IMapper mapper)
        {
            _adopterRepository = adopterRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(AdopterDTO firstName)
        {
            var adopter = _mapper.Map<Adopter>(firstName);
            await _adopterRepository.AddAsync(adopter);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _adopterRepository.DeleteByIdAsync(id);
        }

        public async Task<List<AdopterDTO>> GetAllAsync()
        {
            var adopters = await _adopterRepository.GetAllAsync();
            return _mapper.Map<List<AdopterDTO>>(adopters);
        }

        public async Task<AdopterDTO> GetByIdAsync(int id)
        {
            var adopter = await _adopterRepository.GetByIdAsync(id);
            return _mapper.Map<AdopterDTO>(adopter);
        }

        public async Task<List<AdopterDTO>> GetAdopterByFirstNameAsync(string firstName)
        {
            var firstNameAdopters = await _adopterRepository.GetByFilterAsync(adopter => adopter.FirstName == firstName);
            return _mapper.Map<List<AdopterDTO>>(firstNameAdopters);
        }

        public async Task UpdateAsync(AdopterDTO firstName)
        {
            var adopter = _mapper.Map<Adopter>(firstName);
            await _adopterRepository.UpdateAsync(adopter);
        }

        public async Task<AdopterDTO> GetByUserIdAsync(string userId)
        {
            var adopters = await _adopterRepository.GetByFilterAsync(adopter => adopter.UserId == userId);
            
            return _mapper.Map<AdopterDTO>(adopters.FirstOrDefault());
        }

        public async Task AdoptCatAsync(CatDTO catModel, AdopterDTO adopterModel)
        {
            var cat = _mapper.Map<Cat>(catModel);
            var adopter = _mapper.Map<Adopter>(adopterModel);
            await _adopterRepository.AdoptAsync(adopter.Id, cat.Id);
        }
    }
}