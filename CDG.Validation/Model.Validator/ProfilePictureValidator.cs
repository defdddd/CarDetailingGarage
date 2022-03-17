using CDG.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.Model.Validator
{
    public class ProfilePictureValidator : AbstractValidator<ProfilePictureModel>
    {
        public ProfilePictureValidator()
        {
            RuleFor(x => x.Image).
                Cascade(CascadeMode.Stop).
                NotEmpty();
            RuleFor(x => x.UserId).
                Cascade(CascadeMode.Stop).
                NotEmpty();

        }
    }
}
