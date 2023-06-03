using MediatR;

namespace CQRSPractice.Infrastructure.Queries
{
    public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;
}