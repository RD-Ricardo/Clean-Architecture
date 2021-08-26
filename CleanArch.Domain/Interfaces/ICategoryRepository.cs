using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetById(int? id);
        Task<Category> Create(Category model);
        Task<Category> Update(Category model);
        Task<Category> Remove(Category model);
    }
}