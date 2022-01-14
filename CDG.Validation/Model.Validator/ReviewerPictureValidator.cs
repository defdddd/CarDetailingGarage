using FluentValidation;
using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.Model.Validator
{
    public class ReviewerPictureValidator : AbstractValidator<ReviewerPictureModel>
    {
        public ReviewerPictureValidator()
        {
            RuleFor(x => x.ReviewId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0);

            RuleFor(x => x.AppointmentId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0);

            RuleFor(x => x.FileName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(x => x.ImagePath)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();
        }
    }
}
