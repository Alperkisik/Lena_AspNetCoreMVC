using Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Forms.Validation
{
    internal sealed class FormValidator: AbstractValidator<Form>
    {
        public FormValidator()
        {
            RuleFor(form => form.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 50).WithMessage("Name must be between 1 and 50 characters.");

            RuleFor(form => form.Description)
                .MaximumLength(50).WithMessage("Description cannot exceed 50 characters.");

            RuleFor(form => form.CreatedBy)
                .GreaterThan(0).WithMessage("CreatedBy must be a positive integer.");

            RuleFor(form => form.Fields)
                .NotNull().WithMessage("Fields cannot be null.")
                .Must(fields => fields.Count > 0).WithMessage("At least one field is required.")
                .ForEach(field => {
                    field.SetValidator(new InlineValidator<FormField>
                    {
                        v => v.RuleFor(f => f.Name)
                            .NotEmpty().WithMessage("Field name is required.")
                            .Length(1, 50).WithMessage("Field name must be between 1 and 50 characters."),
                        v => v.RuleFor(f => f.DataType)
                            .NotEmpty().WithMessage("DataType is required.")
                            .Length(1, 50).WithMessage("DataType must be between 1 and 50 characters.")
                            .Must(dataType => new[] { "STRING", "NUMBER" }.Contains(dataType)).WithMessage("DataType must be one of the following: STRING, NUMBER.")
                    });
                });
        }
    }
}
