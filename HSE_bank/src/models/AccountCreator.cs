using HSE_bank.models.bank;
using HSE_bank.utils;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models;

public interface AccountCreator
{
    public BankAccount GetAccountFromInput(ServiceProvider serviceProvider, int id_ = -1);
}