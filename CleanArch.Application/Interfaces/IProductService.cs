

using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        //Task<ProductDTO> GetProductCategory(int?  id);
        Task<ProductDTO> GetById(int? id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task Add(ProductDTO model);
        Task Remove(int? id);
        Task Update(ProductDTO model);
    }
}