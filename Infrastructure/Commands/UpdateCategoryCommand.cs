using MediatR;

namespace CQRSPractice.Infrastructure.Commands
{
    public record UpdateCategoryCommand(int Id, string Description, DateTime CreatedDate) : IRequest<CategoryDto>;
}