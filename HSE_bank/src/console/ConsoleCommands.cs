using Spectre.Console;

namespace HSE_bank.console;

public static class ConsoleCommands
{
    public static string ShowMenu(string[] opts, string title = "Что вы хотите сделать?")
    {
        opts = opts.Append("Выйти").ToArray();
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
}