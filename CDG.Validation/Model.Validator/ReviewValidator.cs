using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.Model.Validator
{
    public class ReviewValidator : AbstractValidator<ReviewModel>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0);

            RuleFor(x => x.AppointmentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0);

            RuleFor(x => x.Grade)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .LessThan(11);

            RuleFor(x => x.Review)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(0, 255);

            RuleFor(x => x.IsOke)
                .Cascade(CascadeMode.Stop)
                .Must((bool isOke) => !isOke)
                .WithMessage("Your review can t be edited anymore");
        }
    }
}
