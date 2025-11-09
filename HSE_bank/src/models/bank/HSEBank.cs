using HSE_bank.consts;
using Microsoft.Extensions.DependencyInjection;

namespace HSE_bank.models.bank;

public sealed class HSEBank(ServiceProvider serviceProvider)
{
    public static string Name => "HSE Bank";
    public int NewAccountId => free_account_id_++;
    public int NewCategoryId => free_category_id_++;
    public int NewOperationId => free_operation_id_++;
    
    private ServiceProvider serviceProvider_ = serviceProvider;

    private int free_account_id_ = 0;
    private int free_category_id_ = 0;
    private int free_operation_id_ = 0;
    
    private HashSet<int> accounts_ = new HashSet<int>();
    private HashSet<int> categories_ = new HashSet<int>();
    private HashSet<int> operations_ = new HashSet<int>();
    
    private Dictionary<int, BankAccount> accounts__ = new Dictionary<int, BankAccount>();
    private Dictionary<int, Category> categories__ = new Dictionary<int, Category>();
    private Dictionary<int, Operation> operations__ = new Dictionary<int, Operation>();

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

    public Result RegisterCategory(Category category)
    {
        if (!categories_.Add(category.Id))
        {
            Console.WriteLine($"Категория {category.Id} уже зарегистрирована!");
            return Result.Error;
        }
        
        categories__.Add(category.Id, category);
        return Result.Ok;
    }

    public void UpdateCategory(Category category)
    {
        categories__[category.Id] = category;
    }

    public bool CheckCategoryId(int categoryId)
    {
        return categories_.Contains(categoryId);
    }

    public void DeleteCategory(int categoryId)
    {
        categories_.Remove(categoryId);
        categories__.Remove(categoryId);
    }

    public Result RegisterOperation(Operation operation)
    {
        if (!operations_.Add(operation.Id))
        {
            Console.WriteLine($"Операция {operation.Id} уже зарегистрирована!");
            return Result.Error;
        }

        operations__.Add(operation.Id, operation);
        return Result.Ok;
    }

    public void UpdateOperation(Operation operation)
    {
        operations__[operation.Id] = operation;
    }

    public bool CheckOperationId(int operationId)
    {
        return operations_.Contains(operationId);
    }

    public void DeleteOperation(int operationId)
    {
        operations_.Remove(operationId);
        operations__.Remove(operationId);
    }
}