using HSE_bank.consts;

namespace HSE_bank.models;

public class Operation
{
    public int Id => id_;
    public OperationType Type => type_;
    public BankAccount? BankAccountId => bank_account_id_;
    public decimal Amount => amount_;
    public DateTime Date => date_;
    public string Description => description_;
    public Category? CategoryId => category_id_;
    
    private int id_;
    private OperationType type_;
    private BankAccount? bank_account_id_ = null;
    private decimal amount_;
    private DateTime date_;
    private string description_;
    private Category? category_id_;
}
