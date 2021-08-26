using System.Collections.Generic;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}