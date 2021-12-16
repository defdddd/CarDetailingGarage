using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.ModelsValidation
{
    public static class PersonValidation
    {
        public static string ErrorMessage { get; private set; }

        private static bool IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return true;

            return false;
        }
        private static bool IsNotValidEmail(string source)
        {
            return ! new EmailAddressAttribute().IsValid(source);
        }

        public static bool CheckProperties(PersonModel person)
        {
            ErrorMessage = null;

            if (IsEmpty(person.Name))
                ErrorMessage += "Numele este invalid\n";
            if (IsEmpty(person.Password))
                ErrorMessage += "Parola este invalida\n";
            if (IsEmpty(person.UserName))
                ErrorMessage += "Numele de utilizator este invalid\n";
            if (IsEmpty(person.Phone) || person.Phone.Length != 10)
                ErrorMessage += "Telefonul este invalid\n";
            if (IsEmpty(person.Email) || IsNotValidEmail(person.Email))
                ErrorMessage += "Emailul este invalid\n";

            return ErrorMessage == null;
        }

    }
}
