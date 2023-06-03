using CQRSPractice.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractice.Application.Handlers.Category
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDto>>
    {
        private readonly ApplicationDbContext _db;
        public GetAllCategoryHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var entity = await _db.Categories.AsNoTracking().ToListAsync(cancellationToken);

            return entity.Select(c => new CategoryDto
            {
                Id = c.Id,
                Description = c.Description,
                CreatedDate = c.CreatedDate
            });
        }
    }
}