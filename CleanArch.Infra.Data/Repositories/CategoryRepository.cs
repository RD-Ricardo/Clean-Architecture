using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }
        public async Task<Category> Create(Category model)
        {
            _categoryContext.Add(model);
            await _categoryContext.SaveChangesAsync();
            return model;
        }
        public async Task <Category> Update(Category model)
        {
            _categoryContext.Categories.Update(model);
           await _categoryContext.SaveChangesAsync();
           return model;
        }
        public async Task<Category> Remove(Category model)
        {
           _categoryContext.Categories.Remove(model);
           await _categoryContext.SaveChangesAsync();
           return model;
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);   
        }

        public async  Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }


        
    }
}