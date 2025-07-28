using Ticketly.Modules.Events.Application.Abstractions.Data;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Domain.Categories;
using System.Threading;
using System.Threading.Tasks;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;

namespace Ticketly.Modules.Events.Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCategoryCommand>
{
    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure(CategoryErrors.NotFound(request.CategoryId));
        }

        category.ChangeName(request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
