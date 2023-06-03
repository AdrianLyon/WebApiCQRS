using MediatR;

namespace CQRSPractice.Infrastructure.Queries
{
    public record GetAllCategoryQuery : IRequest<IEnumerable<CategoryDto>>;
}