using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id );
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();


            builder.HasData(
                new Category(1 , "Material Escolar"),
                new Category(2 , "eletronicos"),
                new Category(3 , "Acessorios")
            );
        }
    }
}