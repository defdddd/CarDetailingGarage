using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.ModelsValidation
{
    public static class GaragePictureValidation
    {
        public static string ErrorMessage { get; private set; }

        private static bool IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return true;

            return false;
        }
        public static bool CheckProperties(GaragePictureModel garagePicture)
        {
            ErrorMessage = null;

            if (IsEmpty(garagePicture.FileName))
                ErrorMessage += "The name of the file is invalid\n";
            if (IsEmpty(garagePicture.ImagePath))
                ErrorMessage += "The location of the file is invalid\n";
            if (garagePicture.AppointmentId < 0)
                ErrorMessage += "The selected appointment does not exists\n";

            return ErrorMessage == null;
        }
    }
}
