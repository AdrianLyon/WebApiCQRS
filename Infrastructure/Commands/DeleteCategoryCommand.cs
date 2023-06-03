using MediatR;

namespace CQRSPractice.Infrastructure.Commands
{
    public record DeleteCategoryCommand(int Id) : IRequest<bool>;
}