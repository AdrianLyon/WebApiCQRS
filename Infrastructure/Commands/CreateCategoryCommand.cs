using MediatR;

namespace CQRSPractice.Infrastructure.Commands
{
    public record CreateCategoryCommand(string Description, DateTime CreatedDate) : IRequest<CategoryDto>;
}