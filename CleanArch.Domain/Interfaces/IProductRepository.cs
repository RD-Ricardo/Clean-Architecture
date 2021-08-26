using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetByIdAsync(int? id);
        //Task<Product> GetProductCategoryAsync(int? id );
        Task<Product> CreateAsync(Product model);
        Task<Product> UpdateAsync(Product model);
        Task<Product> RemoveAsync(Product model);
        
    }
}