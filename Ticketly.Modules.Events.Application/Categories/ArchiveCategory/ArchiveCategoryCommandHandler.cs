﻿using Ticketly.Modules.Events.Application.Abstractions.Data;
using Ticketly.Modules.Events.Domain.Abstractions;
using Ticketly.Modules.Events.Domain.Categories;
using Ticketly.Modules.Events.Application.Abstractions.Messaging;
using System.Threading.Tasks;
using System.Threading;

namespace Ticketly.Modules.Events.Application.Categories.ArchiveCategory;

internal sealed class ArchiveCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<ArchiveCategoryCommand>
{
    public async Task<Result> Handle(ArchiveCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Failure(CategoryErrors.NotFound(request.CategoryId));
        }

        if (category.IsArchived)
        {
            return Result.Failure(CategoryErrors.AlreadyArchived);
        }

        category.Archive();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
