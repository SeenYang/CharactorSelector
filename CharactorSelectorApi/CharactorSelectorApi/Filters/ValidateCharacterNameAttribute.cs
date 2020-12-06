using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CharactorSelectorApi.Filters
{
    /// <summary>
    ///     Here is the sample filter that could do overriding modal validation, authorization/authentication validation, etc.
    /// </summary>
    public class ValidateCharacterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // if (context.ModelState.IsValid) return;

            var exception = new FieldValidationException();

            foreach (var key in context.ModelState.Keys)
            {
                if (context.ModelState[key].ValidationState != ModelValidationState.Invalid) continue;
                var errorMessage =
                    string.IsNullOrEmpty(
                        context.ModelState[key].Errors.FirstOrDefault()?.ErrorMessage)
                        ? "Invalid Model"
                        : context.ModelState[key].Errors.FirstOrDefault()?.ErrorMessage;
                exception.FieldValidationMessages.Add(errorMessage);
            }

            throw exception;
        }
    }

    public class FieldValidationException : ValidationException
    {
        public List<string> FieldValidationMessages { get; set; }
    }
}