namespace HSE_bank.models;

public class BankAccount(int id, string name, decimal balance)
{
    public int Id => id;
    public string Name => name;
    public decimal Balance => balance;
}