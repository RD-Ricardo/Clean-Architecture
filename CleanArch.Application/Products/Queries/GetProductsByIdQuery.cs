using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductsByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductsByIdQuery(int id)
        {
            Id = id;
        }
    }
}