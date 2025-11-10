using HSE_bank.consts;

namespace HSE_bank.models.bank;

public interface DBAccounts
{
    public int NewAccountId { get; }
    public Result RegisterAccount(BankAccount account);
    public void UpdateAccount(BankAccount account);
    public bool CheckAccountId(int accountId);
    public void DeleteAccount(int accountId);
    public Dictionary<int, BankAccount> GetAccounts();
}