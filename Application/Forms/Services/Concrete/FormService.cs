using Application.Forms.Services.Abstract;
using Application.Forms.Validation;
using Domain.Common;
using Domain.Dtos;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Forms.Services.Concrete
{
    public sealed class FormService : IFormService
    {
        private readonly IFormRepository formRepository;
        private readonly FormValidator validator;

        public FormService(IFormRepository formRepository)
        {
            this.formRepository = formRepository;
            validator = new FormValidator();
        }

        public async Task<IEnumerable<Form>> GetAllForms(CancellationToken cancellationToken)
        {
            return await formRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Form?> GetFormById(int Id, CancellationToken cancellationToken)
        {
            return await formRepository.GetByIdAsync(Id, cancellationToken);
        }

        public async Task<Result> AddFormAsync(Form form, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(form, cancellationToken);

            if (!validationResult.IsValid)
                return Result.Failure(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));

            return await formRepository.AddFormAsync(form, cancellationToken);
        }
    }
}
