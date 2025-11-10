using HSE_bank.consts;
using HSE_bank.models;

namespace HSE_bank.utils;

using HSE_bank.console;

public static class Helper
{
    public static int GetId(string ext = "")
    {
        while (true)
        {
            var id = ConsoleCommands.GetInt("Введите id" + ext);
            if (id >= 0)
            {
                return id;
            }
            Console.Clear();
            Console.WriteLine("Id должен быть >= 0");
        }
    }

    public static decimal GetAmount()
    {
        while (true)
        {
            var amount = ConsoleCommands.GetDecimal("Введи сумму операции.");
            if (amount >= 0)
            {
                return amount;
            }
            Console.Clear();
            Console.WriteLine("Amount должен быть >= 0");
        }
    }

    public static decimal GetBalance()
    {
        while (true)
        {
            var balance = ConsoleCommands.GetDecimal("Введи баланс.");
            if (balance >= 0)
            {
                return balance;
            }
            Console.Clear();
            Console.WriteLine("Balance должен быть >= 0");
        }
    }
    
    public static string GetName()
    {
        return ConsoleCommands.GetString("Введи имя.");
    }

    public static CategoryType GetCategoryType()
    {
        var choise = ConsoleCommands.ShowMenu([
            "Доход",
            "Расход"
        ], "Какой тип категории?", false);
        
        return choise == "Доход" ? CategoryType.Income : CategoryType.Consumption;
    }

    public static OperationType GetOperationType()
    {
        var choise = ConsoleCommands.ShowMenu([
            "Доход",
            "Расход"
        ], "Какой тип операции?", false);
        
        return choise == "Доход" ? OperationType.Income : OperationType.Consumption;
    }

    public static DateOnly GetDate()
    {
        return ConsoleCommands.GetDate();
    }
}