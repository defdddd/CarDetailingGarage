using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.Model.Validator
{
    public class AppointmentValidator : AbstractValidator<AppointmentModel>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(4, 25)
                .Must(MustBeAValidName).WithMessage("Your name must not contain numbers or special caracters.");

            RuleFor(x => x.Type)
                .Cascade(CascadeMode.Stop)
                .Must(MustBeaValidType).WithMessage("The selected type does not meet the requirements.");

            RuleFor(x => x.Date)
                .Cascade(CascadeMode.Stop)
                .Must(MustBeAValidDate).WithMessage("The selected date does not meet the requirements.");

            RuleFor(x => x.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .LessThan(1250);

            RuleFor(x => x.PersonId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0);

           
        }
        private Boolean MustBeAValidName(string name)
        {
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };

            if (name.Any(char.IsDigit)) return false;
            if (name.IndexOfAny(special) >= 0) return false;

            return true;
        }
        private Boolean MustBeaValidType(string type)
        {
            if (type.ToLower() == "full" ||
                type.ToLower() == "interior" ||
                type.ToLower() == "exterior") 
                return true;
            return false;
        }
        private Boolean MustBeAValidDate(string date)
        {
            if(DateTime.Parse(date) < DateTime.Now) return false;

            return !date.Equals(default(DateTime));
        }
        
    }
}
