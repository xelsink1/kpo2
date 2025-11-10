using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models;

public interface CategoryCreator
{
    public Category GetCategoryFromInput(ServiceProvider serviceProvider, int id_ = -1);
}