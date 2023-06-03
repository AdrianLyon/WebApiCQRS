using CQRSPractice.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractice.Application.Handlers.Category
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ApplicationDbContext _db;
        public DeleteCategoryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity == null) return false;
            _db.Categories.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}