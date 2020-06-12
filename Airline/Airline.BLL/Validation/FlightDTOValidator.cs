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
                .NotEmpty().WithMessage("The Froms cannot be empty")
                .MaximumLength(20).WithMessage("The Froms cannot be longer than 20 characters");
            RuleFor(e => e.Wheres)
                .NotEmpty().WithMessage("The Wheres cannot be empty")
                .MaximumLength(20).WithMessage("The Wheres cannot be longer than 20 characters");
            RuleFor(e => e.Airlines)
               .NotEmpty().WithMessage("The Airlines cannot be empty")
               .MaximumLength(20).WithMessage("The Airlines cannot be longer than 20 characters");
        }
    }
}
