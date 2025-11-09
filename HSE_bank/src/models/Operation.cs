using HSE_bank.consts;

namespace HSE_bank.models;

public class Operation(int id, OperationType type, int bank_account_id, decimal amount, DateOnly date, int category_id)
{
    public int Id => id;
    public OperationType Type => type;
    public int BankAccountId => bank_account_id;
    public decimal Amount => amount;
    public DateOnly Date => date;
    public int CategoryId => category_id;
}
