using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.ModelsValidation
{
    public static class ReviewValidation
    {
        public static string ErrorMessage { get; private set; }

        private static bool IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return true;

            return false;
        }

        public static bool CheckProperties(ReviewModel review)
        {
            ErrorMessage = null;

            if (review.Grade <= 0 || review.Grade > 10)
                ErrorMessage += "Nota este invalida\n";
            if (IsEmpty(review.Review))
                ErrorMessage += "Review ul este invalid\n";
            if (review.UserId < 0)
                ErrorMessage += "Acest utilizator nu exista\n";

            return ErrorMessage == null;
        }
    }
}
