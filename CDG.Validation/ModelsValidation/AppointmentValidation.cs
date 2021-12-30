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
                ErrorMessage += "Invalid name\n";
            if (IsEmpty(appointment.Type))
                ErrorMessage += "Invalid Type\n";
            if (appointment.Price < 0)
                ErrorMessage += "Invalid price\n";
            if (appointment.Date < DateTime.Now)
                ErrorMessage += "Invalid Date\n";
            if(appointment.PersonId < 0)
                ErrorMessage += "Invalid Person\n";
            if (appointment.IsDone)
                ErrorMessage += "Appointment done, you can't edit or insert";

            return ErrorMessage == null;
        }
    }
}
