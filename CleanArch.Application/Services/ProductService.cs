

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ProductDTO> GetById(int? id)
         {
            var productId = new GetProductsByIdQuery(id.Value);

            if(productId == null)
            {
                throw new System.Exception("Error get Id");
            }

            var result = await _mediator.Send(productId);

            return _mapper.Map<ProductDTO>(result);
         }
        // public async  Task<ProductDTO> GetProductCategory(int? id)
        //  {
        //     var productId = new GetProductsByIdQuery(id.Value);

        //     if(productId == null)
        //     {
        //         throw new System.Exception("Error get Id category");
        //     }

        //     var result = await _mediator.Send(productId);

        //     return _mapper.Map<ProductDTO>(result);
        //  }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
             //var result = await _productRepository.GetProductAsync();
             //return _mapper.Map<IEnumerable<ProductDTO>>(result);

             var productQuery = new GetProductsQuery();

             if(productQuery == null)
             {
                 throw new System.Exception($"Entity could not be loaded");
             }

             var result = await _mediator.Send(productQuery);

             return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }
        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

           if(productRemoveCommand == null)
           {
               throw new System.Exception($"Enitty could not be loaded");
           }
           await _mediator.Send(productRemoveCommand);
        }
         public async Task Update(ProductDTO model)
         {
            var product =  _mapper.Map<ProductCreateCommand>(model);
            await _mediator.Send(product);
         }
        public async Task Add(ProductDTO model)
        {
             var product =  _mapper.Map<ProductCreateCommand>(model);
             await _mediator.Send(product);
        }
    }
}