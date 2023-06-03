using AutoMapper;
using CQRSPractice.Infrastructure.Commands;
using MediatR;

namespace CQRSPractice.Application.Handlers.Category
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Category
            {
                Description = request.Description,
                CreatedDate = request.CreatedDate
            };
            _db.Categories.Add(entity);
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