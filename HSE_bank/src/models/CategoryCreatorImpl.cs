using HSE_bank.models.bank;
using HSE_bank.utils;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models;

public class CategoryCreatorImpl : CategoryCreator
{
    public Category GetCategoryFromInput(ServiceProvider serviceProvider, int id_)
    {
        var id = id_ == -1 ? serviceProvider.GetService<DBCategories>()!.NewCategoryId : id_;
        var type = Helper.GetCategoryType();
        var name = Helper.GetName();
        return new Category(id, type, name);
    }
}