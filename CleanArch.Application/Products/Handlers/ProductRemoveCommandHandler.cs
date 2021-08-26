using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
         private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository reposito)
        {
            _productRepository = reposito ?? throw new ArgumentNullException(nameof(reposito));
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if(product == null)
            {
                throw new ApplicationException($"Enity could not be found.");
            }
            else
            {
                var result  = await _productRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}