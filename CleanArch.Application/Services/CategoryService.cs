using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;   
        }
        public async Task Add(CategoryDTO model)
        {
            var result = _mapper.Map<Category>(model);
            await _categoryRepository.Create(result);
        }
        public async Task Update(CategoryDTO model)
        {
            var result = _mapper.Map<Category>(model);
            await _categoryRepository.Update(result); 
        }
        public async Task Remove(int? id)
        {
            var result =  _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(result);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var result =  await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var result = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }


    }
}