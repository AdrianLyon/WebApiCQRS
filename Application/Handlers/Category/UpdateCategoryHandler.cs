using CQRSPractice.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractice.Application.Handlers.Category
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ApplicationDbContext _db;
        public UpdateCategoryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null) return null;

            entity.Description = request.Description;
            entity.CreatedDate = request.CreatedDate;
            await _db.SaveChangesAsync(cancellationToken);
            return new CategoryDto
            {
                Id = entity.Id,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate
            };
        }
    }
}