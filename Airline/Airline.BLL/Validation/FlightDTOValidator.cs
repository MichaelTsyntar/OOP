using Airline.DAL.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.BLL.Validation
{
    public class FlightDTOValidator : AbstractValidator<Flight>
    {
        public FlightDTOValidator()
        {
            RuleFor(e => e.Froms)
                .NotEmpty().WithMessage("The Name cannot be empty")
                .MaximumLength(50).WithMessage("The Name cannot be longer than 50 characters");
            RuleFor(e => e.Wheres)
                .NotEmpty().WithMessage("The Name cannot be empty")
                .MaximumLength(50).WithMessage("The Name cannot be longer than 50 characters");
            RuleFor(e => e.Airlines)
               .NotEmpty().WithMessage("The Name cannot be empty")
               .MaximumLength(50).WithMessage("The Name cannot be longer than 50 characters");
        }
    }
}
