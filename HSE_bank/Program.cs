// See https://aka.ms/new-console-template for more information

using HSE_bank;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var services = new ServiceCollection();

using ServiceProvider serviceProvider = services.BuildServiceProvider();

HSEBankManger hsebank_manager = new HSEBankManger(serviceProvider);

AnsiConsole.WriteLine("Приветствую в HSE банке!\n\n");
Thread.Sleep(3500);

while (true)
{
    hsebank_manager.Work();
}