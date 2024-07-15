using Domain.Common;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Forms.Services.Abstract
{
    public interface IFormService
    {
        Task<IEnumerable<Form>> GetAllForms(CancellationToken cancellationToken);
        Task<Form?> GetFormById(int Id, CancellationToken cancellationToken);
        Task<Result> AddFormAsync(Form form, CancellationToken cancellationToken);
    }
}
