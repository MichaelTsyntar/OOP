using Airline.DAL.Entities;

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.BLL.Validation
{
  public  class PassengerDTOValidator : AbstractValidator<Passenger>
    {
        public PassengerDTOValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("The Name cannot be empty")
                .MaximumLength(20).WithMessage("The Name cannot be longer than 20 characters");
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("The LastName cannot be empty")
                .MaximumLength(20).WithMessage("The LastName cannot be longer than 20 characters");
        }
    }

}
