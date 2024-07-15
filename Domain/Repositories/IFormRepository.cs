using Domain.Common;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFormRepository
    {
        Task<IEnumerable<Form>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Form?> GetByIdAsync(int Id, CancellationToken cancellationToken = default);
        Task<Result> AddFormAsync(Form form, CancellationToken cancellationToken = default);
    }
}