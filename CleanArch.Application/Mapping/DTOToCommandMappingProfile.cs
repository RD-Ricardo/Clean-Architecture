using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;

namespace CleanArch.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {

        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductCreateCommand, ProductDTO>();
        }
        
    }
}