﻿using FluentValidation;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Validation.ValidatorTool
{
    public static class ValidatorTool
    {
        public static async Task FluentValidate<T>(IValidator<T> validator, T entity)
        {
            var result = await validator.ValidateAsync(entity);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
