using Models.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.ModelsValidation
{
    public static class ReviewerPictureValidation
    {
        public static string ErrorMessage { get; private set; }

        private static bool IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return true;

            return false;
        }
        public static bool CheckProperties(ReviewerPictureModel garagePicture)
        {
            ErrorMessage = null;

            if (IsEmpty(garagePicture.FileName))
                ErrorMessage += "Numele fisierului este invalid\n";
            if (IsEmpty(garagePicture.ImagePath))
                ErrorMessage += "Locatia fisierului este invalida\n";
            if (garagePicture.AppointmentId < 0)
                ErrorMessage += "Nu exista aceasta programare\n";
            if (garagePicture.ReviewId < 0)
                ErrorMessage += "Nu exista aceasta persoana\n";

            return ErrorMessage == null;
        }
    }
}
