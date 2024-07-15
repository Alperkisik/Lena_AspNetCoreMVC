using Domain.Common;
using Domain.Dtos;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly DatabaseContext dbContext;

        public FormRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> AddFormAsync(Form form, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(form.Description)) form.Description = string.Empty;

            try
            {
                await dbContext.AddAsync(form);

                await dbContext.SaveChangesAsync(cancellationToken);


                foreach (var field in form.Fields)
                {
                    field.FormId = form.Id;
                }

                return Result.Success(form);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<IEnumerable<Form>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext
                .Forms
                //.Include(form => form.Fields)
                .ToListAsync(cancellationToken);
        }

        public async Task<Form?> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await dbContext
                .Forms
                .Where(form => form.Id == Id)
                .Include(form => form.Fields)
                .FirstOrDefaultAsync(cancellationToken);
        }

    }
}
