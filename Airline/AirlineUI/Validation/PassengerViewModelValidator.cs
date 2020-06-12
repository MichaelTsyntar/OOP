using AirlineUI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineUI.Validation
{
    public class PassengerViewModelValidator: AbstractValidator<PassengerViewModel>
    {
        public PassengerViewModelValidator()
        {

            RuleFor(e => e.name)
                .NotEmpty().WithMessage("The Name cannot be empty")
                .MaximumLength(20).WithMessage("The Name cannot be longer than 20 characters");
               
            RuleFor(e => e.lastName)
                .NotEmpty().WithMessage("The LastName cannot be empty")
                .MaximumLength(20).WithMessage("The LastName cannot be longer than 20 characters");
        }
    }
}
