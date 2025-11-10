using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.utils;

using HSE_bank.console;
using HSE_bank.models;
using HSE_bank.models.bank;

public static class CategoryCommands
{
    public static void Command(ServiceProvider serviceProvider)
    {
        var choice = ConsoleCommands.ShowMenu(consts.Menus.MenuSubCommandCategory);

        switch (choice)
        {
            case "Добавить категорию":
                serviceProvider.GetService<DBCategories>()!.RegisterCategory(
                    serviceProvider.GetService<CategoryCreator>()!.GetCategoryFromInput(serviceProvider)
                    );
                break;
            case "Отредактировать категорию":
                var id = Helper.GetId();
                if (!serviceProvider.GetService<DBCategories>()!.CheckCategoryId(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет категории с таким id.");
                    return;
                }
                Console.WriteLine("Введите новые данные категории.");
                serviceProvider.GetService<DBCategories>()!.UpdateCategory(
                    serviceProvider.GetService<CategoryCreator>()!.GetCategoryFromInput(serviceProvider, id)
                    );
                break;
            case "Удалить категорию":
                id = Helper.GetId();
                serviceProvider.GetService<DBCategories>()!.DeleteCategory(id);
                break;
        }
    }
}