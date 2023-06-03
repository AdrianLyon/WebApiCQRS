using AutoMapper;
using CQRSPractice.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractice.Application.Handlers.Category
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetCategoryByIdHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _db.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null) return null;
            return new CategoryDto{
                Id = entity.Id,
                Description = entity.Description,
                CreatedDate = entity.CreatedDate
            };
        }
    }
}