using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.ModelsValidation
{
    public static class AppointmentValidation
    {
        public static string ErrorMessage { get; private set; }

        private static bool IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return true;

            return false;
        }
        public static bool CheckProperties(AppointmentModel appointment)
        {
            ErrorMessage = null;

            if (IsEmpty(appointment.FullName))
                ErrorMessage += "Numele este invalid\n";
            if (IsEmpty(appointment.Type))
                ErrorMessage += "Tipul programarii este invalid\n";
            if (appointment.Price < 0)
                ErrorMessage += "Pretul este invalid\n";
            if (appointment.Date < DateTime.Now)
                ErrorMessage += "Data este invalida\n";
            if(appointment.PersonId < 0)
                ErrorMessage += "Nu exista persoana asociata\n";

            return ErrorMessage == null;
        }
    }
}
