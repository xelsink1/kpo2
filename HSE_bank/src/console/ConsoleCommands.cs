using HSE_bank.consts;
using Spectre.Console;

namespace HSE_bank.console;

public static class ConsoleCommands
{
    public static string ShowMenu(string[] opts, string title = "Что вы хотите сделать?", bool flag = true)
    {
        if (flag)
        {
            opts = opts.Append("Выйти").ToArray();
        }

        Console.Clear();
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .AddChoices(opts)
        );

        return choice;
    }

    public static string GetString(string title = "")
    {
        Console.Clear();
        Console.WriteLine(title);
        
        string? input = Console.ReadLine();
        for (; input == null; input = Console.ReadLine())
        {
            Console.WriteLine("Нельзя ввести пустую строку!");
        }
        return input;
    }

    public static int GetInt(string title = "")
    {
        if (title.Length > 0)
        {
            Console.Clear();
            Console.WriteLine(title);
        }

        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Это не целое число!");
        }
        return input;
    }
    
    public static decimal GetDecimal(string title = "")
    {
        if (title.Length > 0)
        {
            Console.Clear();
            Console.WriteLine(title);
        }

        decimal input;
        while (!decimal.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Это не рациональное число!");
        }
        return input;
    }
    
    public static void WaitForEnter()
    {
        AnsiConsole.MarkupLine("[green]Нажмите Enter чтобы продолжить...[/]");
    
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
                break;
        }
    
        AnsiConsole.WriteLine();
    }
    
    public static DateOnly GetDate()
    {
        while (true)
        {
            Console.Write("Введите дату (гггг-мм-дд): ");
            string input = Console.ReadLine();

            if (DateOnly.TryParse(input, out DateOnly date))
            {
                Console.Clear();
                Console.WriteLine($"Введенная дата: {date:dd.MM.yyyy}");
                return date;
            }
            Console.Clear();
            Console.WriteLine("Неверный формат даты! Используйте формат гггг-мм-дд");
        }
    }
}