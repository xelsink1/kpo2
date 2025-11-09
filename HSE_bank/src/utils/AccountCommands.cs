using HSE_bank.console;
using HSE_bank.models;
using HSE_bank.models.bank;

namespace HSE_bank.utils;

public static class AccountCommands
{
    public static void Command(ref HSEBank bank)
    {
        var choice = ConsoleCommands.ShowMenu(consts.Menus.MenuSubCommandAccount);

        switch (choice)
        {
            case "Добавить счет":
                bank.RegisterAccount(GetAccountFromInput(ref bank));
                break;
            case "Отредактировать счет":
                var id = Helper.GetId();
                if (!bank.CheckAccountId(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет счета с таким id.");
                    return;
                }
                bank.UpdateAccount(GetAccountFromInput(ref bank, id));
                break;
            case "Удалить счет":
                id = Helper.GetId();
                bank.DeleteAccount(id);
                break;
        }
    }

    private static BankAccount GetAccountFromInput(ref HSEBank bank, int id_ = -1)
    {
        var id = id_ == -1 ? bank.NewAccountId : id_;
        var name = Helper.GetName();
        var balance = Helper.GetBalance();
        return new BankAccount(id, name, balance);
    }
    
}