using HSE_bank.console;
using HSE_bank.models;
using HSE_bank.models.bank;

namespace HSE_bank.utils;

public class OperationCommands
{
    public static void Command(ref HSEBank bank)
    {
        var choice = ConsoleCommands.ShowMenu(consts.Menus.MenuSubCommandOperation);

        switch (choice)
        {
            case "Добавить операцию":
                var operation = GetOperationFromInput(ref bank);
                if (!bank.CheckAccountId(operation.BankAccountId))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет счета с таким id.");
                    return;
                }
                if (!bank.CheckCategoryId(operation.BankAccountId))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет категории с таким id.");
                    return;
                }
                bank.UpdateOperation(operation);
                break;
            case "Отредактировать операцию":
                var id = Helper.GetId();
                if (!bank.CheckAccountId(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка, нет операции с таким id.");
                    return;
                }
                bank.UpdateOperation(GetOperationFromInput(ref bank, id));
                break;
            case "Удалить операцию":
                id = Helper.GetId();
                bank.DeleteOperation(id);
                break;
        }
    }

    private static Operation GetOperationFromInput(ref HSEBank bank, int id_ = -1)
    {
        var id = id_ == -1 ? bank.NewOperationId : id_;
        var type = Helper.GetOperationType();
        var bank_account_id = Helper.GetId();
        var amount = Helper.GetAmount();
        var date = Helper.GetDate();
        var category_id = Helper.GetId();
        return new Operation(id, type, bank_account_id, amount, date, category_id);
    }
}