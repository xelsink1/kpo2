using HSE_bank.console;
using HSE_bank.models;
using HSE_bank.models.bank;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.utils;

public static class AccountCommands
{
    public static void Command(ServiceProvider serviceProvider)
    {
        var choice = ConsoleCommands.ShowMenu(consts.Menus.MenuSubCommandAccount);

        switch (choice)
        {
            case "Добавить счет":
                serviceProvider.GetService<DBAccounts>()!.RegisterAccount(
                    serviceProvider.GetService<AccountCreator>()!.GetAccountFromInput(serviceProvider)
                    );
                break;
            case "Отредактировать счет":
                var id = Helper.GetId();
                if (!serviceProvider.GetService<DBAccounts>()!.CheckAccountId(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет счета с таким id.");
                    return;
                }
                Console.WriteLine("Введите новые данные счета.");
                serviceProvider.GetService<DBAccounts>()!.UpdateAccount(
                    serviceProvider.GetService<AccountCreator>()!.GetAccountFromInput(serviceProvider, id)
                    );
                break;
            case "Удалить счет":
                id = Helper.GetId();
                serviceProvider.GetService<DBAccounts>()!.DeleteAccount(id);
                break;
        }
    }
    
}