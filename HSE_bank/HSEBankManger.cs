using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank;

public class HSEBankManger(ServiceProvider serviceProvider)
{
    private ServiceProvider serviceProvider_ = serviceProvider;
    
    public void Work()
    {
        var choice = console.ConsoleCommands.ShowMenu(consts.Menus.MenuHSEBankManager);

        switch (choice)
        {
            case "":
                // ...
                console.ConsoleCommands.WaitForEnter();
                break;
            case "Выйти":
                Environment.Exit(0);
                break;
        }

    }
}