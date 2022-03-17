using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.Model.Validator
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(4, 25);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(4, 25)
                .Must(MustBeAValidPassowrd).WithMessage("The selected password does not meet the requirements.");
            
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(4,25)
                .Must(MustBeAValidName).WithMessage("Your name must not contain numbers or special caracters.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(4, 25)
                .EmailAddress();

            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(6, 12)
                .Must(MustBeAValidePhoneNumber).WithMessage("Invalid phone number");

            RuleFor(x => x.Gender)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .Must(MustBeaValidType).WithMessage("Invalid gender");
        }

        private Boolean MustBeAValidPassowrd(string passWord)
          {
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=','-' }; 

            if (!passWord.Any(char.IsUpper)) return false;

            if (!passWord.Any(char.IsLower)) return false;

            if (!passWord.Any(char.IsDigit)) return false;

            if (passWord.IndexOfAny(special) == -1) return false;

            return true;
          }

        private Boolean MustBeAValidName(string name)
        {
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '-' };

            if (name.Any(char.IsDigit)) return false;
            if (name.IndexOfAny(special) >= 0) return false;

            return true;
        }

        private Boolean MustBeAValidePhoneNumber(string phone)
        {
            if(phone.Any(char.IsLetter)) return false;
            return true;
        }
        private Boolean MustBeaValidType(string type)
        {
            if (type.ToLower() == "male" || type.ToLower() == "female" )
                return true;
            return false;
        }
    }
}

