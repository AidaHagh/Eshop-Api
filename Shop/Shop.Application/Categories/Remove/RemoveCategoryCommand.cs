﻿using Common.Application;
using Shop.Domain.CategoryAgg.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Remove;

public record RemoveCategoryCommand(long CategoryId) : IBaseCommand;

public class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.DeleteCategory(request.CategoryId);
        if (result)
        {
            await _categoryRepository.Save();
            return OperationResult.Success();
        }

        return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
    }
}
