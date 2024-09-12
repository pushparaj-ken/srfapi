using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(string message, ValidationResult validationResult)
    {
            ValidationErrors.ToDictionary();
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; }
}