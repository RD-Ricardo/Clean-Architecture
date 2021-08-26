using System;
using Xunit;
using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Meu primeiro teste")]
        public void CreateCategory_WidthValidParameters_ResultObjectValidState()
        {
          Action action = () => new Category(1 , "Category name");
          action.Should()
            .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Teste que é para dar erro ")]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
          Action action = () => new Category(-1 , "Category name");
          action.Should()
            .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }
    }
}
