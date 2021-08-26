using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> CreateAsync(Product model)
        {
            _productContext.Add(model);
            await _productContext.SaveChangesAsync();
            return model;
        
        }
        public async Task<Product> UpdateAsync(Product model)
        {
           _productContext.Update(model);
            await _productContext.SaveChangesAsync();
            return model;
        }

        public async Task<Product> RemoveAsync(Product model)
        {
           _productContext.Remove(model);
            await _productContext.SaveChangesAsync();
            return model;
        }
        
        public async Task<Product> GetByIdAsync(int? id)
        {
             return await _productContext.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        // public async Task<Product> GetProductCategoryAsync(int? id)
        // {
        //     //eager loading
        //     return await _productContext.Products.Include(c => c.Category)
        //         .SingleOrDefaultAsync(p => p.Id == id);
        // }
    }
}