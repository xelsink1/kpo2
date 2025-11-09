using HSE_bank.models.bank;
using HSE_bank.utils;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank;

public class HSEBankManger(ServiceProvider serviceProvider)
{
    private ServiceProvider serviceProvider_ = serviceProvider;
    private HSEBank bank_ = new HSEBank(serviceProvider);
    
    public void Work()
    {
        var choice = console.ConsoleCommands.ShowMenu(consts.Menus.MenuHSEBankManager);

        switch (choice)
        {
            case "Редактирование счетов":
                AccountCommands.Command(ref bank_);
                console.ConsoleCommands.WaitForEnter();
                break;
            case "Редактирование категорий":
                CategoryCommands.Command(ref bank_);
                console.ConsoleCommands.WaitForEnter();
                break;
            case "Редактирование операций":
                OperationCommands.Command(ref bank_);
                console.ConsoleCommands.WaitForEnter();
                break;
            case "Выйти":
                Environment.Exit(0);
                break;
        }

    }
}