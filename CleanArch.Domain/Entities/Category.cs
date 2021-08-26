using System.Collections.Generic;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string  Name { get; private set; }

        public Category(string name )
        {
            ValidationDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0 , "Invalid Id Value");
            Id = id;
            ValidationDomain(name);
        }
        public ICollection<Product> Products { get; set; }

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(name.Length < 3,
                 "Invalid name, too short , minimum 3 charecters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                 "Invalid name"); 


            Name = name;           
        }
    }
}