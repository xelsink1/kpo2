using HSE_bank.models.bank;
using HSE_bank.utils;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models;

public class AccountCreatorImpl : AccountCreator
{
    public BankAccount GetAccountFromInput(ServiceProvider serviceProvider, int id_)
    {
        var id = id_ == -1 ? serviceProvider.GetService<DBAccounts>()!.NewAccountId : id_;
        var name = Helper.GetName();
        var balance = Helper.GetBalance();
        return new BankAccount(id, name, balance);
    }
}