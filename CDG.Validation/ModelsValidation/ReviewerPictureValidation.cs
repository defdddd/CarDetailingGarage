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
                ErrorMessage += "The name of the file is empty\n";
            if (IsEmpty(garagePicture.ImagePath))
                ErrorMessage += "The location of the file is empty\n";
            if (garagePicture.AppointmentId < 0)
                ErrorMessage += "Selected appointment does not exists\n";
            if (garagePicture.ReviewId < 0)
                ErrorMessage += "This person does not exits\n";

            return ErrorMessage == null;
        }
    }
}
