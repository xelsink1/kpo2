using HSE_bank.console;
using HSE_bank.models;
using HSE_bank.models.bank;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.utils;

public static class OperationCommands
{
    public static void Command(ServiceProvider serviceProvider)
    {
        var choice = ConsoleCommands.ShowMenu(consts.Menus.MenuSubCommandOperation);

        switch (choice)
        {
            case "Добавить операцию":
                var operation = serviceProvider.GetService<OperationCreator>()!.GetOperationFromInput(serviceProvider);
                if (!serviceProvider.GetService<DBAccounts>()!.CheckAccountId(operation.BankAccountId))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет счета с таким id.");
                    return;
                }
                if (!serviceProvider.GetService<DBCategories>()!.CheckCategoryId(operation.BankAccountId))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет категории с таким id.");
                    return;
                }
                serviceProvider.GetService<DBOperations>()!.UpdateOperation(operation);
                break;
            case "Отредактировать операцию":
                var id = Helper.GetId();
                if (!serviceProvider.GetService<DBOperations>()!.CheckOperationId(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет операции с таким id.");
                    return;
                }
                Console.Clear();
                Console.WriteLine("Введите новые данные операции.");
                serviceProvider.GetService<DBOperations>()!.UpdateOperation(
                    serviceProvider.GetService<OperationCreator>()!.GetOperationFromInput(serviceProvider, id)
                    );
                break;
            case "Удалить операцию":
                id = Helper.GetId();
                serviceProvider.GetService<DBOperations>()!.DeleteOperation(id);
                break;
        }
    }
}