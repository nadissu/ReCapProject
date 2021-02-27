using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.ModelYear).NotEmpty();
            RuleFor(c=>c.Description).MinimumLength(2);
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Price).GreaterThanOrEqualTo(10).When(c=> c.BrandId == 1);
            RuleFor(c=>c.Description).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
