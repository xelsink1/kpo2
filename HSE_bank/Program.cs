// See https://aka.ms/new-console-template for more information

using HSE_bank;
using HSE_bank.models;
using HSE_bank.models.bank;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var services = new ServiceCollection()
    .AddSingleton<DBAccounts, DBAccountsImpl>()
    .AddSingleton<DBCategories, DBCategoriesImpl>()
    .AddSingleton<DBOperations, DBOperationsImpl>()
    .AddSingleton<AccountCreator, AccountCreatorImpl>()
    .AddSingleton<CategoryCreator, CategoryCreatorImpl>()
    .AddSingleton<OperationCreator, OperationCreatorImpl>();

using ServiceProvider serviceProvider = services.BuildServiceProvider();

HSEBankManger hsebank_manager = new HSEBankManger(serviceProvider);

AnsiConsole.WriteLine("Приветствую в HSE банке!\n\n");
Thread.Sleep(3500);

while (true)
{
    hsebank_manager.Work();
}