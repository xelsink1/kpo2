using HSE_bank.consts;

namespace HSE_bank.models.bank;

public class DBAccountsImpl : DBAccounts
{
    public int NewAccountId => free_account_id_++;
    
    private int free_account_id_ = 0;
    
    private HashSet<int> accounts_ = new HashSet<int>();
    private Dictionary<int, BankAccount> accounts__ = new Dictionary<int, BankAccount>();
    
    public Result RegisterAccount(BankAccount account)
    {
        if (!accounts_.Add(account.Id))
        {
            Console.WriteLine($"Аккаунт {account.Id} уже зарегистрирован!");
            return Result.Error;
        }
        
        accounts__.Add(account.Id, account);
        return Result.Ok;
    }

    public void UpdateAccount(BankAccount account)
    {
        accounts__[account.Id] = account;
    }

    public bool CheckAccountId(int accountId)
    {
        return accounts_.Contains(accountId);
    }

    public void DeleteAccount(int accountId)
    {
        accounts_.Remove(accountId);
        accounts__.Remove(accountId);
    }

    public Dictionary<int, BankAccount> GetAccounts()
    {
        return accounts__;
    }
}